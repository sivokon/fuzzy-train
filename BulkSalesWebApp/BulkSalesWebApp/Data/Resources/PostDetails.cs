using System;

namespace BulkSalesWebApp.Data.Resources
{
    public class PostDetails : Resource
    {
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
