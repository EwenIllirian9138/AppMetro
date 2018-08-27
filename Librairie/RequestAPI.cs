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
using System.Collections;

namespace Librairie
{
    public class RequestAPI
    {

        public string Request(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            WebRequest myRequest = WebRequest.Create(url);

            WebResponse myResponse = myRequest.GetResponse();

            Stream dataStream = myResponse.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseJson = reader.ReadToEnd();

            return responseJson;


            //"https://data.metromobilite.fr/api/linesNear/json?y=45.185270&x=5.727231&dist=500&details=true"
        }
    }
}
