using System.Collections.Generic;

namespace BulkSalesWebApp.Data.Resources
{
    public class Topic : Resource
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
