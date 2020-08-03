using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fest.Core.Services.CityInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet("{zipCode}")]
        public string Get(string zipCode)
        {
            return _cityInfoService.GetCityInfo(zipCode);
        }
    }
}