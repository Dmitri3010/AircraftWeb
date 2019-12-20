using Newtonsoft.Json;

namespace Aircraft.Web.Core.Models
{
    public class HotPrice : Base
    {
        [JsonProperty(PropertyName = "cityFrom")]
        public string CityFrom { get; set; }

        [JsonProperty(PropertyName = "cityTo")]
        public string CityTo { get; set; }
        
        [JsonProperty(PropertyName = "leftDays")]
        public string LeftDays { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }
    }
}