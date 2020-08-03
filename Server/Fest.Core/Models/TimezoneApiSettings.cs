using System.Globalization;
using Fest.Core.Responses;

namespace Fest.Core.Models
{
    public class TimezoneApiSettings : ApiSettings
    {
        public string GetUriString(TemperatureInfoResponse temperatureInfoResponse)
        {
            return string.Format(URL, temperatureInfoResponse.CityLatitude.ToString(CultureInfo.InvariantCulture),
                temperatureInfoResponse.CityLongitude.ToString(CultureInfo.InvariantCulture), APIKey);
        }
    }
}