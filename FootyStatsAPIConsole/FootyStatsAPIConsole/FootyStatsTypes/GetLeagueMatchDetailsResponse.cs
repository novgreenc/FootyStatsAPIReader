using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeagueMatchDetailsResponse : GetResponse
    {
        public MatchDetails data { get; set; }
    }
}
