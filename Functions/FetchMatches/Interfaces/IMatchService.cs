using System;
using System.Collections.Generic;
using Drumstepp.Models;

namespace Drumstepp.FetchMatches.Interfaces
{
    public interface IMatchService
    {
        public ICollection<String> GetMatchHistory(string puuid);
        public Match GetMatch(string matchId);
    }
}