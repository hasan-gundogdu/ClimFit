using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace ClimFit.Infrastructure.Extensions
{
    public static class AuthServiceCollectionExtension
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {

                options.Authority = "https://localhost:7110";
                options.Audience = "climfit_45c078c9";
                options.RequireHttpsMetadata = false;
            });

            return services;
        }
    }
}