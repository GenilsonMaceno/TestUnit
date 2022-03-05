using System;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using src.Context;

namespace Api.Configurations
{
    public static class ConfigureConnections
    {
         public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = String.Empty;
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                connection = configuration.GetConnectionString("DefaultConnection") ??
                                 "Server=(localdb)\\mssqllocaldb;Database=InformationSecurityPolicy;Trusted_Connection=True;MultipleActiveResultSets=true";
            }
            // else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            // {
            //     connection = configuration.GetConnectionString("DefaultConnection") ??
            //                      "Server=(localdb)\\mssqllocaldb;Database=InformationSecurityPolicy;Trusted_Connection=True;MultipleActiveResultSets=true";
            // }
            
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

            return services;
        }
    }
}