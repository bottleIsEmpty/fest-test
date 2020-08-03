using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Fest.Core.Models;
using Fest.Core.Responses;
using Microsoft.Extensions.Options;

namespace Fest.Core.Services.ApiQueries
{
    public class TimezoneApiQuery : ITimezoneApiQuery
    {
        private readonly IOptions<TimezoneApiSettings> _timeZoneSettings;

        public TimezoneApiQuery(IOptions<TimezoneApiSettings> timeZoneSettings)
        {
            _timeZoneSettings = timeZoneSettings;
        }

        public async Task<TimezoneResponse> GetDataForCity(TemperatureInfoResponse temperatureInfoResponse)
        {
            var httpResponse = await GetDataFromApiEndpoint(temperatureInfoResponse);

            return GetDataFromJsonResponse(httpResponse);
        }

        private async Task<string> GetDataFromApiEndpoint(TemperatureInfoResponse temperatureInfoResponse)
        {
            var client = new HttpClient();

            var requestUri = _timeZoneSettings.Value.GetUriString(temperatureInfoResponse);

            var httpResponse = await client.GetAsync(requestUri);
            return await httpResponse.Content.ReadAsStringAsync();
        }

        private TimezoneResponse GetDataFromJsonResponse(string jsonResponse)
        {
            using var document = JsonDocument.Parse(jsonResponse);
            var rootElement = document.RootElement;

            return new TimezoneResponse
            {
                Name = rootElement.GetProperty("timeZoneName").GetString(),
                Offset = rootElement.GetProperty("rawOffset").GetInt32()
            };
        }
    }
}