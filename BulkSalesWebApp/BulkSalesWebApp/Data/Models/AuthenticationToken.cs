namespace BulkSalesWebApp.Data.Models
{
    public class AuthenticationToken
    {
        public string TokenType { get; private set; } = "Bearer";

        public string AccessToken { get; set; }
    }
}
