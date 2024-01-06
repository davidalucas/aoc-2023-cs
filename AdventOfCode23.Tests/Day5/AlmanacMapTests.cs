using AdventOfCode23.Day5;
using FluentAssertions;

namespace AdventOfCode23.Tests.Day5;

public class AlmanacMapTests
{
    [Fact]
    public void AlmanacMapConstructor_Constructs_Correctly()
    {
        var map = new AlmanacMap("50 98 2");
        map.Source.Should().Be(98);
        map.Destination.Should().Be(50);
        map.Range.Should().Be(2);
    }
}