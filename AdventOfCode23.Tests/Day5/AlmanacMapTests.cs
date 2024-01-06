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
}