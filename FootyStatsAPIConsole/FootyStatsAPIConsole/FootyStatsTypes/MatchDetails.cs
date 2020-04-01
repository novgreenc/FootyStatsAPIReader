using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class MatchDetails : Match
    {
        public Lineups lineups { get; set; }
        public Bench bench { get; set; }

        public Goal[] team_a_goal_details { get; set; }

        public Goal[] team_b_goal_details { get; set; }

    }
}
