using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeagueListResponseContainer : GetResponseContainer
    {
        public GetLeagueListResponse LeagueListResponseObject { get; set; }

        public GetLeagueListResponseContainer(string json) : base(json)
        { }

        override protected void ParseResponseJson()
        {
            this.LeagueListResponseObject = JsonSerializer.Deserialize<GetLeagueListResponse>(this.ResponseJson);
        }

    }
}
