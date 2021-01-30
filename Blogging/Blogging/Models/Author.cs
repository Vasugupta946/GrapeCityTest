using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogging.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string Email { get; set; }

        public int Phone { get; set; }

        [Required]
        public string Password { get; set; }
    }
}


