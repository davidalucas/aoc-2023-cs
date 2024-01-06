using AdventOfCode23.Day4;
using FluentAssertions;

namespace AdventOfCode23.Tests.Day4;

public class CardCollectionTests
{
    [Fact]
    public void CalculateTotalScore_Gets_Correct_Score_For_Example_Data()
    {
        CardCollection.CalculateTotalScore("Day4/example.txt").Should().Be(13);
    }
    
    [Fact]
    public void CalculateTotalScore_Gets_Correct_Score_For_Real_Data()
    {
        CardCollection.CalculateTotalScore("Day4/data.txt").Should().Be(23235);
    }

    [Fact]
    public void CalculateTotalCards_Gets_Correct_Score_For_Example_Data()
    {
        CardCollection.CalculateTotalCards("Day4/example.txt").Should().Be(30);
    }
    
    [Fact]
    public void CalculateTotalCards_Gets_Correct_Score_For_Real_Data()
    {
        CardCollection.CalculateTotalCards("Day4/data.txt").Should().Be(5920640);
    }
}