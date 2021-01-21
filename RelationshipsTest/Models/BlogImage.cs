using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsTest.Models
{
    public class BlogImage
    {
        public int BlogImageId { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }

        /// <summary>
        /// One to one relationship with blog. Each BlogImage relates to exactly one blog.
        /// </summary>
        public int BlogForeignKey { get; set; }
        public Blog Blog { get; set; }
    }
}
