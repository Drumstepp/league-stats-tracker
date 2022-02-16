using System;
namespace Drumstepp.FetchMatches.Models
{
    public class PlayerMatch
    {
        public int Id { get; set; }
        public string MatchId { get; set; }
        public string LanePlayed { get; set; }
        public string SidePlayed { get; set; }
        public bool Won { get; set; }
    }
}