using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Aircraft.Web.Core.Models
{
    public class Airports:Base
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "city ")]
        public string City { get; set; }
        
        [JsonProperty(PropertyName = "capacity")]
        public string Capacity { get; set; }
    }
}