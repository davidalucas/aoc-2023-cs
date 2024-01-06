namespace AdventOfCode23.Day5;

public class Almanac(int[] seeds, AlmanacMap[][] maps)
{
    public int[] Seeds { get; set; } = seeds;
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
            .Select(s => int.Parse(s.ToString()))
            .ToArray();

        Queue<string> dataQueue = [];
        List<AlmanacMap[]> mapList = [];

        for (int i = 2; i < lines.Length; i++) // skip the first two lines
        {
            if (lines[i] == "")
            {
                mapList.Add(ConstructMaps(dataQueue));
            }
            else
            {
                dataQueue.Enqueue(lines[i]);
            }
        }
        
        mapList.Add(ConstructMaps(dataQueue)); // empty the queue at the end

        return new Almanac(seeds, mapList.ToArray());
    }

    public static AlmanacMap[] ConstructMaps(Queue<string> data)
    {
        data.Dequeue(); // remove the map's title, we don't need it
        AlmanacMap[] mapArr = new AlmanacMap[data.Count];
        for (int i = 0; i < mapArr.Length; i++)
        {
            mapArr[i] = AlmanacMap.FromString(data.Dequeue());
        }
        
        // if we wanted to sort the array, we could do it here before returning
        return mapArr;
    }
}