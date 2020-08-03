namespace Fest.Core.Services.ApiQueries
{
    public interface ICityInfoApiQuery
    {
        string GetDataForCity(string zipCode);
    }
}