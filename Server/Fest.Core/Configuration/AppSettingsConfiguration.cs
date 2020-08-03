using Fest.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fest.Core.Configuration
{
    public static class AppSettingsConfiguration
    {
        public static void AddAppSettingsModels(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpenWeatherApiSettings>(configuration.GetSection("OpenWeather"));
            services.Configure<TimezoneApiSettings>(configuration.GetSection("GoogleTimeZone"));
        } 
    }
}