namespace Fest.Core.Services.ApiQueries
{
    public class CityTemperatureApiQuery : ICityInfoApiQuery
    {
        public string GetDataForCity(string zipCode)
        {
            return "10";
        }
    }
}