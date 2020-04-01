using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeagueMatchesResponse : GetResponse
    {
        public Match[] data { get; set; }
    }
}
