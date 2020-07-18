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

                ScenarioHelpers.Get_Players_Involved_In_Goals_With_Context(apiKey, 1905);
            }
        }
    }
}
