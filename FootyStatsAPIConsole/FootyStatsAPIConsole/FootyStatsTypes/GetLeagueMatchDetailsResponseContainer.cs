using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeagueMatchDetailsResponseContainer : GetResponseContainer
    {
        public GetLeagueMatchDetailsResponse LeagueMatchDetailsResponseObject { get; set; }

        public GetLeagueMatchDetailsResponseContainer(string json) : base(json)
        { }

        override protected void ParseResponseJson()
        {
            this.LeagueMatchDetailsResponseObject = JsonSerializer.Deserialize<GetLeagueMatchDetailsResponse>(this.ResponseJson);
        }

    }
}
