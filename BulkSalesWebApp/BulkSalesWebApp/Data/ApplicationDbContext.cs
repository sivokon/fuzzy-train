using BulkSalesWebApp.Data.Resources;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BulkSalesWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostDetails> PostDetails { get; set; }

        public DbSet<Topic> Topic { get; set; }
    }
}
