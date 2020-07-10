using AirTek.Transport.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AirTek.Transport.Config
{
    public class PriorityConverter : JsonConverter<Service>
    {
        Dictionary<string, int> priorities = new Dictionary<string, int>()
        {
            {"same-day",0 },
            {"next-day",1 },
            {"regular" ,2}
        };
        public override Service Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return (Service)priorities[reader.GetString()];
        }

        public override void Write(Utf8JsonWriter writer, Service value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
