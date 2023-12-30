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


    private readonly Dictionary<string, int> _numberMap = new()
    {
        { "zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    [Fact]
    public void TryForwardWordParse_Parses_First_Number()
    {
        var methodReturn = Trebuchet.TryForwardWordParse("two1nine", 0, _numberMap, out var methodResult);
        methodReturn.Should().BeTrue();
        methodResult.Should().Be(2);

        methodReturn = Trebuchet.TryForwardWordParse("two1nine", 1, _numberMap, out methodResult);
        methodReturn.Should().BeFalse();
        methodResult.Should().Be(0);
    }

    [Fact]
    public void TryReverseWordParse_Parses_Last_Number()
    {
        var methodReturn = Trebuchet.TryReverseWordParse("two1nine", 7, _numberMap, out var methodResult);
        methodReturn.Should().BeTrue();
        methodResult.Should().Be(9);

        methodReturn = Trebuchet.TryReverseWordParse("two1nine", 6, _numberMap, out methodResult);
        methodReturn.Should().BeFalse();
        methodResult.Should().Be(0);
    }

    [Fact]
    public void Calibrate_Calculates_With_Word_Search_For_Example_Data()
    {
        string[] data =
        [
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",
        ];
        Trebuchet.Calibrate(data, _numberMap).Should().Be(281);
    }

    [Fact]
    public void Calibrate_Calculates_With_Word_Search_For_Real_Data()
    {
        string[] data = File.ReadAllLines("Day1/data.txt");
        Trebuchet.Calibrate(data, _numberMap).Should().Be(54431);
    }


    [Fact]
    public async Task CalibrateAsync_Calculates_With_Word_Search_For_Example_Data()
    {
        string[] data =
        [
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",
        ];
        var result = await Trebuchet.CalibrateAsync(data, _numberMap);
        result.Should().Be(281);
    }
    
    [Fact]
    public async Task CalibrateAsync_Calculates_With_Word_Search_For_Real_Data()
    {
        string[] data = await File.ReadAllLinesAsync("Day1/data.txt");
        var result = await Trebuchet.CalibrateAsync(data, _numberMap);
        result.Should().Be(54431);
    }
}