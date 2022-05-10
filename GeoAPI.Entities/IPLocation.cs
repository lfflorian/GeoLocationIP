using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoAPI.Entities
{
    public class IPLocation
    {
        public string IP { get; set; }
        public string Geolocation { get; set; }
        public bool Found { get; set; }
    }
}
