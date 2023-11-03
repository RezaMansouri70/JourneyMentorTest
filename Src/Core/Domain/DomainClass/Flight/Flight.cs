using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainClass
{
    public class Flight
    {
        protected Flight()
        {
        }
        public Flight(string title, int airportId , string flight_date ,string flight_status)
        {
            Name validateName = new Name(title);
            AirportId = airportId;
        }

        public int Id { get; set; }
        public string flight_date { get; set; }
        public string flight_status { get; set; }
        public Departure departure { get; set; }
        public Arrival arrival { get; set; }
        public Airline airline { get; set; }
        public FlightInfo flight { get; set; }
        public Aircraft aircraft { get; set; }
        public Live live { get; set; }
        public int AirportId { get; }
        [ForeignKey("AirportId")]
        public virtual Airport FlightAirport { get; init; } = null!;
    }
}
