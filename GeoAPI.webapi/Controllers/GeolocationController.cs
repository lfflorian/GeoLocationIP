using GeoAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoAPI.webapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeolocationController : ControllerBase
    {
        public GeolocationController()
        {

        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok("Get its working");
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            return Ok("Post its working");
        }
    }
}
