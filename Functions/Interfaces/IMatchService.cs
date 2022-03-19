using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Drumstepp.Models;

namespace Drumstepp.Common.Interfaces
{
    public interface IMatchService
    {
        public ICollection<String> GetMatchHistory(string puuid);
        public Task<Match> GetMatch(string matchId);
        public Task<ICollection<String>> GetMatchesNotInDb(ICollection<String> matchIds);
        public Task<bool> GetMatchExists(string matchId);
        public Task<Match> AddMatch (Match match);
        public Task UpdateMatch(Match match);
    }
}