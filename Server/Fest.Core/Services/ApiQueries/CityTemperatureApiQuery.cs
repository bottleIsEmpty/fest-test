using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Fest.Core.Models;
using Fest.Core.Requests;
using Fest.Core.Responses;
using Microsoft.Extensions.Options;

namespace Fest.Core.Services.ApiQueries
{
    public class CityTemperatureApiQuery : ICityTemperatureApiQuery
    {
        private readonly IOptions<OpenWeatherApiSettings> _openWeatherSettings;

        public CityTemperatureApiQuery(IOptions<OpenWeatherApiSettings> openWeatherSettings)
        {
            _openWeatherSettings = openWeatherSettings;
        }

        public async Task<TemperatureInfoResponse> GetDataForCity(CityInfoRequest cityInfoRequest)
        {
            var httpResponse = await GetDataFromApiEndpoint(cityInfoRequest);

            return GetDataFromJsonResponse(httpResponse);
        }

        private async Task<string> GetDataFromApiEndpoint(CityInfoRequest cityInfoRequest)
        {
            var client = new HttpClient();

            var requestUri = _openWeatherSettings.Value.GetUriString(cityInfoRequest); 
            
            var httpResponse = await client.GetAsync(requestUri);
            return await httpResponse.Content.ReadAsStringAsync();
        }

        private TemperatureInfoResponse GetDataFromJsonResponse(string jsonResponse)
        {
            using var document = JsonDocument.Parse(jsonResponse);
            var rootElement = document.RootElement;
            
            return new TemperatureInfoResponse
            {
                Temperature = rootElement.GetProperty("main").GetProperty("temp").ToString(),
                CityLatitude = rootElement.GetProperty("coord").GetProperty("lat").GetDecimal(),
                CityLongitude = rootElement.GetProperty("coord").GetProperty("lon").GetDecimal(),
                CityName = rootElement.GetProperty("name").GetString()
            };
        }
    }
}