using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Drumstepp.Models;

namespace Drumstepp.FetchMatches.Interfaces
{
    public interface IPlayerMatchService
    {
        Task<bool> GetPlayerMatchExists(string matchId, string PUUID);
        public Task<int> AddPlayerMatch(PlayerMatch playerMatch);
    }
}