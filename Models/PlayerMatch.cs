using System;
namespace Drumstepp.Models
{
    public enum SidePlayed
    {
        RED, BLUE
    }
    public enum PositionPlayed
    {
        TOP, JUNGLE, MIDDLE, BOTTOM, UTILITY, Invalid
    }

    public class PlayerMatch
    {
        public int Id { get; set; }
        public PositionPlayed PositionPlayed { get; set; }
        public SidePlayed SidePlayed { get; set; }
        public int TimeSpentCCD { get; set; }
        public bool Won { get; set; }
        public string ChampionName { get; set; }
        public Player Player { get; set; }
        public Match Match { get; set; }
    }
}