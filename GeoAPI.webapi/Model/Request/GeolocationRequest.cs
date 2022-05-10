using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoAPI.webapi.Model.Request
{
    public class GeolocationRequest
    {
        [Required(ErrorMessage = "IP is required")]
        public string IP { get; set; }
    }
}
