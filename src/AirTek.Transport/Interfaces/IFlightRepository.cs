using AirTek.Transport.Models;
using System.Collections.Generic;

namespace AirTek.Transport.Interfaces
{
    public interface IFlightRepository
    {
        IList<Flight> GetFlights();
    }
}
