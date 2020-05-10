using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace FootyStatsAPIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1 || String.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Please specify your API key.");
            }
            else
            {
                Console.WriteLine("API Key provided: '{0}'", args[0]);

                string apiKey = args[0];

                var appSettings = AppSettings.Instance;
                appSettings.apiKey = apiKey;
                appSettings.enableCaching = true;
                appSettings.readFromCacheWhenAvailable = true;

                Get_Players_Involved_In_Goals_With_Context(apiKey, 1905);
            }
        }



        static void Get_Players_Involved_In_Goals_With_Context(string apiKey, int seasonId)
        {
            List<FootyStatsTypes.MatchDetails> matchDetailsList = new List<FootyStatsTypes.MatchDetails>();
            List<FootyStatsTypes.PlayerGoal> playerGoalsList = new List<FootyStatsTypes.PlayerGoal>();

            Dictionary<int, FootyStatsTypes.PlayerDetails> playerDetailsIndexed = FootyStatsObjectFactory.GetLeaguePlayersIndexById(apiKey, seasonId);
            Dictionary<int, FootyStatsTypes.TeamDetails> teamDetailsIndexed = FootyStatsObjectFactory.GetLeagueTeamsIndexById(apiKey, seasonId);

            FootyStatsTypes.Match[] matches = FootyStatsObjectFactory.GetMatches(apiKey, seasonId);

            int counter = 0;

            foreach (FootyStatsTypes.Match match in matches)
            {
                FootyStatsTypes.MatchDetails matchDetails = FootyStatsObjectFactory.GetMatchDetails(apiKey, match.id);
                matchDetailsList.Add(matchDetails);

                // if (++counter > 5) break;
            }

            foreach (FootyStatsTypes.MatchDetails matchDetails in matchDetailsList)
            {
                if (matchDetails.status == "canceled")
                    continue;

                int previous_score_home = 0;
                int previous_score_away = 0;


                List<FootyStatsTypes.Goal> homeGoals = matchDetails.team_a_goal_details.ToList();
                int homeGoalsCount = homeGoals.Count;
                List<FootyStatsTypes.Goal> awayGoals = matchDetails.team_b_goal_details.ToList();
                int awayGoalsCount = awayGoals.Count;

                List<FootyStatsTypes.Goal> sortedGoals = new List<FootyStatsTypes.Goal>();

                while (homeGoals.Count > 0 || awayGoals.Count > 0)
                {
                    FootyStatsTypes.Goal currentGoal;

                    if (homeGoals.Count == 0)
                    {
                        currentGoal = awayGoals[0];
                        currentGoal.home = false;
                        awayGoals.RemoveAt(0);
                        sortedGoals.Add(currentGoal);
                    } 
                    else if (awayGoals.Count == 0)
                    {
                        currentGoal = homeGoals[0];
                        currentGoal.home = true;
                        homeGoals.RemoveAt(0);
                        sortedGoals.Add(currentGoal);
                    } 
                    else
                    {
                        if (homeGoals[0].clean_time < awayGoals[0].clean_time)
                        {
                            currentGoal = homeGoals[0];
                            currentGoal.home = true;
                            homeGoals.RemoveAt(0);
                        }
                        else
                        {
                            currentGoal = awayGoals[0];
                            currentGoal.home = false;
                            awayGoals.RemoveAt(0);
                        }

                        sortedGoals.Add(currentGoal);
                    }
                }

                for(int i = 0; i < sortedGoals.Count; i++)
                {
                    FootyStatsTypes.PlayerGoal currentPlayerGoal = new FootyStatsTypes.PlayerGoal();
                    FootyStatsTypes.Goal currentGoal = sortedGoals[i];

                    if (sortedGoals.Count == 1)
                    {
                        currentPlayerGoal.only_goal = true;
                    }

                    currentPlayerGoal.player_id = currentGoal.player_id;
                    currentPlayerGoal.player_name = playerDetailsIndexed[currentGoal.player_id].full_name;

                    currentPlayerGoal.match_id = matchDetails.id;

                    currentPlayerGoal.previous_score_home = previous_score_home;
                    currentPlayerGoal.previous_score_away = previous_score_away;

                    currentPlayerGoal.scored = true;

                    if ((previous_score_home - previous_score_away) == 0)
                    {
                        currentPlayerGoal.go_ahead_goal = true;

                        if (i == sortedGoals.Count - 1)
                        {
                            currentPlayerGoal.game_winning_goal = true;
                        }
                    }
                    else if ((((previous_score_home - previous_score_away) == -1) && currentGoal.home) || (((previous_score_home - previous_score_away) == 1) && !currentGoal.home))
                    {
                        currentPlayerGoal.tying_goal = true;

                        if (i == sortedGoals.Count - 1)
                        {
                            currentPlayerGoal.game_tying_goal = true;
                        }
                    }

                    if (currentGoal.home)
                    {
                        if (homeGoalsCount == 1)
                        {
                            currentPlayerGoal.only_goal_team = true;
                        }
                        currentPlayerGoal.team_id = matchDetails.homeID;

                        currentPlayerGoal.team_name = teamDetailsIndexed[matchDetails.homeID].name;

                        currentPlayerGoal.team_final_table_position = teamDetailsIndexed[matchDetails.homeID].table_position;

                        currentPlayerGoal.away_goal = false;
                        previous_score_home++;
                    }
                    else
                    {
                        if (awayGoalsCount == 1)
                        {
                            currentPlayerGoal.only_goal_team = true;
                        }
                        currentPlayerGoal.team_id = matchDetails.awayID;

                        currentPlayerGoal.team_name = teamDetailsIndexed[matchDetails.awayID].name;

                        currentPlayerGoal.team_final_table_position = teamDetailsIndexed[matchDetails.awayID].table_position;

                        previous_score_away++;
                        currentPlayerGoal.away_goal = true;
                    }

                    playerGoalsList.Add(currentPlayerGoal);

                    /// remember to also do the assist
                }
            }

            var csv = new StringBuilder();

            csv.AppendLine(FootyStatsTypes.PlayerGoal.csv_header);

            foreach (FootyStatsTypes.PlayerGoal playergoal in playerGoalsList)
            {
                csv.AppendLine(playergoal.csv_line);
            }

            string filePath = @"c:\temp\PlayerGoals.csv";

            File.WriteAllText(filePath, csv.ToString());
        }

        static void Test_APIs(string apiKey)
        {
            FootyStatsTypes.League[] leagues = FootyStatsObjectFactory.GetLeagues(apiKey);

            Console.WriteLine("League Count: {0} - League 1 Name: {1} - League 1 Season Count '{2}'", leagues.Length, leagues[1].name, leagues[1].season.Length);

            FootyStatsTypes.Match[] matches = FootyStatsObjectFactory.GetMatches(apiKey, 1625);

            Console.WriteLine("Matches count: {0} - Match 1 ID: {1} - Match 1 total goal count '{2}'", matches.Length, matches[0].id, matches[0].totalGoalCount);

            FootyStatsTypes.MatchDetails matchDetails = FootyStatsObjectFactory.GetMatchDetails(apiKey, 453979);

            Console.WriteLine("Match ID: {0} - Match Attendance: {1} - Match total goal count'{2}'", matchDetails.id, matchDetails.attendance, matchDetails.totalGoalCount);

            FootyStatsTypes.PlayerDetails[] playerDetails = FootyStatsObjectFactory.GetLeaguePlayers(apiKey, 1625);

            Console.WriteLine("Matches count: {0} - Match 1 ID: {1} - Match 1 total goal count '{2}'", playerDetails.Length, playerDetails[0].id, playerDetails[0].full_name);
        }

    }
}
