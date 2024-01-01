using AdventOfCode23.Day2;
using FluentAssertions;

namespace AdventOfCode23.Tests.Day2;

public class CubeGameTests
{
    [Fact]
    public void Reveal_Constructor_Parses_Input_String_Correctly()
    {
        const string input = " 1 red, 2 green, 6 blue; ";
        Reveal expected = new(1, 2, 6);
        Reveal actual = new(input);

        expected.Should().BeEquivalentTo(actual);
    }

    [Fact]
    public void CubeGame_Constructor_Parses_Input_String_Correctly()
    {
        const string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        CubeGame expected = new(1, [
            new Reveal(4, 0, 3),
            new Reveal(1, 2, 6),
            new Reveal(0, 2, 0)
        ]);
        CubeGame actual = new(input);

        expected.Should().BeEquivalentTo(actual);
    }

    [Fact]
    public void IsPossible_Returns_Correctly_For_Possible_And_Impossible_Games()
    {
        string[] input =
        [
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        ];

        var maxRed = 12;
        var maxGreen = 13;
        var maxBlue = 14;

        bool[] expected =
        [
            true,
            true,
            false,
            false,
            true
        ];

        var actual = input
            .Select(s => new CubeGame(s).IsPossible(maxRed, maxGreen, maxBlue))
            .ToArray();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void SumAllPossible_Calculates_Example_Data()
    {
        string[] data =
        [
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        ];
        CubeGame.SumAllPossible(data, 12, 13, 14).Should().Be(8);
    }

    [Fact]
    public void SumAllPossible_Calculates_Real_Data()
    {
        string[] data = File.ReadAllLines("Day2/data.txt");
        CubeGame.SumAllPossible(data, 12, 13, 14).Should().Be(2727);
    }
}