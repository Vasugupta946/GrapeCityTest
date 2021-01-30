using Blogging.Models;
using System;

namespace Blogging
{
    /*The DTO is used to:
    1)  Prevent over-posting.
    2)  Hide properties that clients are not supposed to view.
    3)  Omit some properties in order to reduce payload size.
    4)  Flatten object graphs that contain nested objects. 
        Flattened object graphs can be more convenient for clients.*/
    public class BlogDTO
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Content { get; set; }

        public int AuthorID { get; set; }
    }
}
