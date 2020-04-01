using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    abstract class GetResponseContainer
    {
        protected string ResponseJson = String.Empty;

        public GetResponseContainer(string json)
        {
            this.ResponseJson = json;
            this.ParseResponseJson();
        }

        abstract protected void ParseResponseJson();

    }
}
