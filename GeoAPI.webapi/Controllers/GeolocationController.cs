using AutoMapper;
using GeoAPI.Entities;
using GeoAPI.webapi.Middleware;
using GeoAPI.webapi.Model.Request;
using GeoAPI.webapi.Services;
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
        private readonly IGeoIPService GeoIPService;
        public GeolocationController(IMapper mapper, IGeoIPService geoIPService)
        {
            _mapper = mapper;
            GeoIPService = geoIPService;
        }

        [HttpGet]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<IActionResult> Get([FromQuery] GeolocationRequest req)
        {
            var location = await GeoIPService.GetGeolocalization(req.IP);

            if (location.Found)
                return Ok(location);
            else
                return NotFound(location);
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<IActionResult> Post([FromBody] IEnumerable<GeolocationRequest> req)
        {
            List<IPLocation> iPLocations = new List<IPLocation>();
            var reqList = req.ToList();

            for (int i = 0; i < reqList.Count(); i++)
            {
                var loc = await GeoIPService.GetGeolocalization(reqList[i].IP);
                iPLocations.Add(loc);
            }

            return Ok(iPLocations);
        }
    }
}
