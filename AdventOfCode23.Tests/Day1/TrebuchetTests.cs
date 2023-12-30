using AdventOfCode23.Day1;
using FluentAssertions;

namespace AdventOfCode23.Tests.Day1;

public class TrebuchetTests
{
    [Fact]
    public void Calibrate_Calculates_Example_Data()
    {
        string[] data = ["1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"];
        Trebuchet.Calibrate(data).Should().Be(142);
    }

    [Fact]
    public void Calibrate_Calculates_Real_Data()
    {
        string[] data = File.ReadAllLines("Day1/data.txt");
        Trebuchet.Calibrate(data).Should().Be(55477);
    }
}