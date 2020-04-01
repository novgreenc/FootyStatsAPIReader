using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class Pager
    {
        public int current_page { get; set; }
        public int max_page { get; set; }

        public int results_per_page { get; set; }

        public int total_results { get; set; }

    }
}
