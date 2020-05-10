using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class PlayerGoal
    {
        public int player_id { get; set; }

        public string player_name { get; set; }

        public int match_id { get; set; }

        public int team_id { get; set; }

        public string team_name { get; set; }

        public int team_final_table_position { get; set; }

        public bool scored { get; set; }

        public bool assisted { get; set; }

        public int previous_score_home { get; set; }

        public int previous_score_away { get; set; }

        public bool go_ahead_goal { get; set; }

        public bool game_winning_goal { get; set; }

        public bool tying_goal { get; set; }

        public bool game_tying_goal { get; set; }

        public bool only_goal { get; set; }

        public bool only_goal_team { get; set; }

        public bool away_goal { get; set; }

        public string csv_line
        {
            get
            {
                return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}"
                    , player_id
                    , player_name
                    , match_id
                    , team_id
                    , team_name
                    , team_final_table_position
                    , scored
                    , assisted
                    , previous_score_home
                    , previous_score_away
                    , go_ahead_goal
                    , game_winning_goal
                    , tying_goal
                    , game_tying_goal
                    , only_goal
                    , only_goal_team
                    , away_goal);
            }
        }

        public static string csv_header
        {
            get
            {
                return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}"
                    , "player_id"
                    , "player_name"
                    , "match_id"
                    , "team_id"
                    , "team_name"
                    , "team_final_table_position"
                    , "scored"
                    , "assisted"
                    , "previous_score_home"
                    , "previous_score_away"
                    , "go_ahead_goal"
                    , "game_winning_goal"
                    , "tying_goal"
                    , "game_tying_goal"
                    , "only_goal"
                    , "only_goal_team"
                    , "away_goal");
            }
        }
    }
}
