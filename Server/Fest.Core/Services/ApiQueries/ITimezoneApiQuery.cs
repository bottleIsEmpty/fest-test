using System.Threading.Tasks;
using Fest.Core.Responses;

namespace Fest.Core.Services.ApiQueries
{
    public interface ITimezoneApiQuery
    {
        Task<TimezoneResponse> GetDataForCity(TemperatureInfoResponse temperatureInfoResponse);
    }
}