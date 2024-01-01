using AdventOfCode23.Day2;
using FluentAssertions;

namespace AdventOfCode23.Tests.Day2;

public class CubeGameTests
{
    [Fact]
    public void Reveal_Constructor_Parses_Input_String_Correctly()
    {
        string input = " 1 red, 2 green, 6 blue; ";
        Reveal expected = new(1, 2, 6);
        Reveal actual = new(input);

        expected.Should().BeEquivalentTo(actual);
    }

    [Fact]
    public void CubeGame_Constructor_Parses_Input_String_Correctly()
    {
        string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        CubeGame expected = new(1, [new Reveal(4, 0, 3), new Reveal(1, 2, 6), new Reveal(0, 2, 0)]);
        CubeGame actual = new(input);

        expected.Should().BeEquivalentTo(actual);
    }
}