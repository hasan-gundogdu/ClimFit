﻿using ClimFit.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ClimFit.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddAuthServices();
            services.AddODataServices();
            services.AddSwaggerServices();
            services.AddExternalServices();

            return services;
        }
        public static IApplicationBuilder UseInfrastructureMiddleware(this IApplicationBuilder app, bool isDevelopment, bool autoMigration=false)
        {
            app.UseSwaggerServices(isDevelopment);
            app.UseDefaultServices(autoMigration);

            return app;
        }
    }
}
