using Fest.Core.Services.ApiQueries;
using Fest.Core.Services.CityInfo;
using Microsoft.Extensions.DependencyInjection;

namespace Fest.Core.Configuration
{
    public static class CoreServicesConfiguration
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(CityTemperatureApiQuery));
            services.AddScoped(typeof(TimezoneApiQuery));
            services.AddScoped(typeof(CityInfoService));
        }
    }
}