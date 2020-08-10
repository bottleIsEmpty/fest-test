using Fest.Core.Services.ApiQueries;
using Fest.Core.Services.CityInfo;
using Microsoft.Extensions.DependencyInjection;

namespace Fest.Core.Configuration
{
    public static class CoreServicesConfiguration
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<ICityTemperatureApiQuery, CityTemperatureApiQuery>();
            services.AddScoped<ITimezoneApiQuery, TimezoneApiQuery>();
            services.AddScoped<ICityInfoService, CityInfoService>();
        }
    }
}