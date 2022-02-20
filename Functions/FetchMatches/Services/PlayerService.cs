using System;
using System.Collections.Generic;
using Drumstepp.FetchMatches.Interfaces;
using Drumstepp.Models;
using Drumstepp.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Drumstepp.FetchMatches.Services
{
    public class PlayerService : IPlayerService
    {
        private LolContext _context;
        public PlayerService(LolContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Player>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }
        public async Task UpdatePlayer(Player p)
        {
            var dbPlayer = await _context.Players.SingleOrDefaultAsync(x => x.Id == p.Id);
            dbPlayer = p;
            await _context.SaveChangesAsync();
        }


    }
}
