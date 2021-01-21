using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsTest.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        /// <summary>
        /// One to many relationship with Posts. Each Blog can have many Posts.
        /// </summary>
        public List<Post> Posts { get; set; }
        /// <summary>
        /// One to one relationship with BlogImage. Each Blog has exactly one BlogImage
        /// </summary>
        public BlogImage BlogImage { get; set; }
    }
}
