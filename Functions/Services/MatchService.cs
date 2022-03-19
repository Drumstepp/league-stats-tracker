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
    public class MatchService : IMatchService
    {
        private LolContext _context;
        public MatchService(LolContext context)
        {
            _context = context;
        }
        public ICollection<String> GetMatchHistory(string puuid)
        {
            return null;
        }

        public async Task<Match> GetMatch(string matchId)
        {
            return await _context.Matches.FirstOrDefaultAsync(x => x.MatchId == matchId);
        }
        public async Task<bool> GetMatchExists(string matchId) 
        {
            return await _context.Matches.AnyAsync(x => x.MatchId == matchId);
        }

        public async Task<Match> AddMatch(Match match) {
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
            return match;
        }        
        public async Task UpdateMatch(Match match) {
            var dbMatch = await _context.Matches.SingleOrDefaultAsync(x => x.Id == match.Id);
            dbMatch = match;
            await _context.SaveChangesAsync();
        }
        
        public async Task<ICollection<String>> GetMatchesNotInDb(ICollection<String> matchIds)
        {
            // Fetches matches in database that match the matchIds
            var dbList = await _context.Matches.Where(x => matchIds.Contains(x.MatchId)).ToListAsync();   
            // Returns matches that are NOT in the database
            return matchIds.Where(x => dbList.All(y => y.MatchId != x)).ToArray();
        }

    }
}
