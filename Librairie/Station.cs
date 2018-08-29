using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Librairie;

namespace Librairie
{
    public class Station
    {
        private IApiMetro _IApiMetro;

        public Station (IApiMetro IApiMetro)
        {
            this._IApiMetro = IApiMetro;
        }

        public Station()
            : this(new RequestAPI())
        {
        }

        public List<ArretAndLineDetails> Finalstatus ()
        {
            string resultReponse = _IApiMetro.Request("https://data.metromobilite.fr/api/linesNear/json?y=45.185270&x=5.727231&dist=500&details=true");
            List<ChampApi> result = formatStaionJson(resultReponse);
            return StationList(result);
        }

        private List<ChampApi> formatStaionJson(string responseJson)
        {
            List<ChampApi> stations = new List<ChampApi>();

            stations = JsonConvert.DeserializeObject<List<ChampApi>>(responseJson);

            return stations;
        }

        private List<ChampApiRoutes> formatDetailJson(string responseJson)
        {
            List<ChampApiRoutes> ligneDetail = new List<ChampApiRoutes>();
            ligneDetail = JsonConvert.DeserializeObject<List<ChampApiRoutes>>(responseJson);

            return ligneDetail;
        }

        private List<ArretAndLineDetails> StationList(List<ChampApi> originalData)
        {
            List<ArretAndLineDetails> result = new List<ArretAndLineDetails>();
            foreach (ChampApi arret in originalData)
            {
                ArretAndLineDetails newArret;
                if (!result.Any(_ => _.ArretName == arret.Name))
                {
                    newArret = new ArretAndLineDetails(arret.Name);
                    result.Add(newArret);
                }

                newArret = result.SingleOrDefault(_ => _.ArretName == arret.Name);
                if (newArret != null)
                {
                    string linesForRequest = GetLinesForUrl(arret.Lignes, newArret.LineDetails);
                    if (!string.IsNullOrEmpty(linesForRequest))
                    {
                        string url = string.Format("https://data.metromobilite.fr/api/routers/default/index/routes?codes={0}", linesForRequest);
                        string resultReponse = _IApiMetro.Request(url);
                        newArret.LineDetails.AddRange(formatDetailJson(resultReponse));
                    }
                }
            }            
            return result;
        }

        private string GetLinesForUrl(List<string> lignes, List<ChampApiRoutes> lineDetails)
        {
            string linesForRequest = "";
            foreach (string ligne in lignes)
            {
                if (!lineDetails.Any(_ => _.Id == ligne) && !linesForRequest.Contains(ligne))
                {
                    linesForRequest += ligne + ",";
                }
            }

            return linesForRequest.TrimEnd(new char[] { ','});
        }

        private void Fusion(List<String> result, List<String> original)
        {
            foreach(String Ligne in original)
            {
                if (!result.Contains(Ligne))
                {
                    result.Add(Ligne);
                }
            }
        }       
    }
}
