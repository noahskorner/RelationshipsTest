using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsTest.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Many to many relationship with Post. Each tag can belong to multiple Posts, and each Post can have multiple Tags
        /// </summary>
        public ICollection<PostTag> PostTags { get; set; }
    }
}
