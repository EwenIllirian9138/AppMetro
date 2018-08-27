using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Librairie
{
    public class ChampApi
    {
        public ChampApi()
        {
        }

        public ChampApi(ChampApi old)
        {
            Id = old.Id;
            Name = old.Name;
            Latitude = old.Latitude;
            Longitude = old.Longitude;
            Lignes = new List<string>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lines")]
        public List<string> Lignes { get; set; }

    }
}
