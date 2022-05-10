using GeoAPI.Entities;
using MaxMind.GeoIP2;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoAPI.webapi.Services
{
    public class GeoIPService : IGeoIPService
    {
        private readonly IConfiguration _config;
        public GeoIPService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public IPLocation GetGeolocalization(string ip)
        {
            IPLocation iPLocation = new IPLocation();
            iPLocation.IP = ip;

            using (var reader = new DatabaseReader(this._config["AppSettings:GeoDb"]))
            {
                var response = reader.Country(iPLocation.IP);

                iPLocation.Geolocation = response.Country.Name;
            }

            return iPLocation;
        }
    }
}
