using BulkSalesWebApp.Abstract;
using BulkSalesWebApp.Data.Models;
using BulkSalesWebApp.Data.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BulkSalesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UsersController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        //GET: api/users
        [HttpGet]
        public IEnumerable<User> RetrieveAllUsers()
        {
            return _userService.RetrieveAllUsers();
        }

        //POST: api/users/login
        [HttpPost(Name = nameof(Login))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login([FromBody] LoginForm form)
        {
            if (_userService.UserPasswordIsValid(form))
            {
                return Ok(new AuthenticationToken
                {
                    AccessToken = GenerateJwtToken(form.Email)
                });
            }
            else return BadRequest(new ApiError
            {
                Message = "Login attempt failed.",
                Details = "The email or password is invalid."
            });
        }

        //POST: api/users/register
        [HttpPost(Name = nameof(Register))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RegisterForm form)
        {
            var (success, errorMessage) = _userService.CreateUser(form);

            if (success)
            {
                return Ok(new AuthenticationToken
                {
                    AccessToken = GenerateJwtToken(form.Email)
                });
            }

            return BadRequest(new ApiError
            {
                Message = "Registration failed.",
                Details = errorMessage
            });
        }

        private string GenerateJwtToken(string email)
        {
            return _tokenService.GenerateJwtToken(email);
        }
    }
}