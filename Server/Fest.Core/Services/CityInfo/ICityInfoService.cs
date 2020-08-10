using System.Threading.Tasks;
using Fest.Core.Requests;

namespace Fest.Core.Services.CityInfo
{
    public interface ICityInfoService
    {
        Task<string> GetCityInfo(CityInfoRequest cityInfoRequest);
    }
}