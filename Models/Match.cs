using System;
namespace Drumstepp.FetchMatches.Models
{
    public class Match
    {
        public string MatchId { get; set; }
        public string puuid { get; set; }
        public DateTime GameStart { get; set; }
        public DateTime GameEnd { get; set; }
        public string GameMode { get; set; }
        public string LanePlayed { get; set; }
        public string SidePlayed { get; set; }
        public int TimeSpentCCD { get; set; }
        public bool Won { get; set; }
    }
}