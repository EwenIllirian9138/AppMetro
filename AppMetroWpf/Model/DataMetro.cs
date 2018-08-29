using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librairie;

namespace AppMetroWpf.Model
{
    public class DataMetro : ChampApiRoutes
    {
        private static void Display (Station station)
        {
            station.Finalstatus();
        }
    }
}
