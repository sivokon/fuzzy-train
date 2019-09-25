using System;

namespace BulkSalesWebApp.Data.Resources
{
    public class Post : Resource
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public Guid PostDetailsId { get; set; }
        public virtual PostDetails PostDetails { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        public Guid ParentId { get; set; }
        public virtual Post Parent { get; set; }
    }
}
