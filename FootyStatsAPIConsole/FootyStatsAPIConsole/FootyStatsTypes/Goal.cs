using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class Goal
    {
        public int player_id { get; set; }
        public int assist_player_id { get; set; }
        public string time { get; set; }

        public int clean_time
        {
            get
            {
                int clean_time = -1;

                DataTable dt = new DataTable();
                try
                {
                    clean_time = (int)dt.Compute(time, "");
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Caught an exception of type {0} with message: {1}", e.GetType(), e.Message);
                }

                return clean_time;
            }
        }

        public bool home { get; set; }

        // TODO: need to add type and extra field if I figure out what data type it is
    }
}
