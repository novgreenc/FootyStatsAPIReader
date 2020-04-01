using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class BenchPlayer
    {
        public int player_in_shirt_number { get; set; }
        
        public int player_in_id { get; set; }
        
        public int player_out_id { get; set; }
        
        public string player_out_time { get; set; }
        
        public PlayerEvent[] player_in_events { get; set; }

    }
}
