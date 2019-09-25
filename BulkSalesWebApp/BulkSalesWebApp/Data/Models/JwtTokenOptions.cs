namespace BulkSalesWebApp.Data.Models
{
    public class JwtTokenOptions
    {
        public string Secret { get; set; }

        public string JwtIssuer { get; set; }

        public int JwtExpireDays { get; set; }
    }
}
