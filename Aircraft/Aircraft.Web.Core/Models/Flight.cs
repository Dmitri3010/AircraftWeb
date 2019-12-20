using Newtonsoft.Json;

namespace Aircraft.Web.Core.Models
{
    public class Flight:Base
    {
        [JsonProperty(PropertyName = "arrivivalCity")]
        public string ArrivivalCity { get; set; }
                
        [JsonProperty(PropertyName = "fromCity")]
        public string FromCity { get; set; }
        
        [JsonProperty(PropertyName = "cost")]
        public double Cost { get; set; }
        
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }
    }
}