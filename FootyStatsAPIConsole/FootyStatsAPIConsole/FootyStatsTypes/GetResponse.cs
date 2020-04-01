using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetResponse
    {
        public bool success { get; set; }

        public Pager pager { get; set; }

        public string message { get; set; }

    }
}
