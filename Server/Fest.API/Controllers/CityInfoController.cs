using Fest.Core.DTOs;
using Fest.Core.Services.CityInfo;
using Microsoft.AspNetCore.Mvc;

namespace Fest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityInfoController : ControllerBase
    {
        private readonly CityInfoService _cityInfoService;

        public CityInfoController(CityInfoService cityInfoService)
        {
            _cityInfoService = cityInfoService;
        }

        [HttpGet]
        public string Get([FromQuery] CityInfoRequest cityInfoRequest)
        {
            return _cityInfoService.GetCityInfo(cityInfoRequest);
        }
    }
}