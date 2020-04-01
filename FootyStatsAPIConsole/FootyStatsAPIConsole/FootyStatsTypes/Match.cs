using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class Match
    {
        public int id { get; set; }
        public int homeID { get; set; }
        public int awayID { get; set; }
        public string season { get; set; }
        public string status { get; set; }
        public int roundID { get; set; }
        public int game_week { get; set; }
        public int revised_game_week { get; set; }
        public string[] homeGoals { get; set; }
        public string[] awayGoals { get; set; }
        public int homeGoalCount { get; set; }
        public int awayGoalCount { get; set; }
        public int totalGoalCount { get; set; }

        // ...

        public string attendance { get; set; }

    }
}
