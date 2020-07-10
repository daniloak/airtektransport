using AirTek.Transport.Config;
using AirTek.Transport.Interfaces;
using AirTek.Transport.Models;
using AirTek.Transport.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace AirTek.Transport
{
    public class TransportApplication
    {
        private readonly JsonSerializerConfig _jsonSerializerConfig;
        private readonly IFlightRepository _flightRepository;
        private readonly IScheduleService _scheduleService;
        public TransportApplication(JsonSerializerConfig jsonSerializerConfig,
                                    IFlightRepository flightRepository,
                                    IScheduleService scheduleService)
        {
            _jsonSerializerConfig = jsonSerializerConfig;
            _flightRepository = flightRepository;
            _scheduleService = scheduleService;
        }
        public void Run()
        {
            Console.WriteLine("Flights availables");
            WriteFlights();

            Console.WriteLine("Press any key to load the schedule");
            Console.ReadKey();
            Console.Clear();

            var orderJson = Resources.coding_assigment_orders_part_two;
            var orders = JsonSerializer.Deserialize<Dictionary<string, Order>>(orderJson, _jsonSerializerConfig.JsonSerializerOptions);

            var schedules = _scheduleService.Schedule(orders);

            WriteScheduledFlights(schedules);
            WriteNotScheduledFlights(schedules);
        }

        void WriteFlights()
        {
            var flights = _flightRepository.GetFlights();
            foreach (var flight in flights)
                Console.WriteLine($"flightnumber: {flight.Number}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
        }

        void WriteScheduledFlights(IEnumerable<Schedule> schedules)
        {
            foreach (var schedule in schedules.Where(p => p.FlightNumber != null))
                Console.WriteLine($"order: {schedule.Order}, flightnumber: {schedule.FlightNumber}, departure: {schedule.Departure}, arrival: {schedule.Arrival}, day: {schedule.Day}, service: {schedule.Service.ToString()}");
        }

        void WriteNotScheduledFlights(IEnumerable<Schedule> schedules)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var schedule in schedules.Where(p => p.FlightNumber == null))
                Console.WriteLine($"order: { schedule.Order}, flightnumber: not scheduled");
        }
    }
}
