using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    abstract class GetResponseContainer
    {
        protected string ResponseJson = String.Empty;

        protected abstract string requestUri
        {
            get;
        }

        protected abstract string requestCacheFileName
        {
            get;
        }

        protected string requestCacheFileExtension
        {
            get
            {
                return ".json";
            }
        }

        protected string requestCacheFullFileName
        {
            get
            {
                return String.Format("{0}{1}", requestCacheFileName, requestCacheFileExtension);
            }
        }

        public GetResponseContainer()
        {

        }

        abstract protected void ParseResponseJson();

        protected string GetJson(int pageNumber)
        {
            string response = String.Empty;
            string currentRequestUri = requestUri;
            string currentRequestCacheFullFileName = requestCacheFullFileName;

            if (pageNumber > 1)
            {
                currentRequestUri = String.Format("{0}&page={1}", requestUri, pageNumber);
                currentRequestCacheFullFileName = String.Format("{0}_{1}{2}", requestCacheFileName, pageNumber, requestCacheFileExtension);
            }

            if (AppSettings.Instance.readFromCacheWhenAvailable && File.Exists(currentRequestCacheFullFileName))
            {
                using (StreamReader r = new StreamReader(currentRequestCacheFullFileName))
                {
                    response = r.ReadToEnd();
                }
            }
            else
            {
                RestAPIGetter Request = new RestAPIGetter(currentRequestUri);
                response = Request.GetResponse();
                Thread.Sleep(10 * 1000);

                if (AppSettings.Instance.enableCaching)
                {
                    File.WriteAllText(currentRequestCacheFullFileName, response);
                }
            }

            return response;
        }

        protected void GetJson()
        {
            this.ResponseJson = this.GetJson(1);
            this.ParseResponseJson();
        }


    }
}
