namespace AdventOfCode23.Day2;

public class CubeGame(int gameNumber, params Reveal[] reveals)
{
    public int GameNumber { get; } = gameNumber;
    public Reveal[] Reveals { get; } = reveals;

    /// <summary>
    ///     Checks whether the game is possible with the given constraints
    /// </summary>
    /// <param name="red">The maximum number of red cubes allowed.</param>
    /// <param name="green">The maximum number of green cubes allowed.</param>
    /// <param name="blue">The maximum number of blue cubes allowed.</param>
    /// <returns><see langword="true"/> if the game is possible with the given constraints.</returns>
    public bool IsPossible(int red, int green, int blue)
    {
        foreach (var reveal in Reveals)
        {
            if (reveal.Reds > red || reveal.Greens > green || reveal.Blues > blue)
            {
                return false;
            }
        }

        return true;
    }
}