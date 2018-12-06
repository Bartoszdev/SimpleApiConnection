using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApiConnection
{
    public enum Rest
    {
        GET,
        POST,
        PUT,
        DELETE
    }
     class RestClient
    {
        public string endPoint { get; set; }
        public Rest httpMethod {get; set;}
        public RestClient()
        {
            endPoint = String.Empty;
            httpMethod = Rest.GET;
        }
        public string MakeRequest(int numberID)
        {
            string ResponseMsg = String.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(@"http://api.gios.gov.pl/pjp-api/rest/station/sensors/{0}", numberID));

            request.Method = httpMethod.ToString();

            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code :" + response.StatusCode.ToString());

                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using(StreamReader reader = new StreamReader(responseStream))
                        {
                            ResponseMsg = reader.ReadToEnd();
                        }
                    }
                }
            }
            return ResponseMsg;
        }
    }
}
