using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Airport
{
    public class AirportModel
    {
        public string airport_name { get; set; }
        public string iata_code { get; set; }
        public string icao_code { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string geoname_id { get; set; }
        public string timezone { get; set; }
        public string gmt { get; set; }
        public object phone_number { get; set; }
        public string country_name { get; set; }
        public string country_iso2 { get; set; }
        public string city_iata_code { get; set; }
    }
}
