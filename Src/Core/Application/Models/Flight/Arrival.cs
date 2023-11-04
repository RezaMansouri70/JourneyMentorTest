namespace Application.Models.Flight
{
    public class Arrival
    {
        public string airport { get; set; }
        public string timezone { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }
        public string terminal { get; set; }
        public string gate { get; set; }
        public string baggage { get; set; }
        public int? delay { get; set; }
        public DateTime scheduled { get; set; }
        public DateTime estimated { get; set; }
        public object actual { get; set; }
        public object estimated_runway { get; set; }
        public object actual_runway { get; set; }
    }
}
