using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Drumstepp.Models
{
    public class DbChartData
    {
        public string Name { get; set; }
        public SidePlayed SidePlayed { get; set; }
        public int SecondsSpentCCd { get; set; }
        public string ChampionName { get; set; }
        public bool Won { get; set; }
        public DateTime GameStart { get; set; }
        public DateTime GameEnd { get; set; }
        public string GameMode { get; set; }
        public string MatchId { get; set; }

    }
}