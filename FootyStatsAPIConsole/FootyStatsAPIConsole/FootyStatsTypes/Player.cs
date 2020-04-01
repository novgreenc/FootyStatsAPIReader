using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class Player
    {
        public int player_id { get; set; }
        public int shirt_number { get; set; }
        public PlayerEvent[] player_events { get; set; }

    }
}
