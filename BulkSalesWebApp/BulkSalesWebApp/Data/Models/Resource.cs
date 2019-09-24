using Newtonsoft.Json;

namespace BulkSalesWebApp.Data.Models
{
    public abstract class Resource
    {
        [JsonProperty(Order = -2)]
        public string Href { get; set; }
    }
}
