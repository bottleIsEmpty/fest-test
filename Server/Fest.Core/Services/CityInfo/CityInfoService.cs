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

        public string GetCityInfo(string zipCode)
        {
            return _cityTemperatureApiQuery.GetDataForCity(zipCode) + _timezoneApiQuery.GetDataForCity(zipCode);
        }
    }
}