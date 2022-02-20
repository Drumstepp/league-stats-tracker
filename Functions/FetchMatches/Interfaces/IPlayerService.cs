using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Drumstepp.Models;

namespace Drumstepp.FetchMatches.Interfaces
{
    public interface IPlayerService
    {
        public Task<ICollection<Player>> GetPlayers();
        public Task UpdatePlayer(Player p);
    }
}