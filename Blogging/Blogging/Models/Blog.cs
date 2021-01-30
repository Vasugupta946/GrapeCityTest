using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Blogging.Models
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Content { get; set; }

        [Required]
        public int AuthorID { get; set; }

        public string Secret { get; set; }

    }
}
