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
}