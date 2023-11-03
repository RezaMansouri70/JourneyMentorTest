namespace Application.Models.Flight
{
    public class Live
    {
        public DateTime updated { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double altitude { get; set; }
        public double direction { get; set; }
        public double speed_horizontal { get; set; }
        public double speed_vertical { get; set; }
        public bool is_ground { get; set; }
    }
}
