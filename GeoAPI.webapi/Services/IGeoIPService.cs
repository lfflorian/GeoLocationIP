using GeoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoAPI.webapi.Services
{
    public interface IGeoIPService
    {
        IPLocation GetGeolocalization(string ip);
    }
}
