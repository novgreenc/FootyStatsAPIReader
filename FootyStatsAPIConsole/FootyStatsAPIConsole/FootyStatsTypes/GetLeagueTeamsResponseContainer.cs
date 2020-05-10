using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FootyStatsAPIConsole.FootyStatsTypes
{
    class GetLeagueTeamsResponseContainer : GetResponseContainer
    {

        private int seasonId { get; set; }

        private TeamDetails[] dataAllPages;

        protected override string requestUri
        {
            get
            {
                return String.Format("https://api.footystats.org/league-teams?key={0}&season_id={1}", AppSettings.Instance.apiKey, this.seasonId);
            }
        }

        protected override string requestCacheFileName
        {
            get
            {
                return String.Format("LeagueTeamsResponseCache_{0}", this.seasonId);
            }
        }

        private GetLeagueTeamsResponse LeagueTeamsResponseObject { get; set; }

        public TeamDetails[] data
        {
            get
            {
                if (dataAllPages != null && LeagueTeamsResponseObject.pager.max_page > 1)
                {
                    return dataAllPages;
                }
                else
                {
                    return LeagueTeamsResponseObject.data;
                }
            }
        }

        public GetLeagueTeamsResponseContainer(int seasonId) : base()
        {
            this.seasonId = seasonId;
            base.GetJson();    
        }

        override protected void ParseResponseJson()
        {
            this.LeagueTeamsResponseObject = JsonSerializer.Deserialize<GetLeagueTeamsResponse>(this.ResponseJson);
            this.FetchAllData();
        }


        public void FetchAllData()
        {
            int availablePages = this.LeagueTeamsResponseObject.pager.max_page;
            int totalTeamDetails = this.LeagueTeamsResponseObject.pager.total_results;
            int totalTeamDetailsPerPage = this.LeagueTeamsResponseObject.pager.results_per_page;
            this.dataAllPages = new FootyStatsAPIConsole.FootyStatsTypes.TeamDetails[totalTeamDetails];

            if (availablePages == 1)
            {
                this.dataAllPages = data;
            }
            else
            {
                bool morePages = true;
                int currentPage = 2;
                this.LeagueTeamsResponseObject.data.CopyTo(this.dataAllPages, 0);
                while (morePages)
                {
                    string json = base.GetJson(currentPage);
                    GetLeagueTeamsResponse currentLeagueTeamsResponseObject = JsonSerializer.Deserialize<GetLeagueTeamsResponse>(json);

                    currentLeagueTeamsResponseObject.data.CopyTo(this.dataAllPages, totalTeamDetailsPerPage * (currentPage - 1));

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
