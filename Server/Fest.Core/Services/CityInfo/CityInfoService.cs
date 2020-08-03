using Fest.Core.DTOs;
using Fest.Core.Services.ApiQueries;

namespace Fest.Core.Services.CityInfo
{
    public class CityInfoService
    {
        private readonly CityTemperatureApiQuery _cityTemperatureApiQuery;
        private readonly TimezoneApiQuery _timezoneApiQuery;

        public CityInfoService(CityTemperatureApiQuery cityTemperatureApiQuery, TimezoneApiQuery timezoneApiQuery)
        {
            _cityTemperatureApiQuery = cityTemperatureApiQuery;
            _timezoneApiQuery = timezoneApiQuery;
        }

        public string GetCityInfo(CityInfoRequest cityInfoRequest)
        {
            return _cityTemperatureApiQuery.GetDataForCity(cityInfoRequest.ZipCode) + " " +
                   _timezoneApiQuery.GetDataForCity(cityInfoRequest.ZipCode);
        }
    }
}