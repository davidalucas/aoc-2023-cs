using AdventOfCode23.Day5;
using FluentAssertions;

namespace AdventOfCode23.Tests.Day5;

public class AlmanacTests
{
    [Fact]
    public void ConstructMaps_Constructs_Expected_Array_And_Empties_Queue()
    {
        Queue<string> data = [];
        data.Enqueue("soil-to-fertilizer map:");
        data.Enqueue("0 15 37");
        data.Enqueue("37 52 2");
        data.Enqueue("39 0 15");

        AlmanacMap[] expected =
        [
            new AlmanacMap(15, 0, 37),
            new AlmanacMap(52, 37, 2),
            new AlmanacMap(0, 39, 15)
        ];

        var actual = Almanac.ConstructMaps(data);
        actual.Should().BeEquivalentTo(expected);
        data.Count.Should().Be(0);
    }

    [Fact]
    public void FromFile_Constructs_Expected_Almanac()
    {
        Almanac expected = new([79, 14, 55, 13], [
            [AlmanacMap.FromString("50 98 2"), AlmanacMap.FromString("52 50 48")],
            [AlmanacMap.FromString("0 15 37"), AlmanacMap.FromString("37 52 2"), AlmanacMap.FromString("39 0 15")],
            [
                AlmanacMap.FromString("49 53 8"),
                AlmanacMap.FromString("0 11 42"),
                AlmanacMap.FromString("42 0 7"),
                AlmanacMap.FromString("57 7 4"),
            ],
            [AlmanacMap.FromString("88 18 7"), AlmanacMap.FromString("18 25 70")],
            [AlmanacMap.FromString("45 77 23"), AlmanacMap.FromString("81 45 19"), AlmanacMap.FromString("68 64 13")],
            [AlmanacMap.FromString("0 69 1"), AlmanacMap.FromString("1 0 69")],
            [AlmanacMap.FromString("60 56 37"), AlmanacMap.FromString("56 93 4")]
        ]);

        var actual = Almanac.FromFile("Day5/example.txt");
        actual.Should().BeEquivalentTo(expected);
    }
}