using System.Collections.Immutable;

namespace AdventOfCode23.Day5;

public class Almanac(long[] seeds, AlmanacMap[][] maps)
{
    public long[] Seeds { get; set; } = seeds;
    public AlmanacMap[][] Maps { get; set; } = maps;

    /// <summary>
    ///     Constructs a new Almanac object from a text file at the specified path location.
    /// </summary>
    /// <param name="path">The path to the text file containing the Almanac data.</param>
    /// <returns>A new Almanac object.</returns>
    public static Almanac FromFile(string path)
    {
        var lines = File.ReadAllLines(path);
        var seeds = lines[0]
            .Split(": ")[1]
            .Split(" ")
            .Select(s => long.Parse(s.ToString()))
            .ToArray();

        Queue<string> dataQueue = [];
        List<AlmanacMap[]> mapList = [];

        for (var i = 2; i < lines.Length; i++) // skip the first two lines
            if (lines[i] == "")
                mapList.Add(ConstructMaps(dataQueue));
            else
                dataQueue.Enqueue(lines[i]);

        mapList.Add(ConstructMaps(dataQueue)); // empty the queue at the end

        return new Almanac(seeds, mapList.ToArray());
    }

    public static AlmanacMap[] ConstructMaps(Queue<string> data)
    {
        data.Dequeue(); // remove the map's title, we don't need it
        var mapArr = new AlmanacMap[data.Count];
        for (var i = 0; i < mapArr.Length; i++) mapArr[i] = AlmanacMap.FromString(data.Dequeue());

        Array.Sort(mapArr, (a, b) => a.Source.CompareTo(b.Source));
        return mapArr;
    }

    public long FindMinimumLocation()
    {
        long minLocation = 0;
        bool firstPass = true;
        foreach (var seed in seeds)
        {
            var source = seed;
            foreach (var mapSet in Maps)
            foreach (var map in mapSet)
            {
                var destination = map.CalculateDestination(source);
                if (destination is not null)
                {
                    source = destination.Value; // set the next source to the current destination
                    break;
                }
            }

            if (!firstPass)
            {
                minLocation = minLocation < source ? minLocation : source;
                continue;
            }

            minLocation = source;
            firstPass = false;
        }

        return minLocation;
    }

    /// <summary>
    ///     This method is the key to Part 2. You give it both a source and a range, and it gives you back a
    ///     AlmanacMap object which contains your destination and a new range. You can use that new range to jump
    ///     forward on the next iteration of seed evaluation.
    /// </summary>
    /// <param name="mapCollection">The index of the map collection you're on.</param>
    /// <param name="source">The source value.</param>
    /// <param name="range">The current range.</param>
    /// <returns>An AlmanacMap object containing the destination value, as well as the new adjusted range.</returns>
    /// <remarks>This only works if the AlmanacMaps are sorted by their Source values.</remarks>
    public static AlmanacMap CalculateDestinationMap(AlmanacMap[] mapCollection, long source, long range)
    {
        foreach (var map in mapCollection)
        {
            if (map.Source > source) // our source is between the last map and this map
                return new AlmanacMap(source, source, map.Source - source);

            var destination = map.CalculateDestination(source);
            if (destination is null) continue;
            // if we get here, we've found a valid map
            if (range > map.Range - (source - map.Source)) range = map.Range - (source - map.Source);

            return new AlmanacMap(source, destination.Value, range);
        }

        return new AlmanacMap(source, source, range); // our source exceeds all of the map ranges
    }

    /// <summary>
    ///     This method calculates the solution for the Part 2 problem.
    /// </summary>
    /// <returns>The solution value.</returns>
    public long FindRangedMinLocation()
    {
        long? minLocation = null;
        for (int i = 0; i < Seeds.Length; i += 2)
        {
            var seed = Seeds[i];
            var seedRange = Seeds[i + 1];
            while (seed < Seeds[i] + seedRange)
            {
                var source = seed;
                var range = seedRange - (Seeds[i] - seed);
                foreach (var mapCollection in Maps)
                {
                    var result = CalculateDestinationMap(mapCollection, source, range);
                    source = result.Destination;
                    range = result.Range;
                }

                if (minLocation is null)
                    minLocation = source;
                else if (source < minLocation)
                    minLocation = source;

                seed += range;
            }
        }

        return minLocation ?? throw new Exception("Failed to find any min location!");
    }
}