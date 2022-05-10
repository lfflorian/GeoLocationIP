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
        [RegularExpression(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b", ErrorMessage = "the input is not a valid IP")]
        public string IP { get; set; }
    }
}
