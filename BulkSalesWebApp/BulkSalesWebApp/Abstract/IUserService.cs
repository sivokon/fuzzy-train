using BulkSalesWebApp.Data.Models;
using BulkSalesWebApp.Data.Resources;
using System.Collections.Generic;

namespace BulkSalesWebApp.Abstract
{
    public interface IUserService
    {
        IEnumerable<User> RetrieveAllUsers();

        bool UserPasswordIsValid(LoginForm form);

        (bool success, string errorMessage) CreateUser(RegisterForm form);
    }
}
