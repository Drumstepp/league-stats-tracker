using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Drumstepp.Models;

namespace Drumstepp.FetchMatches.Interfaces
{
    public interface IRiotApiService
    {
        public Task<ICollection<String>> GetMatchesByPUUID(string PUUID);
        public Task<Match> GetMatch(string matchId);
    }
}