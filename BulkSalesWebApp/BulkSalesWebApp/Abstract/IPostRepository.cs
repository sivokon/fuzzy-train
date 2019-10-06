using BulkSalesWebApp.Data.Resources;
using System;
using System.Collections.Generic;

namespace BulkSalesWebApp.Abstract
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetUserPosts(Guid userId);
    }
}
