using AirTek.Transport.Config;
using AirTek.Transport.Interfaces;
using AirTek.Transport.Models;
using AirTek.Transport.Repositories;
using AirTek.Transport.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AirTek.Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<TransportApplication>().Run();

            Console.ReadKey();
        }

        private static IServiceCollection ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<JsonSerializerConfig>();
            serviceCollection.AddScoped<IFlightRepository, FlightRepository>();
            serviceCollection.AddScoped<IScheduleService, ScheduleService>();
            serviceCollection.AddTransient<TransportApplication>();

            return serviceCollection;
        }
    }
}
