namespace AirTek.Transport.Models
{
    public class Schedule
    {
        public string Order { get; set; }
        public string FlightNumber { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int Day { get; set; }
        public Service Service { get; set; }
    }
}
