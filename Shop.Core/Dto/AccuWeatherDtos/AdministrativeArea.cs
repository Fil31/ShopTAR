using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Shop.Core.Dto.AccuWeatherDtos
{
    public class AdministrativeArea
    {
        [JsonPropertyName("ID")]
        public string ID { get; set; }

        [JsonPropertyName("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("EnglishName")]
        public string EnglishName { get; set; }

        [JsonPropertyName("Level")]
        public int Level { get; set; }

        [JsonPropertyName("LocalizedType")]
        public string LocalizedType { get; set; }

        [JsonPropertyName("EnglishType")]
        public string EnglishType { get; set; }

        [JsonPropertyName("CountryID")]
        public string CountryID { get; set; }
    }
}