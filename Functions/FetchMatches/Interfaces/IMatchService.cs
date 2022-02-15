using System;
using System.Collections.Generic;

namespace Drumstepp.FetchMatches.Interfaces
{
    public interface IMatchService
    {
        public ICollection<String> GetMatchHistory(string puuid);
    }    
}