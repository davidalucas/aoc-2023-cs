namespace AdventOfCode23.Day2;

public class CubeGame
{
    public CubeGame(int gameNumber, params Reveal[] reveals)
    {
        GameNumber = gameNumber;
        Reveals = reveals;
    }

    public CubeGame(string data)
    {
        var gameTitle = data.Split(":")[0];
        GameNumber = int.Parse(gameTitle.Split(" ")[1]);

        Reveals = data.Split(":")[1]
            .Trim()
            .Split("; ")
            .Select(s => new Reveal(s))
            .ToArray();
    }

    public int GameNumber { get; set; }
    public Reveal[] Reveals { get; set; }

    public int Power
    {
        get
        {
            int reqReds = 0;
            int reqGreens = 0;
            int reqBlues = 0;
            foreach (var r in Reveals)
            {
                if (r.Reds > reqReds) {
                    reqReds = r.Reds;
                }
                if (r.Greens > reqGreens) {
                    reqGreens = r.Greens;
                }
                if (r.Blues > reqBlues) {
                    reqBlues = r.Blues;
                }
            }
            return reqReds * reqGreens * reqBlues;
        }
    }

    /// <summary>
    ///     Checks whether the game is possible with the given constraints
    /// </summary>
    /// <param name="red">The maximum number of red cubes allowed.</param>
    /// <param name="green">The maximum number of green cubes allowed.</param>
    /// <param name="blue">The maximum number of blue cubes allowed.</param>
    /// <returns><see langword="true" /> if the game is possible with the given constraints.</returns>
    public bool IsPossible(int red, int green, int blue)
    {
        foreach (var reveal in Reveals)
            if (reveal.Reds > red || reveal.Greens > green || reveal.Blues > blue)
                return false;

        return true;
    }

    /// <summary>
    ///     Performs the algorithm for AoC Day 2 Part 1
    /// </summary>
    /// <param name="data">The provided raw string data.</param>
    /// <param name="maxRed">Maximum number of allowed red cubes.</param>
    /// <param name="maxGreen">Maximum number of allowed green cubes.</param>
    /// <param name="maxBlue">Maximum number of allowed blue cubes.</param>
    /// <returns>The sum of the IDs of all possible Cube Games.</returns>
    public static int SumAllPossible(IEnumerable<string> data, int maxRed, int maxGreen, int maxBlue)
    {
        return data.Select(s => new CubeGame(s))
            .Select(cg => cg.IsPossible(maxRed, maxGreen, maxBlue) ? cg.GameNumber : 0)
            .Aggregate((a, b) => a + b);
    }
}