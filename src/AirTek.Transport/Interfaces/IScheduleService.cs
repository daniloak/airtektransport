using AirTek.Transport.Models;
using System.Collections.Generic;

namespace AirTek.Transport.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<Schedule> Schedule(IDictionary<string, Order> orders);
    }
}
