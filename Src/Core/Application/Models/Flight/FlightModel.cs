﻿namespace Application.Models.Flight
{
    public class FlightModel
    {

        public DateOnly flight_date { get; set; }
        public string flight_status { get; set; }
        public Departure departure { get; set; }
        public Arrival arrival { get; set; }
        public Airline airline { get; set; }
        public Flight flight { get; set; }
        public Aircraft aircraft { get; set; }
        public Live live { get; set; }
    }
}
