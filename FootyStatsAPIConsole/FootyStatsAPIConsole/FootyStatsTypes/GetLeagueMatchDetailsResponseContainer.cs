using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeagueMatchDetailsResponseContainer : GetResponseContainer
    {

        private int matchId { get; set; }

        protected override string requestUri
        {
            get
            {
                return String.Format("https://api.footystats.org/match?key={0}&match_id={1}", AppSettings.Instance.apiKey, this.matchId);
            }
        }

        protected override string requestCacheFileName
        {
            get
            {
                return String.Format("MatchResponseCache_{0}", this.matchId);
            }
        }

        public GetLeagueMatchDetailsResponse LeagueMatchDetailsResponseObject { get; set; }

        public GetLeagueMatchDetailsResponseContainer(int matchId) : base()
        {
            this.matchId = matchId;
            base.GetJson();
        }

        override protected void ParseResponseJson()
        {
            this.LeagueMatchDetailsResponseObject = JsonSerializer.Deserialize<GetLeagueMatchDetailsResponse>(this.ResponseJson);
        }

    }
}
