using System;
using System.Text.Json;

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

                FootyStatsTypes.League[] leagues = FootyStatsObjectFactory.GetLeagues(apiKey);

                Console.WriteLine("League Count: {0} - League 1 Name: {1} - League 1 Season Count '{2}'", leagues.Length, leagues[1].name, leagues[1].season.Length);

                FootyStatsTypes.Match[] matches = FootyStatsObjectFactory.GetMatches(apiKey, 1625);

                Console.WriteLine("Matches count: {0} - Match 1 ID: {1} - Match 1 total goal count '{2}'", matches.Length, matches[0].id, matches[0].totalGoalCount);

                FootyStatsTypes.MatchDetails matchDetails = FootyStatsObjectFactory.GetMatchDetails(apiKey, 453979);

                Console.WriteLine("Match ID: {0} - Match Attendance: {1} - Match total goal count'{2}'", matchDetails.id, matchDetails.attendance, matchDetails.totalGoalCount);
            }
        }
    }
}
