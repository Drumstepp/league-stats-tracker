using System;
using System.Collections.Generic;

namespace Drumstepp.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string MatchId { get; set; }
        public DateTime GameStart { get; set; }
        public DateTime GameEnd { get; set; }
        public string GameMode { get; set; }

        public ICollection<PlayerMatch> PlayerMatches { get; set; }
    }
}