using AutoMapper;
using GeoAPI.Entities;
using GeoAPI.webapi.Middleware;
using GeoAPI.webapi.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoAPI.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocationController : ControllerBase
    {
        private readonly IMapper _mapper;
        public GeolocationController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<IActionResult> Get(GeolocationRequest req)
        {
            return Ok("Get its working");
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<IActionResult> Post([FromBody] IEnumerable<GeolocationRequest> req)
        {
            return Ok("Post its working");
        }
    }
}
