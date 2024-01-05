using AdventOfCode23.Day3;
using FluentAssertions;

namespace AdventOfCode23.Tests.Day3;

public class SchematicTests
{
    [Fact]
    public void SumAllPartNumbers_Returns_Correct_Sum_From_Example()
    {
        var data = File.ReadAllLines("Day3/example.txt");
        Schematic.SumAllPartNumbers(data).Should().Be(4361);
    }

    [Fact]
    public void SumAllPartNumbers_Returns_Correct_Sum_From_Actual_Data()
    {
        var data = File.ReadAllLines("Day3/data.txt");
        Schematic.SumAllPartNumbers(data).Should().Be(544664);
    }
}