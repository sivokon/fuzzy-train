using BulkSalesWebApp.Abstract;
using BulkSalesWebApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BulkSalesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public UsersController(IUserService userService, IConfiguration configuration, UserManager<User> userManager)
        {
            _userService = userService;
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _userManager.Users.ToList();
        }

        // POST: api/users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginForm form)
        {
            var (userIsValid, errorMessage) = _userService.CheckUserPassword(form);

            if (userIsValid)
            {
                //TODO: return Jwt token
                return Ok(GenerateJwtToken(form.Email));
            };

            return BadRequest(new ApiError
            {
                Message = "Login attempt failed.",
                Details = errorMessage
            });
        }

        // POST: api/users/register
        [HttpPost("~/register")]
        public IActionResult Register([FromBody] RegisterForm form)
        {
            var (success, errorMessage) = _userService.CreateUser(form);

            if (success)
            {
                //TODO: return Jwt token
                return Ok(GenerateJwtToken(form.Email));
            }

            return BadRequest(new ApiError
            {
                Message = "Registration failed.",
                Details = errorMessage
            });
        }

        private object GenerateJwtToken(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtToken:JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtToken:JwtIssuer"],
                _configuration["JwtToken:JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}