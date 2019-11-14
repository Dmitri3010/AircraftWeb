using System;
using Newtonsoft.Json;

namespace Aircraft.Web.Core.Models
{
    public class Base
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }
}