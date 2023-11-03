using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.DomainClass
{
    public class Airport
    {
        protected Airport()
        {
        }
        public Airport(string airportname, string iata_code, string icao_code, string latitude, string longitude, string geoname_id, string timezone, string gmt, string phone_number, string country_name, string country_iso2, string city_iata_code
            )
        {
            Name validateairportname = new Name(airportname);
            this.airport_name = validateairportname;
            this.iata_code = iata_code;
            this.icao_code = icao_code;
            this.latitude = latitude;
            this.longitude = longitude;
            this.geoname_id = geoname_id;
            this.timezone = timezone;
            this.gmt = gmt;
            this.phone_number = phone_number;
            this.country_name = country_name;
            this.country_iso2 = country_iso2;
            this.city_iata_code = city_iata_code;
        }
        public int Id { get; set; }
        public Name airport_name { get; }
        public string iata_code { get; }
        public string icao_code { get; }
        public string latitude { get; }
        public string longitude { get; }
        public string geoname_id { get; }
        public string timezone { get; }
        public string gmt { get; }
        public string phone_number { get; }
        public string country_name { get; }
        public string country_iso2 { get; }
        public string city_iata_code { get; }

    }


}
