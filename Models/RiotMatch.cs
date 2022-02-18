public class RiotMatch
{
    public Info Info { get; set; }
}
public class Info
{
    public long GameStartTimeStamp { get; set; }
    public long GameEndTimeStamp { get; set; }
    public string GameMode { get; set; }
}