namespace Fest.Core.Responses
{
    public class TemperatureInfoResponse
    {
        public string Temperature { get; set; }

        public string CityName { get; set; }
        
        public decimal CityLatitude { get; set; }

        public decimal CityLongitude { get; set; }
    }
}