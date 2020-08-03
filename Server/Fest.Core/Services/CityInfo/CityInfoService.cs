using System.Threading.Tasks;
using Fest.Core.Requests;
using Fest.Core.Services.ApiQueries;

namespace Fest.Core.Services.CityInfo
{
    public class CityInfoService : ICityInfoService
    {
        private readonly ICityTemperatureApiQuery _cityTemperatureApiQuery;
        private readonly ITimezoneApiQuery _timezoneApiQuery;

        public CityInfoService(ICityTemperatureApiQuery cityTemperatureApiQuery, ITimezoneApiQuery timezoneApiQuery)
        {
            _cityTemperatureApiQuery = cityTemperatureApiQuery;
            _timezoneApiQuery = timezoneApiQuery;
        }

        public async Task<string> GetCityInfo(CityInfoRequest cityInfoRequest)
        {
            var temperatureApiResponse = await _cityTemperatureApiQuery.GetDataForCity(cityInfoRequest);
            var timezoneApiResponse = await _timezoneApiQuery.GetDataForCity(temperatureApiResponse);

            return
                $"At the location {temperatureApiResponse.CityName}, the temperature is {temperatureApiResponse.Temperature}, and the timezone is {timezoneApiResponse.Name}";
        }
    }
}