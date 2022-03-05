using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using src.Repositories;

namespace Api.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services){
             services.AddScoped<IRegisterRepository, RegisterRepository>();

             return services;
        }

        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            return services;
        }

        public static IServiceCollection AddLogging(this IServiceCollection services)
        {
            services.AddLogging(builder => builder
                .AddConsole()
                .AddFilter(level => level >= LogLevel.Information)
            );

            return services;
        }
        
        public static IServiceCollection AddCaching(this IServiceCollection services)
        {
            services.AddMemoryCache();            
            services.AddResponseCaching();

            return services;
        }
        
        public static IServiceCollection AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("https://localhost")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            return services;
        }


    }
}