namespace AdventOfCode23.Day4;

public class Card
{
    public Card(string line)
    {
        var splitCardNumber = line.Split(": ");
        Id = int.Parse(splitCardNumber[0].Split(" ").Where(s => s != "").ElementAt(1));

        var splitWinningRevealed = splitCardNumber[1].Split(" | ");

        WinningNumbers =
        [
            ..splitWinningRevealed[0]
                .Split(" ")
                .Where(s => s != "")
                .Select(int.Parse)
        ];
        RevealedNumbers =
        [
            ..splitWinningRevealed[1]
                .Split(" ")
                .Where(s => s != "")
                .Select(int.Parse)
        ];
    }

    public int Id { get; }
    public HashSet<int> WinningNumbers { get; }
    public HashSet<int> RevealedNumbers { get; }

    public int Matches
    {
        get { return WinningNumbers.Count(winner => RevealedNumbers.Contains(winner)); }
    }

    public static int CalculateScore(string line)
    {
        var card = new Card(line);
        return (int)Math.Pow(2, card.Matches - 1);
    }

    /// <summary>
    ///     This is the key algorithm for solving the Day 4 Part 2 problem. It accepts a string value for the line which needs
    ///     to be parsed, and a LinkedList that represents the number of cards which have been found previously and have not
    ///     yet been counted.
    /// </summary>
    /// <param name="line">The raw string data to process (a line of the raw data file).</param>
    /// <param name="memory">A list which is keeping track of the cards which are being accumulated as we traverse.</param>
    /// <returns>The cumulative total of cards for this line.</returns>
    public static int CalculateCards(string line, LinkedList<int> memory)
    {
        var card = new Card(line);
        // if you found 4 matches, memory needs to be at least 5
        while (card.Matches > memory.Count - 1) memory.AddLast(0);

        var node = memory.First!.Next;
        for (var i = 1; i < card.Matches + 1; i++)
        {
            node!.Value += memory.First!.Value + 1;
            node = node.Next;
        }

        var result = memory.First!.Value; // we've made sure there's always at least one node here
        memory.RemoveFirst();

        return result + 1; // add 1, for the current card
    }
}