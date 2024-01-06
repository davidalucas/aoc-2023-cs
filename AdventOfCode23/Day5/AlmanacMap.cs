namespace AdventOfCode23.Day5;

public class AlmanacMap
{
    public int Source { get; set; }
    public int Destination { get; set; }
    public int Range { get; set; }

    public AlmanacMap(string data)
    {
        var splitData = data.Trim().Split(" ");
        Source = int.Parse(splitData[1]);
        Destination = int.Parse(splitData[0]);
        Range = int.Parse(splitData[2]);
    }
}