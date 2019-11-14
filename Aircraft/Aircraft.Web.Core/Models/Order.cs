using System;
using Newtonsoft.Json;

namespace Aircraft.Web.Core.Models
{
    public class Order:Base
    {
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }
        
        [JsonProperty(PropertyName = "ticketId")]
        public string TicketId { get; set; }
        
        [JsonProperty(PropertyName = "countOfPassangers")]
        public int CountOfPassangers { get; set; }
        
        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }
        
        [JsonProperty(PropertyName = "orderTime")]
        public DateTimeOffset OrderTime { get; set; }
        
        
    }
}