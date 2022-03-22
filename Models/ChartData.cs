using System;
using System.Collections;

public class ChartData
{
    public String[] Labels { get; set; }
    public ChartDataSets[] Datasets { get; set; }

}

public class ChartDataSets
{
    public String Label { get; set; }
    public int[] Data { get; set; }
    public String[] BackgroundColor { get; set; }
    public String[] BorderColor { get; set; }
    public int BorderWidth { get; set; } = 1;

}