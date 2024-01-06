namespace AdventOfCode23.Day5;

public class AlmanacMap(int source, int destination, int range)
{
    public int Source { get; set; } = source;
    public int Destination { get; set; } = destination;
    public int Range { get; set; } = range;

    /// <summary>
    ///     Calculates the destination using the provided source value.
    /// </summary>
    /// <param name="source"></param>
    /// <returns>The resulting destination, or <see langword="null" /> if the provided source was outside of the allowed range.</returns>
    public int? CalculateDestination(int source)
    {
        return (source - Source < Range) ? Destination + (source - Source) : null;
    }

    /// <summary>
    ///     Constructs a new AlmanacMap using the provided string data.
    /// </summary>
    /// <param name="data">The string data for the map (as described in the Day 5 problem).</param>
    /// <returns>A new AlmanacMap object.</returns>
    public static AlmanacMap FromString(string data)
    {
        var splitData = data.Trim().Split(" ");
        var source = int.Parse(splitData[1]);
        var destination = int.Parse(splitData[0]);
        var range = int.Parse(splitData[2]);
        return new AlmanacMap(source, destination, range);
    }
}