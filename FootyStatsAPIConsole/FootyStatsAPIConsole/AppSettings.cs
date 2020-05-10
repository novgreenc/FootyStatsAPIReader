using System;
using System.Collections.Generic;
using System.Text;

namespace FootyStatsAPIConsole
{
    class AppSettings
    {
        private static AppSettings instance;

        private AppSettings() { }

        public static AppSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppSettings();
                }
                return instance;
            }
        }

        public bool enableCaching { get; set; }

        public bool readFromCacheWhenAvailable { get; set; }

        public string apiKey { get; set; }

    }
}
