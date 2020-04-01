using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeagueListResponse : GetResponse
    {
        public League[] data { get; set; }
    }
}
