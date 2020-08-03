namespace Fest.Core.Services.ApiQueries
{
    public class TimezoneApiQuery : ICityInfoApiQuery
    {
        public string GetDataForCity(string zipCode)
        {
            return "GMT+2";
        }
    }
}