using AirTek.Transport.Config;
using System.Text.Json.Serialization;

namespace AirTek.Transport.Models
{
    public class Order
    {
        [JsonConverter(typeof(PriorityConverter))]
        public Service Service { get; set; }

        public string Destination { get; set; }
    }

    public enum Service
    {
        same_day,
        next_day,
        regular
    }
}
