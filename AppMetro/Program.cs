using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AppMetro
{
    class Program
    {
        static void Main(string[] args)
        {
            Station stationsData = new Station();
            List<Station> Stations = stationsData.request();
            stationsData.DisplayStationOrder(stationsData.StationList(Stations));
        }
    }
}
