using System;

public class RiotMatch
{
    public RiotMetadata Metadata { get; set; }
    public RiotInfo Info { get; set; }
}
public class RiotInfo
{
    public long GameStartTimeStamp { get; set; }
    public long GameEndTimeStamp { get; set; }
    public string GameMode { get; set; }
    public RiotParticipant[] Participants { get; set; }
}

public class RiotMetadata
{
    public String[] Participants { get; set; }
}
public class RiotParticipant
{
    public string PUUID { get; set; }
    public string ChampionName { get; set; }
    public string IndividualPosition { get; set; }
    public bool Win { get; set; }
    public int TeamId { get; set; }
    public int TotalTimeCCDealt { get; set; }
}