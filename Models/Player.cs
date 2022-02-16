using System;
using System.Collections;
using System.Collections.Generic;

namespace Drumstepp.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string PUUID { get; set; }
        public string Name { get; set; }

        public ICollection<PlayerMatch> PlayerMatches { get; set; }
    }
}