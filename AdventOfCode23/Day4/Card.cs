namespace AdventOfCode23.Day4;

public class Card
{
    public int Id { get; set; }
    public HashSet<int> WinningNumbers { get; set; }
    public HashSet<int> RevealedNumbers { get; set; }

    public Card(string line)
    {
        var splitCardNumber = line.Split(": ");
        Id = int.Parse(splitCardNumber[0].Split(" ")[1]);

        var splitWinningRevealed = splitCardNumber[1].Split(" | ");

        WinningNumbers =
        [
            ..splitWinningRevealed[0]
                .Split(" ")
                .Where(s => s != "")
                .Select(int.Parse)
        ];
        RevealedNumbers = [
            ..splitWinningRevealed[1]
                .Split(" ")
                .Where(s => s != "")
                .Select(int.Parse)
        ];
    }

    public static int CalculateScore(string line)
    {
        var card = new Card(line);
        return card.WinningNumbers.Count(winner => card.RevealedNumbers.Contains(winner));
    }
}