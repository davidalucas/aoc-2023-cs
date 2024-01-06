namespace AdventOfCode23.Day4;

public static class CardCollection
{
    /// <summary>
    ///     Calculates the total score (as described in Day 4 Problem 1) of a dataset of Cards contained in a text file at the
    ///     specified path.
    /// </summary>
    /// <param name="path"></param>
    /// <returns>The total score.</returns>
    public static int CalculateTotalScore(string path)
    {
        return File.ReadAllLines(path).Sum(Card.CalculateScore);
    }

    /// <summary>
    ///     Calculates the total number of cards (as described in Day 4 Problem 2).
    /// </summary>
    /// <param name="path">Path to the text file containing the dataset.</param>
    /// <returns>The total number of cards.</returns>
    public static int CalculateTotalCards(string path)
    {
        LinkedList<int> memory = [];
        return File.ReadAllLines(path).Sum(s => Card.CalculateCards(s, memory));
    }
}