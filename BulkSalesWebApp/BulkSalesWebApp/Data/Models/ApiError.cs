namespace BulkSalesWebApp.Data.Models
{
    public class ApiError
    {
        public string Message { get; set; }

        public string Details { get; set; }

        public ApiError()
        {
        }

        public ApiError(string message)
        {
            Message = message;
        }
    }
}
