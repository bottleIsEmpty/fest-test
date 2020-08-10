using System;
using System.Linq;
using System.Threading.Tasks;
using Fest.Core.Persistence;
using Fest.Core.Requests;
using Fest.Core.Services.ApiQueries;

namespace Fest.Core.Services.CityInfo
{
    public class CityInfoService : ICityInfoService
    {
        private readonly ICityTemperatureApiQuery _cityTemperatureApiQuery;
        private readonly ITimezoneApiQuery _timezoneApiQuery;
        private readonly MyDbContext _context;
    

        public CityInfoService(ICityTemperatureApiQuery cityTemperatureApiQuery, ITimezoneApiQuery timezoneApiQuery, MyDbContext context)
        {
            _cityTemperatureApiQuery = cityTemperatureApiQuery;
            _timezoneApiQuery = timezoneApiQuery;
        }

        public async Task<string> GetCityInfo(CityInfoRequest cityInfoRequest)
        {
            var dbCityInfo = _context.CityInfos.Where(c => c.ZipCode == cityInfoRequest.ZipCode).FirstOrDefault();


            if (dbCityInfo == null || DateTime.UtcNow - dbCityInfo.UpdatedAt > new TimeSpan(0, 0, 10)) {

                var temperatureApiResponse = await _cityTemperatureApiQuery.GetDataForCity(cityInfoRequest);
                var timezoneApiResponse = await _timezoneApiQuery.GetDataForCity(temperatureApiResponse);

                dbCityInfo = new Fest.Core.Models.CityInfo {
                        Id = dbCityInfo == null ? dbCityInfo.Id : null,
                        Temperature = temperatureApiResponse.Temperature,
                        CityName = temperatureApiResponse.CityName,
                        ZipCode = cityInfoRequest.ZipCode,
                        TimezoneName = timezoneApiResponse.Name,
                        TimezoneOffset = timezoneApiResponse.Offset,
                        UpdatedAt = DateTime.UtcNow,
                    };

                if (dbCityInfo == null) {
                    _context.CityInfos.Add(dbCityInfo);
                } else {
                    _context.CityInfos.Update(dbCityInfo);
                }

                await _context.SaveChangesAsync();

                return
                    $"At the location {temperatureApiResponse.CityName}, the temperature is {temperatureApiResponse.Temperature} degrees by Celsius, and the timezone is \"{timezoneApiResponse.Name}\"";

            }

            dbCityInfo.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return
                $"At the location {dbCityInfo.CityName}, the temperature is {dbCityInfo.Temperature} degrees by Celsius, and the timezone is \"{dbCityInfo.CityName}\" (Data was cahced)";
        }
    }
}