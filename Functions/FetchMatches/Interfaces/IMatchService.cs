using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Drumstepp.Models;

namespace Drumstepp.FetchMatches.Interfaces
{
    public interface IMatchService
    {
        public ICollection<String> GetMatchHistory(string puuid);
        public Match GetMatch(string matchId);
        public ICollection<String> GetMatchesNotInDb(ICollection<String> matchIds);
        public Task<bool> GetMatchExists(string matchId);
        public Task SaveMatch(Match match);
    }
}