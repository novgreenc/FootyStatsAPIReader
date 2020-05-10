using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeaguePlayersResponse : GetResponse
    {
        public PlayerDetails[] data { get; set; }

    }
}
