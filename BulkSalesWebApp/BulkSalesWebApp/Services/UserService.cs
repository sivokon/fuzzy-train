using BulkSalesWebApp.Abstract;
using BulkSalesWebApp.Data.Models;
using BulkSalesWebApp.Data.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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

        public IEnumerable<User> RetrieveAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public bool UserPasswordIsValid(LoginForm form)
        {
            var user = _userManager.FindByEmailAsync(form.Email).Result;
            if (user == null)
            {
                return false;
            }

            return _userManager.CheckPasswordAsync(user, form.Password).Result;
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
