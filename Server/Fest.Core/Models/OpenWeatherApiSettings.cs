using Fest.Core.Requests;

namespace Fest.Core.Models
{
    public class OpenWeatherApiSettings : ApiSettings
    {
        public string GetUriString(CityInfoRequest cityInfoRequest)
        {
            return string.Format(URL, cityInfoRequest.ZipCode, cityInfoRequest.CountryCode, APIKey);
        }
    }
}