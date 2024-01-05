using System.Text.RegularExpressions;

namespace AdventOfCode23.Day3;

public static partial class Schematic
{
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
                        if (MyRegex().IsMatch(surrChars))
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
                        if (MyRegex().IsMatch(surrChars))
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
                        if (MyRegex().IsMatch(surrChars))
                        {
                            sum += int.Parse(dataArray[i].Substring(start, j - start + 1));
                        }

                        break;
                }
            }
        }

        return sum;
    }

    [GeneratedRegex(@"[^0-9\.]")]
    private static partial Regex MyRegex();
}