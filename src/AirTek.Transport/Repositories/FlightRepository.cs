using AirTek.Transport.Interfaces;
using AirTek.Transport.Models;
using System.Collections.Generic;

namespace AirTek.Transport.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        public IList<Flight> GetFlights()
        {
            var flights = new List<Flight>();

            flights.Add(new Flight()
            {
                Number = "1",
                Day = 1,
                Departure = "YUL",
                Arrival = "YYZ"
            });

            flights.Add(new Flight()
            {
                Number = "2",
                Day = 1,
                Departure = "YUL",
                Arrival = "YYC"
            });

            flights.Add(new Flight()
            {
                Number = "3",
                Day = 1,
                Departure = "YUL",
                Arrival = "YVR"
            });

            flights.Add(new Flight()
            {
                Number = "4",
                Day = 2,
                Departure = "YUL",
                Arrival = "YYZ"
            });

            flights.Add(new Flight()
            {
                Number = "5",
                Day = 2,
                Departure = "YUL",
                Arrival = "YYC"
            });

            flights.Add(new Flight()
            {
                Number = "6",
                Day = 2,
                Departure = "YUL",
                Arrival = "YVR"
            });

            return flights;
        }
    }
}
