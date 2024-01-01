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

    /// <summary>
    ///     Performs the enhanced calibration from the AoC Day 1 Part 2 problem.
    /// </summary>
    /// <param name="lines">The data to parse in order to calculate the calibration factor.</param>
    /// <param name="numMap">The number map to use for parsing out numbers represented as words (i.e. "one" for 1).</param>
    /// <returns>The calculated calibration factor.</returns>
    public static int Calibrate(IEnumerable<string> lines, Dictionary<string, int> numMap)
    {
        var lineArr = lines.ToArray();
        var coordinates = new int[lineArr.Length];

        var a = 0;
        var b = 0;

        for (var i = 0; i < lineArr.Length; i++)
        {
            for (var j = 0; j < lineArr[i].Length; j++)
            {
                if (int.TryParse(lineArr[i][j].ToString(), out a)) break;
                if (TryForwardWordParse(lineArr[i], j, numMap, out a)) break;
            }

            for (var j = lineArr[i].Length - 1; j >= 0; j--)
            {
                if (int.TryParse(lineArr[i][j].ToString(), out b)) break;
                if (TryReverseWordParse(lineArr[i], j, numMap, out b)) break;
            }

            coordinates[i] = a * 10 + b;
            a = b = 0;
        }

        return coordinates.Aggregate((i, j) => i + j);
    }

    /// <summary>
    ///     Performs the (forward) word number parsing for the Day 1 Part 2 algorithm. This implementation tries to emulate the
    ///     .NET int.TryParse method to make the implementation in Calibrate look a little more cohesive.
    /// </summary>
    /// <param name="line"></param>
    /// <param name="currIdx"></param>
    /// <param name="numMap"></param>
    /// <param name="result"></param>
    /// <returns>A bool value indicating whether a result has been found</returns>
    public static bool TryForwardWordParse(string line, int currIdx, Dictionary<string, int> numMap, out int result)
    {
        // loop over each item in the numMap
        foreach (var kvPair in numMap)
        {
            if (currIdx < 0 || currIdx + kvPair.Key.Length > line.Length) continue;
            var subStr = line.Substring(currIdx, kvPair.Key.Length);
            if (subStr != kvPair.Key) continue;
            result = kvPair.Value;
            return true;
        }

        result = 0;
        return false;
    }

    /// <summary>
    ///     Performs the (reverse) word number parsing for the Day 1 Part 2 algorithm. This implementation tries to emulate the
    ///     .NET int.TryParse method to make the implementation in Calibrate look a little more cohesive.
    /// </summary>
    /// <param name="line"></param>
    /// <param name="currIdx"></param>
    /// <param name="numMap"></param>
    /// <param name="result"></param>
    /// <returns>A bool value indicating whether a result has been found</returns>
    public static bool TryReverseWordParse(string line, int currIdx, Dictionary<string, int> numMap, out int result)
    {
        // loop over each item in the numMap
        foreach (var kvPair in numMap)
        {
            var startIdx = currIdx - kvPair.Key.Length + 1;
            if (startIdx < 0 || startIdx + kvPair.Key.Length > line.Length) continue;
            var subStr = line.Substring(startIdx, kvPair.Key.Length);
            if (subStr != kvPair.Key) continue;
            result = kvPair.Value;
            return true;
        }

        result = 0;
        return false;
    }

    /// <summary>
    ///     Performs the enhanced calibration from the AoC Day 1 Part 2 problem.
    /// </summary>
    /// <param name="lines">The data to parse in order to calculate the calibration factor.</param>
    /// <param name="numMap">The number map to use for parsing out numbers represented as words (i.e. "one" for 1).</param>
    /// <returns>The calculated calibration factor.</returns>
    public static async Task<int> CalibrateAsync(IEnumerable<string> lines, Dictionary<string, int> numMap)
    {
        var lineArr = lines.ToArray();
        var coordinates = new int[lineArr.Length];

        var taskList = new Task[lineArr.Length];

        for (var i = 0; i < lineArr.Length; i++)
        {
            var idx = i;

            taskList[i] = Task.Run(() =>
            {
                var a = 0;
                var b = 0;

                for (var j = 0; j < lineArr[idx].Length; j++)
                {
                    if (int.TryParse(lineArr[idx][j].ToString(), out a)) break;
                    if (TryForwardWordParse(lineArr[idx], j, numMap, out a)) break;
                }

                for (var j = lineArr[idx].Length - 1; j >= 0; j--)
                {
                    if (int.TryParse(lineArr[idx][j].ToString(), out b)) break;
                    if (TryReverseWordParse(lineArr[idx], j, numMap, out b)) break;
                }

                coordinates[idx] = a * 10 + b;
            });
        }

        await Task.WhenAll(taskList);

        return coordinates.Aggregate((i, j) => i + j);
    }
}