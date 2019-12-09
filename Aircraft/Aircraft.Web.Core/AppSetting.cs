using Microsoft.AspNetCore.Builder;

namespace Aircraft.Web.Core
{
    public static class AppSettings
    {
        public static IApplicationBuilder ApplicationBuilder { get; set; }
        
        public static string AuthTokenSecret { get; set; }
    }
}