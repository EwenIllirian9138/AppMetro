using System;
using System.Net;
using System.IO;

namespace Librairie
{
    public class RequestAPI : IApiMetro
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
