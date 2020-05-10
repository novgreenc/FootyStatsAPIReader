using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeagueMatchesResponseContainer : GetResponseContainer
    {
        private int seasonId { get; set; }

        protected override string requestUri
        {
            get
            {
                return String.Format("https://api.footystats.org/league-matches?key={0}&season_id={1}", AppSettings.Instance.apiKey, this.seasonId);
            }
        }

        protected override string requestCacheFileName
        {
            get
            {
                return String.Format("LeagueMatchesResponseCache_{0}.json", this.seasonId);
            }
        }

        public GetLeagueMatchesResponse LeagueMatchesResponseObject { get; set; }

        public GetLeagueMatchesResponseContainer(int seasonId) : base()
        {
            this.seasonId = seasonId;
            base.GetJson();
        }

        override protected void ParseResponseJson()
        {
            this.LeagueMatchesResponseObject = JsonSerializer.Deserialize<GetLeagueMatchesResponse>(this.ResponseJson);
        }

    }
}
