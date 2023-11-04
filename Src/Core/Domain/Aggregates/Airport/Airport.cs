using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.DomainClass
{
    public class Airport : IAggregateRoot
    {
        protected Airport()
        {
        }
        public Airport(string airportname, string iata_code, string icao_code, string latitude, string longitude, string geoname_id, string timezone, string gmt, string phone_number, string country_name, string country_iso2, string city_iata_code)
        {
            this.airport_name = new Name(airportname) ;
            this.iata_code = iata_code;
            this.icao_code = icao_code;
            this.latitude = new Latitude(latitude);
            this.longitude = new Longitude(longitude);
            this.geoname_id = geoname_id;
            this.timezone = timezone;
            this.gmt = gmt;
            this.phone_number = phone_number;
            this.country_name = country_name;
            this.country_iso2 = country_iso2;
            this.city_iata_code = city_iata_code;
        }
        public int Id { get; set; }
        public Name airport_name { get; private set; }
        public string iata_code { get; private set; }
        public string icao_code { get; private set; }
        public Latitude latitude { get; private set; }
        public Longitude longitude { get; private set; }
        public string geoname_id { get; private set; }
        public string timezone { get; private set; }
        public string gmt { get; private set; }
        public string? phone_number { get; private set; }
        public string? country_name { get; private set; }
        public string? country_iso2 { get; private set; }
        public string? city_iata_code { get; private set; }

    }


}
