using System;

namespace BulkSalesWebApp.Data.Resources
{
    public class Comment : Resource
    {
        public string Body { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public Guid ParentId { get; set; }

        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }

        public Guid? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
