using Blogging.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public BlogsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDTO>>> GetBlogs()
        {
            return await _context.Blogs.Select(selector: x => ItemToDTO(x))
                                       .ToListAsync();
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogDTO>> GetBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return ItemToDTO(blog);
        }

        // PUT: api/Blogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, BlogDTO blogDTO)
        {
            if (id != blogDTO.ID)
            {
                return BadRequest();
            }

            Blog blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            else
            {
                blog.ID = blogDTO.ID;
                blog.Title = blogDTO.Title;
                blog.CreatedDate = blogDTO.CreatedDate;
                blog.Content = blogDTO.Content;
                blog.AuthorID = blogDTO.AuthorID;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Blogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Blog>> CreateBlog(BlogDTO blogDTO)
        {
            Blog blog = new Blog
            {
                ID = blogDTO.ID,
                Title = blogDTO.Title,
                CreatedDate = DateTime.Now,
                Content = blogDTO.Content,
                AuthorID = blogDTO.AuthorID
            };
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetBlog", new { id = blog.ID }, blog);
            return CreatedAtAction(nameof(GetBlog), new { id = blog.ID }, ItemToDTO(blog));
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Blog>> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return blog;
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.ID == id);
        }

        private static BlogDTO ItemToDTO(Blog blog) =>
        new BlogDTO
        {
            ID = blog.ID,
            Title = blog.Title,
            CreatedDate = blog.CreatedDate,
            Content = blog.Content,
            AuthorID = blog.AuthorID
        };
    }
}
