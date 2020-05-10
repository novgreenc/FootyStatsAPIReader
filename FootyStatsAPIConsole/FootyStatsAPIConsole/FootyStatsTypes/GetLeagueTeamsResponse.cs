using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeagueTeamsResponse : GetResponse
    {
        public TeamDetails[] data { get; set; }

    }
}
