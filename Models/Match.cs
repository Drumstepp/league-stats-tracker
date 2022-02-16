using System;
namespace Drumstepp.FetchMatches.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string MatchId { get; set; }
        public DateTime GameStart { get; set; }
        public DateTime GameEnd { get; set; }
        public string GameMode { get; set; }
        public int TimeSpentCCD { get; set; }
        public bool Won { get; set; }
    }
}