namespace AdventOfCode23.Day3;

public class PartNumber : IEquatable<PartNumber>
{
    public int Value { get; set; }
    public int LineFound { get; set; }
    public int LinePositionStart { get; set; }
    public int LinePositionEnd { get; set; }

    public PartNumber(string[] rawData, int lineFound, int linePositionStart, int linePositionEnd)
    {
        LineFound = lineFound;
        LinePositionStart = linePositionStart;
        LinePositionEnd = linePositionEnd;
        Value = int.Parse(rawData[lineFound].Substring(linePositionStart, linePositionEnd - linePositionStart + 1));
    }

    public bool Equals(PartNumber? other)
    {
        if (other is null)
        {
            return false;
        }

        return other.Value == Value && other.LineFound == LineFound && other.LinePositionStart == LinePositionStart &&
               other.LinePositionEnd == LinePositionEnd;
    }
}