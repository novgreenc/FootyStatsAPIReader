using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole
{
    class FootyStatsObjectFactory
    {
        public static FootyStatsTypes.League[] GetLeagues(string apiKey)
        {
            FootyStatsTypes.GetLeagueListResponseContainer responseContainer = new FootyStatsTypes.GetLeagueListResponseContainer();
            return responseContainer.LeagueListResponseObject.data;
        }

        public static FootyStatsTypes.Match[] GetMatches(string apiKey, int seasonId)
        {
            FootyStatsTypes.GetLeagueMatchesResponseContainer responseContainer = new FootyStatsTypes.GetLeagueMatchesResponseContainer(seasonId);
            return responseContainer.LeagueMatchesResponseObject.data;
        }

        public static FootyStatsTypes.MatchDetails GetMatchDetails(string apiKey, int matchId)
        {
            FootyStatsTypes.GetLeagueMatchDetailsResponseContainer responseContainer = new FootyStatsTypes.GetLeagueMatchDetailsResponseContainer(matchId);
            return responseContainer.LeagueMatchDetailsResponseObject.data;
        }

        public static FootyStatsTypes.PlayerDetails[] GetLeaguePlayers(string apiKey, int seasonId)
        {
            FootyStatsTypes.GetLeaguePlayersResponseContainer responseContainer = new FootyStatsTypes.GetLeaguePlayersResponseContainer(seasonId);
            return responseContainer.data;
        }

        public static Dictionary<int, FootyStatsTypes.PlayerDetails> GetLeaguePlayersIndexById(string apiKey, int seasonId)
        {
            FootyStatsTypes.GetLeaguePlayersResponseContainer responseContainer = new FootyStatsTypes.GetLeaguePlayersResponseContainer(seasonId);
            return PlayerDetailsIndexedById(responseContainer.data);
        }

        public static Dictionary<int, FootyStatsTypes.TeamDetails> GetLeagueTeamsIndexById(string apiKey, int seasonId)
        {
            FootyStatsTypes.GetLeagueTeamsResponseContainer responseContainer = new FootyStatsTypes.GetLeagueTeamsResponseContainer(seasonId);
            return TeamDetailsIndexedById(responseContainer.data);
        }

        private static Dictionary<int, FootyStatsTypes.PlayerDetails> PlayerDetailsIndexedById(FootyStatsTypes.PlayerDetails[] playerDetails)
        {

            var dictionary = new Dictionary<int, FootyStatsTypes.PlayerDetails>();
            for (int i = 0; i < playerDetails.Length; i++)
            {
                dictionary.Add(playerDetails[i].id, playerDetails[i]);
            }
            return dictionary;
        }

        private static Dictionary<int, FootyStatsTypes.TeamDetails> TeamDetailsIndexedById(FootyStatsTypes.TeamDetails[] teamDetails)
        {

            var dictionary = new Dictionary<int, FootyStatsTypes.TeamDetails>();
            for (int i = 0; i < teamDetails.Length; i++)
            {
                dictionary.Add(teamDetails[i].id, teamDetails[i]);
            }
            return dictionary;
        }

    }
}
