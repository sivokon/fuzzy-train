using System;
using BulkSalesWebApp.Data.Models;
using BulkSalesWebApp.Data.Resources;
using BulkSalesWebApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BulkSalesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly PostRepository _postRepository;

        public PostsController(UserManager<User> userManager, PostRepository postRepository)
        {
            _userManager = userManager;
            _postRepository = postRepository;
        }

        //GET: api/posts/5
        [HttpGet]
        [Route("posts/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserPosts(Guid userId)
        {
            if (_userManager.FindByIdAsync(userId.ToString()) == null)
            {
                return NotFound(new ApiError("User with specified id was not found"));
            }

            return Ok(_postRepository.GetUserPosts(userId));
        }

        //POST: api/posts
        [HttpPost]
        public IActionResult CreatePost()
        {

        }

        [HttpPut]
        public IActionResult UpdatePost()
        {

        }

        public IActionResult DeletePost()
        {

        }
    }
}