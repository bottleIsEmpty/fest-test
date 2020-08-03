using System.Threading.Tasks;
using Fest.Core.Requests;
using Fest.Core.Services.CityInfo;
using Microsoft.AspNetCore.Mvc;

namespace Fest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityInfoController : ControllerBase
    {
        private readonly ICityInfoService _cityInfoService;

        public CityInfoController(ICityInfoService cityInfoService)
        {
            _cityInfoService = cityInfoService;
        }

        [HttpGet]
        public async Task<string> Get([FromQuery] CityInfoRequest cityInfoRequest)
        {
            return await _cityInfoService.GetCityInfo(cityInfoRequest);
        }
    }
}