namespace AdventOfCode23.Day2;

public class Reveal
{
    public Reveal(int reds, int greens, int blues)
    {
        Reds = reds;
        Greens = greens;
        Blues = blues;
    }

    public Reveal(string data)
    {
        var structuredData = data.Trim()
            .Split(", ");
        foreach (var colorStr in structuredData)
            if (colorStr.Contains("red"))
                Reds = int.Parse(colorStr.Split(" ")[0]);
            else if (colorStr.Contains("green"))
                Greens = int.Parse(colorStr.Split(" ")[0]);
            else if (colorStr.Contains("blue")) Blues = int.Parse(colorStr.Split(" ")[0]);
    }

    public int Reds { get; set; }
    public int Greens { get; set; }
    public int Blues { get; set; }
}