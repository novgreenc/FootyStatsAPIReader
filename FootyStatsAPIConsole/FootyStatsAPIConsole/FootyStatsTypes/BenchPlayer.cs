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
        
        // Currently commented out as there is a data issue in this field, switching data types depending on value
        // This field has a string value (i.e. “79’”) when the sub actually happened but has an int value (-1) when the sub did not happen
        //public int player_out_time { get; set; }
        
        public PlayerEvent[] player_in_events { get; set; }

    }
}
