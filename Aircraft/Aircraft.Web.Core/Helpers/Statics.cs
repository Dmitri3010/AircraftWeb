using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Aircraft.Web.Core.Helpers
{
    public static class Statics
    {
        public static IConfiguration Configuration { get; set; }
        public static IHostingEnvironment HostingEnvironment { get; set; }
        public static string WebRootPath => HostingEnvironment.WebRootPath;
    }
}