using System.Text.RegularExpressions;

namespace AdventOfCode23.Day3;

public static partial class Schematic
{
    /// <summary>
    /// Regex used for determining if a character is a so-called "symbol"
    /// </summary>
    /// <returns></returns>
    [GeneratedRegex(@"[^0-9\.]")]
    private static partial Regex IsSymbolRegex();

    /// <summary>
    ///     Day 3 Part 1 algorithm
    /// </summary>
    /// <param name="data"></param>
    /// <returns>The sum of all of the valid part numbers in the schematic</returns>
    public static int SumAllPartNumbers(IEnumerable<string> data)
    {
        int sum = 0;
        var dataArray = data.ToArray();
        for (var i = 0; i < dataArray.Length; i++)
        {
            for (int j = 0; j < dataArray[i].Length; j++)
            {
                int start = j;
                while (j < dataArray[i].Length && int.TryParse(dataArray[i][j].ToString(), out _))
                {
                    j++;
                }

                if (start == j)
                {
                    continue;
                }

                j--;

                int searchStart = start > 0 ? start - 1 : start;
                int searchEnd = j < dataArray[i].Length - 1 ? j + 1 : j;
                string surrChars;
                switch (i)
                {
                    case > 0 when i + 1 < dataArray.Length:
                        surrChars = string.Concat(
                            dataArray[i - 1].Substring(searchStart, searchEnd - searchStart + 1),
                            searchStart == start ? "" : dataArray[i][start - 1].ToString(),
                            searchEnd == j ? "" : dataArray[i][j + 1].ToString(),
                            dataArray[i + 1].Substring(searchStart, searchEnd - searchStart + 1)
                        );
                        if (IsSymbolRegex().IsMatch(surrChars))
                        {
                            sum += int.Parse(dataArray[i].Substring(start, j - start + 1));
                        }

                        break;
                    case 0:
                        surrChars = string.Concat(
                            searchStart == start ? "" : dataArray[i][start - 1].ToString(),
                            searchEnd == j ? "" : dataArray[i][j + 1].ToString(),
                            dataArray[i + 1].Substring(searchStart, searchEnd - searchStart + 1)
                        );
                        if (IsSymbolRegex().IsMatch(surrChars))
                        {
                            sum += int.Parse(dataArray[i].Substring(start, j - start + 1));
                        }

                        break;
                    default:
                        surrChars = string.Concat(
                            dataArray[i - 1].Substring(searchStart, searchEnd - searchStart + 1),
                            searchStart == start ? "" : dataArray[i][start - 1].ToString(),
                            searchEnd == j ? "" : dataArray[i][j + 1].ToString()
                        );
                        if (IsSymbolRegex().IsMatch(surrChars))
                        {
                            sum += int.Parse(dataArray[i].Substring(start, j - start + 1));
                        }

                        break;
                }
            }
        }

        return sum;
    }

    /// <summary>
    ///     Day 3 Part 2 algorithm
    /// </summary>
    /// <param name="data"></param>
    /// <returns>A list of all of the Gears found in the provided data</returns>
    public static List<Gear> FindAllGears(IEnumerable<string> data)
    {
        List<Gear> gears = [];

        var dataArr = data.ToArray();
        for (int i = 0; i < dataArr.Length; i++)
        {
            var line = dataArr[i];

            for (int j = 0; j < line.Length; j++)
            {
                var ch = line[j];
                if (ch.ToString() != "*")
                {
                    continue;
                }

                // get search array
                int[][] searchArray = GetSearchArray(i, dataArr.Length, j, line.Length);
                // walk the search array, and produce a list of parts
                List<PartNumber> parts = [];
                foreach (var searchParams in searchArray)
                {
                    if (searchParams[2] == 1)
                    {
                        continue;
                    }

                    int searchLine = searchParams[0];
                    int searchChar = searchParams[1];
                    bool isInt = int.TryParse(dataArr[searchLine][searchChar].ToString(), out _);
                    if (isInt)
                    {
                        int startCursor = searchChar;
                        int endCursor = searchChar;
                        // move startCursor left until finished
                        while (startCursor != 0)
                        {
                            if (!int.TryParse(dataArr[searchLine][startCursor - 1].ToString(), out _))
                            {
                                break;
                            }

                            startCursor--;
                        }

                        // move endCursor right until finished
                        while (endCursor < line.Length)
                        {
                            if (endCursor == line.Length - 1)
                            {
                                break;
                            }
                            if (!int.TryParse(dataArr[searchLine][endCursor + 1].ToString(), out _))
                            {
                                break;
                            }

                            endCursor++;
                        }

                        // make new part
                        var part = new PartNumber(dataArr, searchLine, startCursor, endCursor);

                        // don't add duplicates
                        if (parts.Count == 0)
                        {
                            parts.Add(part);
                        } else if (!part.Equals(parts.Last()))
                        {
                            parts.Add(part);
                        }
                    }
                }

                // if the length of the parts list is 2, create a gear and add it to the list
                if (parts.Count == 2)
                {
                    gears.Add(new Gear(parts));
                }
            }
        }

        return gears;
    }

    /// <summary>
    ///     Gets the search array used to walk around the periphery of an asterisk symbol
    /// </summary>
    /// <param name="currLinePos">The line the asterisk is on</param>
    /// <param name="totalLines">The total number of lines in the dataset</param>
    /// <param name="currCharPos">The position of where the asterisk is on the line in the schematic</param>
    /// <param name="lineLength">The length of the line in the schematic</param>
    /// <returns>A 2-D array which can be used to walk around the periphery of an asterisk</returns>
    public static int[][] GetSearchArray(int currLinePos, int totalLines, int currCharPos, int lineLength)
    {
        // note: the third int on each row is actually a true/false indicator of whether the row
        // needs to be analyzed
        int[][] searchArray =
        [
            [currLinePos - 1, currCharPos - 1, 0], // top left
            [currLinePos - 1, currCharPos, 0], // top center
            [currLinePos - 1, currCharPos + 1, 0], // top right
            [currLinePos, currCharPos - 1, 0], // middle left
            [currLinePos, currCharPos, 1], // middle center
            [currLinePos, currCharPos + 1, 0], // middle right
            [currLinePos + 1, currCharPos - 1, 0], // lower left
            [currLinePos + 1, currCharPos, 0], // lower center
            [currLinePos + 1, currCharPos + 1, 0], // lower right
        ];
        foreach (var row in searchArray)
        {
            if (row[0] < 0 || row[1] < 0)
            {
                row[2] = 1;
            }
            else if (row[0] == totalLines || row[1] == lineLength)
            {
                row[2] = 1;
            }
        }

        return searchArray;
    }

    public static int SumAllGearRatios(IEnumerable<string> data)
    {
        return FindAllGears(data.ToArray()).Sum(gear => gear.Ratio);
    }
}