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
using MoreLinq;
using System.Collections;

namespace AppMetro
{
    class Station
    {
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


        public List<Station> request()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            WebRequest myRequest = WebRequest.Create("https://data.metromobilite.fr/api/linesNear/json?y=45.185270&x=5.727231&dist=500&details=true");

            WebResponse myResponse = myRequest.GetResponse();

            Stream dataStream = myResponse.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseJson = reader.ReadToEnd();

            List<Station> stations = new List<Station> ();

            stations = JsonConvert.DeserializeObject<List<Station>>(responseJson);

            return stations;

        }

        public List<Station> StationList(List<Station> stations)
        {

            Dictionary<string, Station> stationOrder = new Dictionary<string, Station>();
            List<Station> listeResult = new List<Station>();

            foreach (Station station in stations)
            {
                if (!stationOrder.ContainsKey(station.Name))
                {
                    List<String> LignesBackup = station.Lignes;
                    station.Lignes = new List<string>();
                    fusion(station.Lignes, LignesBackup);
                    stationOrder.Add(station.Name, station);
                    listeResult.Add(station);
                }
                else
                {
                    Station previousStation = null;
                    stationOrder.TryGetValue(station.Name, out previousStation);

                    fusion(previousStation.Lignes, station.Lignes);
                }
            }
            return listeResult;
        }

        public void DisplayStationOrder (List<Station> ListStation)
        {
            foreach(Station station in ListStation)
            {
                Console.WriteLine(station.Name);

                foreach(string ligne in station.Lignes)
                {
                    Console.WriteLine(ligne);
                }
            }
        }
        private void fusion(List<String> liste1, List<String> liste2)
        {
            foreach(String Ligne in liste2)
            {
                if (!liste1.Contains(Ligne))
                {
                    liste1.Add(Ligne);
                }
            }
        }
    }
}
