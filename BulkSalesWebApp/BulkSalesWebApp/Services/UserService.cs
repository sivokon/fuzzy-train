using BulkSalesWebApp.Abstract;
using BulkSalesWebApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace BulkSalesWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public (bool isValidUser, string errorMessage) CheckUserPassword(LoginForm form)
        {
            var user = _userManager.FindByEmailAsync(form.Email);
            if (user.IsFaulted)
            {
                return (false, user.Exception.Message);
            }

            var result = _userManager.CheckPasswordAsync(user.Result, form.Password);

            return (result.Result, null);
        }

        public (bool success, string errorMessage) CreateUser(RegisterForm form)
        {
            var user = new User
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                UserName = form.Email,
                CreatedAt = DateTimeOffset.Now
            };

            var result = _userManager.CreateAsync(user, form.Password).Result;

            return (result.Succeeded, result.Errors.FirstOrDefault()?.Description);
        }
    }
}
