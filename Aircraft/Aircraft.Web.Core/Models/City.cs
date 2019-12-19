using Newtonsoft.Json;

namespace Aircraft.Web.Core.Models
{
    public class City:Base
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}