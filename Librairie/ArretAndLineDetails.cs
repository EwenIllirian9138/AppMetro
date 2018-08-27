using System;
using System.Collections.Generic;


namespace Librairie
{
    public class ArretAndLineDetails
    {
        public ArretAndLineDetails(string arret)
        {
            ArretName = arret;
            LineDetails = new List<ChampApiRoutes>();
        }

        public string ArretName { get; private set; }

        public List<ChampApiRoutes> LineDetails { get; private set; }
    }
}
