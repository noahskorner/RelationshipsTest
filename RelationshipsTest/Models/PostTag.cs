using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsTest.Models
{
    /// <summary>
    /// PostTag is the Join Table for the Many to Many relationship with Posts and Tags. The PK is the Composite key of (PostId, TagId)
    /// </summary>
    public class PostTag
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
