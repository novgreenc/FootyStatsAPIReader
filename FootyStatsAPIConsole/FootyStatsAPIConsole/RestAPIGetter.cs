using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FootyStatsAPIConsole
{
    class RestAPIGetter
    {
        string requestUri;

        public RestAPIGetter(string requestUri)
        {
            this.requestUri = requestUri;
        }

        public string GetResponse()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            string responseJson = readStream.ReadToEnd();

            response.Close();
            readStream.Close();

            return responseJson;
        }


    }
}
