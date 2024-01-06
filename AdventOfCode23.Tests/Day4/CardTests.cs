using AdventOfCode23.Day4;
using FluentAssertions;

namespace AdventOfCode23.Tests.Day4;

public class CardTests
{
    [Fact]
    public void Card_Constructor_Constructs_Correct_Card()
    {
        Card card = new("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1");

        card.Id.Should().Be(3);
        card.WinningNumbers.Should().BeEquivalentTo([1, 21, 53, 59, 44]);
        card.RevealedNumbers.Should().BeEquivalentTo([69, 82, 63, 72, 16, 21, 14, 1]);
    }

    [Fact]
    public void CalculateScore_Calculates_Correct_Score()
    {
        
        var score = Card.CalculateScore("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1");
        score.Should().Be(2);
    }
}