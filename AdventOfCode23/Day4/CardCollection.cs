namespace AdventOfCode23.Day4;

public static class CardCollection
{
    /// <summary>
    ///     Calculates the total score (as described in Day 4 Problem 1) of a dataset of Cards contained in a text file at the specified path.
    /// </summary>
    /// <param name="path"></param>
    /// <returns>The total score.</returns>
    public static int CalculateTotalScore(string path)
    {
        return File.ReadAllLines(path).Sum(Card.CalculateScore);
    }
}