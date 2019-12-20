using System;
using Aircraft.Web.Auth;
using Aircraft.Web.Core;
using Aircraft.Web.Core.Models;
using Aircraft.Web.Core.Models.Enums;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using PN.Storage.EF;
using DB = PN.Storage.EF.SimpleRepository;
using Hash = PN.Crypt.AES;

namespace Aircraft.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public ActionResult<string> Login([FromBody] UserLoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Login) || string.IsNullOrWhiteSpace(model.Password))
            {
                return Ok(new ResponseStatus() {Status = "400", Message = "login or password empty"});
            }

            var loggedUser = DB.Single<User>(u => u.Login.ToLower() == model.Login.ToLower());
            if (loggedUser == null)
            {
                return Ok(new ResponseStatus() {Status = "401", Message = "incorrect login or password"});
            }

            if (loggedUser.PasswordHash != Hash.SHA256Hash(model.Password + loggedUser.PasswordSalt))
            {
                return Ok(new ResponseStatus() {Status = "401", Message = "incorrect password"});
            }

            var authToken = Token.Create(new TokenClaims
            {
                ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(int.MaxValue).ToUnixTimeSeconds(),
                User = new TokenUser
                {
                    Id = loggedUser.Id.ToString(),
                    Name = loggedUser.Login
                }
            }, AppSettings.AuthTokenSecret);

            Response.Headers.Add(AccessToken, authToken);
            Response.Cookies.Append(AccessToken, authToken);

            return Ok(new ResponseStatus() {Status = "200", Message = authToken});
        }

        [HttpPost("Register")]
        public ActionResult Register([FromBody] User model)
        {
            if (Guid.Empty != model.Id)
            {
                return Ok(new ResponseStatus() {Status = "400", Message = "login or password or name empty"});
            }

            if (!string.IsNullOrWhiteSpace(model.PasswordHash) || !string.IsNullOrWhiteSpace(model.PasswordSalt))
            {
                return Ok(new ResponseStatus() {Status = "400", Message = "login or password or name empty"});
            }

            if (string.IsNullOrWhiteSpace(model.Login) || string.IsNullOrWhiteSpace(model.Password) ||
                string.IsNullOrWhiteSpace(model.Email))
            {
                return Ok(new ResponseStatus() {Status = "400", Message = "login or password or name empty"});
            }

            var user = DB.Single<User>(p => p.Login == model.Login || p.FirstName == model.FirstName);

            if (user != null)
            {
                return Ok(new ResponseStatus() {Status = "400", Message = "username or login is busy"});
            }

            model.UserRole = UserRole.User;

            model.PasswordSalt = Hash.SHA256Hash(Guid.NewGuid().ToString());
            model.PasswordHash = Hash.SHA256Hash(model.Password + model.PasswordSalt);

            model.Upsert();

            return Ok(new ResponseStatus() {Status = "200", Message = ""});
        }
    }
}