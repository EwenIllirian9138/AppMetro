
using Librairie;
using System;
using System.Collections.Generic;

namespace AppMetro
{
    public class Program
    {
        static void Main(string[] args)
        {
            Station stationsData = new Station();
            List<ArretAndLineDetails> result = stationsData.Finalstatus();
            DisplayStationOrder(result);
        }

        private static void DisplayStationOrder(List<ArretAndLineDetails> ListStation)
        {
            foreach (ArretAndLineDetails station in ListStation)
            {
                Console.WriteLine(station.ArretName);

                foreach (ChampApiRoutes ligne in station.LineDetails)
                {
                    Console.WriteLine(string.Format("{0}: {1}, {2}", ligne.ShortName, ligne.Type, ligne.Mode));
                }
            }
        }
    }
}
