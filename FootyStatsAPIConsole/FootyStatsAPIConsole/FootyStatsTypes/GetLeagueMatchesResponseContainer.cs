using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeagueMatchesResponseContainer : GetResponseContainer
    {
        public GetLeagueMatchesResponse LeagueMatchesResponseObject { get; set; }

        public GetLeagueMatchesResponseContainer(string json) : base(json)
        { }

        override protected void ParseResponseJson()
        {
            this.LeagueMatchesResponseObject = JsonSerializer.Deserialize<GetLeagueMatchesResponse>(this.ResponseJson);
        }

    }
}
