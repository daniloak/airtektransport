using AirTek.Transport.Config;
using AirTek.Transport.Interfaces;
using AirTek.Transport.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AirTek.Transport.Services
{
    public class ScheduleService : IScheduleService
    {
        const int maxOrderPerFlight = 20;

        private readonly IFlightRepository _flightRepository;
        public ScheduleService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public IEnumerable<Schedule> Schedule(IDictionary<string, Order> orders)
        {
            var schedules = new List<Schedule>();
            var flights = _flightRepository.GetFlights();

            foreach (var flight in flights)
            {
                var scheduableOrders = GetScheduableOrders(orders, flight);
                if (scheduableOrders.Any())
                    schedules.AddRange(scheduableOrders);

                scheduableOrders.ToList().ForEach(p => orders.Remove(p.Order));
            }

            var notScheduledOrders = GetNotScheduledOrders(orders);
            schedules.AddRange(notScheduledOrders);

            return schedules;
        }

        IEnumerable<Schedule> GetScheduableOrders(IDictionary<string, Order> orders, Flight flight)
        {
            var scheduableOrders = orders.OrderBy(p => (int)p.Value.Service)
                                        .Where(p => p.Value.Destination == flight.Arrival)
                                       .Take(maxOrderPerFlight)
                                       .Select(p => new Schedule()
                                       {
                                           Order = p.Key,
                                           FlightNumber = flight.Number,
                                           Day = flight.Day,
                                           Departure = flight.Departure,
                                           Arrival = p.Value.Destination,
                                           Service = p.Value.Service,
                                       }
                                       );

            return scheduableOrders;
        }

        IEnumerable<Schedule> GetNotScheduledOrders(IDictionary<string, Order> orders)
        {
            return orders.Select(p => new Schedule()
            {
                Order = p.Key,
            });
        }
    }
}
