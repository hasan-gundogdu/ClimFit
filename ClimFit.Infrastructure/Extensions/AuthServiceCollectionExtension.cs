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

                options.Authority = "https://demo-auth.infinextsoft.com";
                options.Audience = "dolapp";
                options.RequireHttpsMetadata = false;
            });

            return services;
        }
    }
}