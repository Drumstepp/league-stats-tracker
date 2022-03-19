using System;
using System.Collections.Generic;
using Drumstepp.Common.Interfaces;
using Drumstepp.Models;
using Drumstepp.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Drumstepp.Common.Services
{
    public class PlayerMatchService : IPlayerMatchService
    {
        private LolContext _context;
        public PlayerMatchService(LolContext context)
        {
            _context = context;
        }
        
        public async Task<bool> GetPlayerMatchExists(string matchId, string PUUID)
        {
            
            return await _context.PlayerMatches.AnyAsync(x => x.Match.MatchId == matchId && x.Player.PUUID == PUUID);
        }

        public async Task<int> AddPlayerMatch(PlayerMatch playerMatch)
        {
            
            await _context.PlayerMatches.AddAsync(playerMatch);
            return await _context.SaveChangesAsync();
        }


    }
}
