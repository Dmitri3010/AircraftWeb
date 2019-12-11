using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Aircraft.Web.Core.Models
{
    public class Ticket:Base
    {
        [JsonProperty(PropertyName = "orderTime")]
        public DateTimeOffset OrderTime { get; set; }
        
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }
        
        [JsonProperty(PropertyName = "flightTime")]
        public DateTimeOffset FlightTime { get; set; }
        
        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }
        
        [JsonProperty(PropertyName = "arrivivalCity")]
        public string ArrivivalCity { get; set; }
        
        [JsonProperty(PropertyName = "seat")]
        public string Seat { get; set; }
        
        [JsonProperty(PropertyName = "fromCity")]
        public string FromCity { get; set; }
        
        [JsonProperty(PropertyName = "cost")]
        public double Cost { get; set; }
        
    }
}