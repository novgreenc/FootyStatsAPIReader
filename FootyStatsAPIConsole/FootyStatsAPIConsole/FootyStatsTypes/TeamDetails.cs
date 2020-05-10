using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class TeamDetails
    {
        public int id { get; set; }
        public int competition_id { get; set; }

        public string name { get; set; }

        public int table_position { get; set; }

    }
}
