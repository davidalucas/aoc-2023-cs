namespace AdventOfCode23.Day3;

public class Gear(IEnumerable<PartNumber> partNumbers)
{
    public PartNumber[] PartNumbers { get; } = partNumbers.ToArray();

    public int Ratio => PartNumbers[0].Value * PartNumbers[1].Value;
}