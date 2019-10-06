using System;
using System.Collections.Generic;
using System.Linq;
using BulkSalesWebApp.Abstract;
using BulkSalesWebApp.Data;
using BulkSalesWebApp.Data.Resources;
using Microsoft.AspNetCore.Identity;

namespace BulkSalesWebApp.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public PostRepository(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IEnumerable<Post> GetUserPosts(Guid userId)
        {
            return _dbContext.Posts.Where(post => post.UserId == userId);
        }
    }
}
