using GeoAPI.Entities;
using MaxMind.GeoIP2;
using MaxMind.GeoIP2.Responses;
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
        public async Task<IPLocation> GetGeolocalization(string ip)
        {
            IPLocation iPLocation = new IPLocation();
            CountryResponse countryResponse = new CountryResponse();
            
            using (var reader = new DatabaseReader(this._config["AppSettings:GeoDb"]))
            {
                try
                {
                    var response = reader.TryCountry(ip, out countryResponse);

                    if (response)
                    {
                        iPLocation.IP = countryResponse.Traits.IPAddress;
                        iPLocation.Geolocation = countryResponse.Country.Name;
                        iPLocation.Found = true;
                    }
                    else
                    {
                        iPLocation.IP = ip;
                        iPLocation.Found = false;
                    }
                }
                catch (Exception es)
                {
                    iPLocation.IP = ip;
                    iPLocation.Found = false;
                    Console.WriteLine($"ip ${ip} not found with error: {es.Message}");
                }
            }

            return await Task.FromResult(iPLocation);
        }
    }
}
