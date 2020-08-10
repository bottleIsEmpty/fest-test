using System.Threading.Tasks;
using Fest.Core.Requests;
using Fest.Core.Responses;

namespace Fest.Core.Services.ApiQueries
{
    public interface ICityTemperatureApiQuery
    {
        Task<TemperatureInfoResponse> GetDataForCity(CityInfoRequest cityInfoRequest);
    }
}