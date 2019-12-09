#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

#endregion

namespace Aircraft.Web.Auth
{
    public static class Token
    {
        public static string Create(string secret, int tokenDurationMinutes = 0, Dictionary<string, object> payload = null)
        {
            var claims = new TokenClaims
            {
                ExpiresAt = DateTimeOffset.UtcNow.AddMinutes(tokenDurationMinutes).ToUnixTimeSeconds(), Payloads = payload
            };
            return Create(claims, secret);
        }

        public static string Create(TokenClaims claims, string secret)
        {
            if (claims == null)
            {
                throw new ArgumentNullException(nameof(claims));
            }

            if (secret.IsEmpty())
            {
                throw new ArgumentNullException(nameof(secret));
            }

            var tokenBuilder = new JwtBuilder().WithAlgorithm(new HMACSHA256Algorithm()).WithSecret(secret);

            var claimsDict = claims.ClaimToDictionary();

            foreach (var (key, value) in claimsDict)
            {
                tokenBuilder = tokenBuilder.AddClaim(key, value);
            }
            
            tokenBuilder = tokenBuilder.AddClaim("rnd", Guid.NewGuid());

            return tokenBuilder.Build();
        }

        public static TokenClaims Parse(string token, string secret)
        {
            var json = new JwtBuilder().WithSecret(secret).MustVerifySignature().Decode(token);
            var claim = JsonConvert.DeserializeObject<TokenClaims>(json);
            return claim;
        }

        public static bool TryParse(string token, string secret, out TokenClaims claims, out Exception ex)
        {
            claims = null;
            ex = null;
            try
            {
                claims = Parse(token, secret);
                return true;
            }
            catch (Exception e)
            {
                ex = e;
                return false;
            }
        }

        public static bool IsTokenSignatureVerified(string token, string secret)
        {
            if (secret.IsEmpty())
            {
                throw new ArgumentNullException(nameof(secret));
            }

            if (token.IsEmpty())
            {
                throw new ArgumentNullException(nameof(token));
            }

            try
            {
                new JwtBuilder().WithSecret(secret).MustVerifySignature().Decode(token);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (SignatureVerificationException)
            {
                return false;
            }
        }

        public static bool IsTokenExpired(string token, string secret)
        {
            if (secret.IsEmpty())
            {
                throw new ArgumentNullException(nameof(secret));
            }

            if (token.IsEmpty())
            {
                throw new ArgumentNullException(nameof(token));
            }

            try
            {
                new JwtBuilder().WithSecret(secret).MustVerifySignature().Decode(token);
                return false;
            }
            catch (FormatException)
            {
                return true;
            }
            catch (TokenExpiredException)
            {
                return true;
            }
        }

#region Private methods

        private static Dictionary<string, object> ClaimToDictionary(this TokenClaims claims)
        {
            var claimsDict = new Dictionary<string, object>();

            var props = claims.GetType().GetProperties(ReflectHelp.AccessibleBindingFlags).ToList();

            foreach (var prop in props)
            {
                var claimName = prop.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName ?? prop.Name.ToLower();

                var claimValue = prop.GetValue(claims);

                claimsDict.Add(claimName, claimValue);
            }

            return claimsDict;
        }

#endregion
    }
}