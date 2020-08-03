namespace Fest.Core.Services.ApiQueries
{
    public interface ICityInfoQuery
    {
        string GetDataForCity(string zipCode);
    }
}