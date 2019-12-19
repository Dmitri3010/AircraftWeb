using Microsoft.Extensions.DependencyInjection;

namespace Aircraft.Web
{
    public static class Services
    {
        public static IServiceCollection ConfigureCors(IServiceCollection services)
        {
            
            services.AddCors(o =>
            {
                o.AddPolicy(
                    "CorsPolicy",
                    b => b
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                );
            });
            return services;
        }
    }
}