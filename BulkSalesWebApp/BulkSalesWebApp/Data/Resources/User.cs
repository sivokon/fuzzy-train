using Microsoft.AspNetCore.Identity;
using System;

namespace BulkSalesWebApp.Data.Resources
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
