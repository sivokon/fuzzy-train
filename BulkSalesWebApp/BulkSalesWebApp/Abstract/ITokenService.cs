namespace BulkSalesWebApp.Abstract
{
    public interface ITokenService
    {
        string GenerateJwtToken(string email);
    }
}