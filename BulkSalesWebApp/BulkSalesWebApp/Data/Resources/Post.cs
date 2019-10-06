using System;
using System.Collections.Generic;

namespace BulkSalesWebApp.Data.Resources
{
    public class Post : Resource
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
