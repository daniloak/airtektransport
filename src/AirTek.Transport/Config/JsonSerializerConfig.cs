using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AirTek.Transport.Config
{
    public class JsonSerializerConfig
    {
        public JsonSerializerOptions JsonSerializerOptions { get; }

        public JsonSerializerConfig()
        {
            JsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };
        }
    }
}
