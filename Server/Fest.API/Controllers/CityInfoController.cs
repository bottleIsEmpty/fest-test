using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityInfoController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello";
        }
    }
}