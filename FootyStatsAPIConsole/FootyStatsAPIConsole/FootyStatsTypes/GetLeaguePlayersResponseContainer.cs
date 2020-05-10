using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeaguePlayersResponseContainer : GetResponseContainer
    {

        private int seasonId { get; set; }

        private PlayerDetails[] dataAllPages;

        protected override string requestUri
        {
            get
            {
                return String.Format("https://api.footystats.org/league-players?key={0}&season_id={1}", AppSettings.Instance.apiKey, this.seasonId);
            }
        }

        protected override string requestCacheFileName
        {
            get
            {
                return String.Format("LeaguePlayersResponseCache_{0}", this.seasonId);
            }
        }

        private GetLeaguePlayersResponse LeaguePlayersResponseObject { get; set; }

        public PlayerDetails[] data
        {
            get
            {
                if (dataAllPages != null && LeaguePlayersResponseObject.pager.max_page > 1)
                {
                    return dataAllPages;
                }
                else
                {
                    return LeaguePlayersResponseObject.data;
                }
            }
        }

        public GetLeaguePlayersResponseContainer(int seasonId) : base()
        {
            this.seasonId = seasonId;
            base.GetJson();    
        }

        override protected void ParseResponseJson()
        {
            this.LeaguePlayersResponseObject = JsonSerializer.Deserialize<GetLeaguePlayersResponse>(this.ResponseJson);
            this.FetchAllData();
        }


        public void FetchAllData()
        {
            int availablePages = this.LeaguePlayersResponseObject.pager.max_page;
            int totalPlayerDetails = this.LeaguePlayersResponseObject.pager.total_results;
            int totalPlayerDetailsPerPage = this.LeaguePlayersResponseObject.pager.results_per_page;
            this.dataAllPages = new FootyStatsAPIConsole.FootyStatsTypes.PlayerDetails[totalPlayerDetails];

            if (availablePages == 1)
            {
                this.dataAllPages = data;
            }
            else
            {
                bool morePages = true;
                int currentPage = 2;
                this.LeaguePlayersResponseObject.data.CopyTo(this.dataAllPages, 0);
                while (morePages)
                {
                    string json = base.GetJson(currentPage);
                    GetLeaguePlayersResponse currentLeaguePlayersResponseObject = JsonSerializer.Deserialize<GetLeaguePlayersResponse>(json);

                    currentLeaguePlayersResponseObject.data.CopyTo(this.dataAllPages, totalPlayerDetailsPerPage * (currentPage - 1));

                    if (currentPage == availablePages)
                    {
                        morePages = false;
                    }

                    currentPage++;
                }
            }
            
        }
    }
}
