using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeagueListResponseContainer : GetResponseContainer
    {
        protected override string requestUri
        {
            get
            {
                return String.Format("https://api.footystats.org/league-list?key={0}", AppSettings.Instance.apiKey);
            }
        }

        protected override string requestCacheFileName
        {
            get
            {
                return String.Format("LeagueListResponseCache");
            }
        }

        public GetLeagueListResponse LeagueListResponseObject { get; set; }

        public GetLeagueListResponseContainer() : base()
        {
            base.GetJson();
        }

        override protected void ParseResponseJson()
        {
            this.LeagueListResponseObject = JsonSerializer.Deserialize<GetLeagueListResponse>(this.ResponseJson);
        }

    }
}
