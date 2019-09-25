using Newtonsoft.Json;
using System;

namespace BulkSalesWebApp.Data.Resources
{
    public abstract class Resource
    {
        [JsonProperty(Order = -2)]
        public string Href { get; set; }

        public Guid Id { get; set; }
    }
}
