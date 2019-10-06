using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BulkSalesWebApp.Data.Resources
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
