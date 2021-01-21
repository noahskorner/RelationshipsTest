using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsTest.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        /// <summary>
        /// Many to one relationship with Blog. Each Post can belong to many different blogs. BlogId is the FK
        /// </summary>
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        /// <summary>
        /// Many to many relationship with Tag. Each post can have multiple Tags, and each Tag can belong to multiple Posts
        /// </summary>
        public ICollection<PostTag> PostTags { get; set; }
    }
}
