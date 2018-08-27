using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Librairie
{
    public class ChampApiRoutes
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("longName")]
        public string LongName { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("texteColor")]
        public string TexteColor { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
