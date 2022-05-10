using GeoAPI.Entities;
using MaxMind.GeoIP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoAPI.webapi.Services
{
    public class GeoIPService : IGeoIPService
    {
        public IPLocation GetGeolocalization(string ip)
        {
            IPLocation iPLocation = new IPLocation();
            iPLocation.IP = ip;

            using (var reader = new DatabaseReader(@"GeoLite2-Country.mmdb"))
            {
                var response = reader.Country(iPLocation.IP);

                iPLocation.Geolocation = response.Country.Name;
            }

            return iPLocation;
        }
    }
}
