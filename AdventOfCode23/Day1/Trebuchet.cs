namespace AdventOfCode23.Day1;

public static class Trebuchet
{
    /// <summary>
    ///     Performs the calibration specified in the AoC Day 1 Part 1 problem.
    /// </summary>
    /// <param name="lines">The lines to parse through.</param>
    /// <returns>The calibration value.</returns>
    /// <remarks>
    ///     In this implementation, we're going to try a LINQ-only implementation. We'll go for better performance on the
    ///     Part 2 algorithm.
    /// </remarks>
    public static int Calibrate(IEnumerable<string> lines)
    {
        return lines.Select(val =>
        {
            if (val == string.Empty) return 0;
            
            var a = 0;
            var b = 0;

            try
            {
                a = int.Parse(
                    val.First(c => int.TryParse(c.ToString(), out _))
                        .ToString()
                );
            }
            catch
            {
                // ignored
            }

            try
            {
                b = int.Parse(
                    val.Reverse()
                        .First(c => int.TryParse(c.ToString(), out _))
                        .ToString()
                );
            }
            catch
            {
                // ignored
            }

            return a * 10 + b;
        }).Aggregate((a, b) => a + b);
    }
}