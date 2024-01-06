namespace AdventOfCode23.Day5;

public class AlmanacMap(int source, int destination, int range)
{
    public int Source { get; set; } = source;
    public int Destination { get; set; } = destination;
    public int Range { get; set; } = range;

    public static AlmanacMap FromString(string data)
    {
        var splitData = data.Trim().Split(" ");
        var source = int.Parse(splitData[1]);
        var destination = int.Parse(splitData[0]);
        var range = int.Parse(splitData[2]);
        return new AlmanacMap(source, destination, range);
    }
}