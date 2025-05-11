using ClimFit.Abstractions.Services;
using ClimFit.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClimFit.Infrastructure.Extensions
{
    public static class ExternalServiceCollectionExtension
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IHttpRequestBase, HttpRequestBase>();
            services.AddScoped<IAuthApiService, AuthApiService>();

            return services;
        }
        
    }
}