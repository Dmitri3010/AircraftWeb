using System.ComponentModel.DataAnnotations.Schema;
using Aircraft.Web.Core.Models.Enums;
using Newtonsoft.Json;

namespace Aircraft.Web.Core.Models
{
    public class User : Base
    {
        [JsonProperty(PropertyName = "login")] public string Login { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "secondName")]
        public string SecondName { get; set; }

        [JsonProperty(PropertyName = "email")] public string Email { get; set; }

        [JsonProperty(PropertyName = "passwordHash")]
        public string PasswordHash { get; set; }

        [JsonProperty(PropertyName = "passwordSalt")]
        public string PasswordSalt { get; set; }

        [JsonProperty(PropertyName = "phone")] public string Phone { get; set; }

        [JsonProperty(PropertyName = "password"), NotMapped]
        public string Password { get; set; }

        [JsonIgnore] public UserRole UserRole { get; set; }
    }
    
}