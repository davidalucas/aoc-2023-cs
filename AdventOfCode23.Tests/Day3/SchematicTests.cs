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

    [Fact]
    public void GetSearchArray_Returns_Correct_Search_Array()
    {
        int[][] expected =
        [
            [1 - 1, 3 - 1, 0], // top left
            [1 - 1, 3, 0], // top center
            [1 - 1, 3 + 1, 0], // top right
            [1, 3 - 1, 0], // middle left
            [1, 3, 1], // middle center
            [1, 3 + 1, 0], // middle right
            [1 + 1, 3 - 1, 0], // lower left
            [1 + 1, 3, 0], // lower center
            [1 + 1, 3 + 1, 0], // lower right
        ];
        var actual = Schematic.GetSearchArray(1, 10, 3, 10);
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void FindAllGears_Finds_All_Gears_In_Example_Data()
    {
        var data = File.ReadAllLines("Day3/example.txt");
        var gears = Schematic.FindAllGears(data);

        gears.Count.Should().Be(2);

        gears[0].PartNumbers[0].Value.Should().Be(467);
        gears[0].PartNumbers[1].Value.Should().Be(35);
        gears[0].Ratio.Should().Be(16345);
        gears[1].PartNumbers[0].Value.Should().Be(755);
        gears[1].PartNumbers[1].Value.Should().Be(598);
        gears[1].Ratio.Should().Be(451490);
    }

    [Fact]
    public void SumAllGearProducts_Calculates_Correct_Sum_For_Real_Data()
    {
        var data = File.ReadAllLines("Day3/data.txt");
        Schematic.SumAllGearRatios(data).Should().Be(84495585);
    }
}