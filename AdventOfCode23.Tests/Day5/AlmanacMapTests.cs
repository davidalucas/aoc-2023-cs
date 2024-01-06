using AdventOfCode23.Day5;
using FluentAssertions;

namespace AdventOfCode23.Tests.Day5;

public class AlmanacMapTests
{
    [Fact]
    public void FromString_Constructs_Correct_AlmanacMap()
    {
        var expected = new AlmanacMap(98, 50, 2);
        var actual = AlmanacMap.FromString("50 98 2");
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void CalculateDestination_Returns_Correct_Value_For_Valid_Source()
    {
        AlmanacMap map = new(50, 52, 48);
        var expected = 72;
        var actual = map.CalculateDestination(70);
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void CalculateDestination_Returns_Null_For_Invalid_Source()
    {
        AlmanacMap map = new(50, 52, 48);
        var actual = map.CalculateDestination(1170);
        actual.Should().BeNull();
    }
}