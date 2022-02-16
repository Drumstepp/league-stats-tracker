using System;
using System.Collections.Generic;
using Drumstepp.FetchMatches.Interfaces;
using Drumstepp.Models;
using Drumstepp.Data;
using System.Linq;

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
            return _context.Matches.Where(x => x.Id == 1).FirstOrDefault();
        }

    }
}
