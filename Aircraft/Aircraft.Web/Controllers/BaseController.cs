using Aircraft.Web.Auth;
using Aircraft.Web.Core;
using Aircraft.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using PN.Storage.EF;

namespace Aircraft.Web.Controllers
{
    public class BaseController : Controller
    {
        public const string AccessToken = "access-token";

        internal TokenUser GetLoggedUserToken()
        {
            Request.Cookies.TryGetValue(AccessToken, out var cookieValue);
            Request.Cookies.TryGetValue(AccessToken, out var headerValue);

            var maybeToken = string.IsNullOrWhiteSpace(headerValue) ? cookieValue : headerValue;
            if (maybeToken == null)
            {
                Request.Headers.TryGetValue(AccessToken, out var headersValue);
                maybeToken = headersValue;
            }

            Token.TryParse(maybeToken, AppSettings.AuthTokenSecret, out var tokenClaims, out var exception);

            if (exception != null)
            {
                throw exception;
            }

            return tokenClaims.User;
        }

        internal User GetLoggedUser()
        {
            Request.Cookies.TryGetValue(AccessToken, out var cookieValue);
            Request.Cookies.TryGetValue(AccessToken, out var headerValue);

            var maybeToken = string.IsNullOrWhiteSpace(headerValue) ? cookieValue : headerValue;

            Token.TryParse(maybeToken, AppSettings.AuthTokenSecret, out var tokenClaims, out var exception);

            if (exception != null)
            {
                throw exception;
            }

            return SimpleRepository.Single<User>(u =>
                u.Id.ToString() == tokenClaims.User.Id
                || u.Login.ToLower() == tokenClaims.User.Name.ToLower()
            );
        }
    }
}