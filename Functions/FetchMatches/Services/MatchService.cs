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

        public Match GetMatch(string matchId)
        {
            var y = _context.PlayerMatches.Where(x => x.Player.Name == "Drumstepp").ToList();
            return _context.Matches.Where(x => x.Id == 1).FirstOrDefault();
        }
        public async Task<bool> GetMatchExists(string matchId) 
        {
            return await _context.Matches.AnyAsync(x => x.MatchId == matchId);
        }

        public async Task SaveMatch(Match match) {
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
            return;
        }

        
        public ICollection<String> GetMatchesNotInDb(ICollection<String> matchIds)
        {
            // Fetches matches in database that match the matchIds
            var dbList = _context.Matches.Where(x => matchIds.Contains(x.MatchId));   
            // Returns matches that are NOT in the database
            return matchIds.Where(x => dbList.All(y => y.MatchId != x)).ToArray();
        }

    }
}
