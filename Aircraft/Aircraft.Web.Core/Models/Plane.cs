using System;
using Newtonsoft.Json;

namespace Aircraft.Web.Core.Models
{
    public class Plane:Base
    {
        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }
        
        [JsonProperty(PropertyName = "manufacturer")]
        public string Manufacturer { get; set; }
        
        [JsonProperty(PropertyName = "createdYear")]
        public string CreatedYear { get; set; }
    }
}