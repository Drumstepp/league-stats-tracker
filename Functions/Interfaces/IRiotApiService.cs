using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Drumstepp.Models;

namespace Drumstepp.Common.Interfaces
{
    public interface IRiotApiService
    {
        public Task<ICollection<String>> GetMatchesByPUUID(string PUUID, int count = 20, int start = 0);
        public Task<RiotMatch> GetRiotMatch(string matchId);
    }
}