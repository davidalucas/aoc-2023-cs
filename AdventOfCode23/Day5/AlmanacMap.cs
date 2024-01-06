namespace AdventOfCode23.Day5;

public class AlmanacMap(long source, long destination, long range)
{
    public long Source { get; set; } = source;
    public long Destination { get; set; } = destination;
    public long Range { get; set; } = range;

    /// <summary>
    ///     Calculates the destination using the provided source value.
    /// </summary>
    /// <param name="source"></param>
    /// <returns>The resulting destination, or <see langword="null" /> if the provided source was outside of the allowed range.</returns>
    public long? CalculateDestination(long source)
    {
        var diff = source - Source;
        return 0 <= diff && diff < Range ? Destination + diff : null;
    }

    /// <summary>
    ///     Constructs a new AlmanacMap using the provided string data.
    /// </summary>
    /// <param name="data">The string data for the map (as described in the Day 5 problem).</param>
    /// <returns>A new AlmanacMap object.</returns>
    public static AlmanacMap FromString(string data)
    {
        var splitData = data.Trim().Split(" ");
        var source = long.Parse(splitData[1]);
        var destination = long.Parse(splitData[0]);
        var range = long.Parse(splitData[2]);
        return new AlmanacMap(source, destination, range);
    }
}