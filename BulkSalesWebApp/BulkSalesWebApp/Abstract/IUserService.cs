using BulkSalesWebApp.Data.Models;

namespace BulkSalesWebApp.Abstract
{
    public interface IUserService
    {
        (bool isValidUser, string errorMessage) CheckUserPassword(LoginForm form);

        (bool success, string errorMessage) CreateUser(RegisterForm form);
    }
}
