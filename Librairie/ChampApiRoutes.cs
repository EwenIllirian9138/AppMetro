using System;
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
        public string TexteColor {get; set;}

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public string RealColor
    {
        get
        {
            return "#" + Color;
        }
    }
        //public Uri Image
        //{
        //    get
        //    {
        //        if(Mode == "BUS")
        //        {
        //            return new Uri(@"/Image/icons8-trolleybus-48.png", UriKind.RelativeOrAbsolute);
        //        }
        //        else
        //        {
        //            return new Uri(@"/Image/icons8-tram-2-48.png", UriKind.RelativeOrAbsolute);
        //        }
        //    }
        //}
    }

}
