using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class Goal
    {
        public int player_id { get; set; }
        public int assist_player_id { get; set; }
        public string time { get; set; }

        // TODO: need to add type and extra field if I figure out what data type it is
    }
}
