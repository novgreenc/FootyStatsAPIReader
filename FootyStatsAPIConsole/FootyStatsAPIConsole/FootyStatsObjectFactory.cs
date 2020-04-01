using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole
{
    class FootyStatsObjectFactory
    {
        public static FootyStatsTypes.League[] GetLeagues(string apiKey)
        {
            RestAPIGetter Request = new RestAPIGetter(String.Format("https://api.footystats.org/league-list?key={0}", apiKey));
            string response = Request.GetResponse();
            FootyStatsTypes.GetLeagueListResponseContainer responseContainer = new FootyStatsTypes.GetLeagueListResponseContainer(response);
            return responseContainer.LeagueListResponseObject.data;
        }

        public static FootyStatsTypes.Match[] GetMatches(string apiKey, int leagueId)
        {
            RestAPIGetter Request = new RestAPIGetter(String.Format("https://api.footystats.org/league-matches?key={0}&season_id={1}", apiKey, leagueId));
            string response = Request.GetResponse();
            FootyStatsTypes.GetLeagueMatchesResponseContainer responseContainer = new FootyStatsTypes.GetLeagueMatchesResponseContainer(response);
            return responseContainer.LeagueMatchesResponseObject.data;
        }

        public static FootyStatsTypes.MatchDetails GetMatchDetails(string apiKey, int matchId)
        {
            RestAPIGetter Request = new RestAPIGetter(String.Format("https://api.footystats.org/match?key={0}&match_id={1}", apiKey, matchId));
            string response = Request.GetResponse();
            FootyStatsTypes.GetLeagueMatchDetailsResponseContainer responseContainer = new FootyStatsTypes.GetLeagueMatchDetailsResponseContainer(response);
            return responseContainer.LeagueMatchDetailsResponseObject.data;
        }
    }
}
