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

    [Fact]
    public void CalculateCards_Calculates_Correct_Sum_And_List()
    {
        LinkedList<int> memory = [];
        var result = Card.CalculateCards("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", memory);

        result.Should().Be(1);
        memory.Should().BeEquivalentTo([1, 1, 1, 1]);

        result = Card.CalculateCards("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", memory);

        result.Should().Be(2);
        memory.Should().BeEquivalentTo([3, 3, 1]);
        
        result = Card.CalculateCards("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", memory);

        result.Should().Be(4);
        memory.Should().BeEquivalentTo([7, 5]);
    }
}