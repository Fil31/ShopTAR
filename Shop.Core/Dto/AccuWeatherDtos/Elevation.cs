using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Shop.Core.Dto.AccuWeatherDtos
{
    public class Elevation
    {
        [JsonPropertyName("Metric")]
        public Metric Metric { get; set; }

        [JsonPropertyName("Imperial")]
        public Imperial Imperial { get; set; }
    }
}