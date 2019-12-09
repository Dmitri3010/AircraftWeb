#region

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

#endregion

namespace Aircraft.Web.Auth
{
    public class TokenClaims
    {
        [JsonProperty(PropertyName = "exp")]
        public long ExpiresAt { get; set; } = DateTimeOffset.UtcNow.AddHours(3).ToUnixTimeSeconds();

        [JsonProperty(PropertyName = "iss")]
        public string Issuer { get; set; }

        [JsonProperty(PropertyName = "user")]
        public TokenUser User { get; set; }
        
        [JsonProperty(PropertyName = "payloads", Required = Required.AllowNull)]
        public Dictionary<string, object> Payloads { get; set; }
    }

    public class TokenUser
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; set; }

        [JsonProperty(PropertyName = "attributes", Required = Required.AllowNull)]
        public Dictionary<string, object> Attributes { get; set; }
    }
}