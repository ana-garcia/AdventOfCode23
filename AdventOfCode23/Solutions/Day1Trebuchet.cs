using System.Text.RegularExpressions;

namespace AdventOfCode23.Solutions;
public class Day1Trebuchet
{
    public Day1Trebuchet() { }

    private Dictionary<string, int> SpelledDigitToNumericMapping = new Dictionary<string, int>
    {
        { "zero",   0 },
        { "one",    1 },
        { "two",    2 },
        { "three",  3 },
        { "four",   4 },
        { "five",   5 },
        { "six",    6 },
        { "seven",  7 },
        { "eight",  8 },
        { "nine",   9 },
        { "0",   0 },
        { "1",    1 },
        { "2",    2 },
        { "3",  3 },
        { "4",   4 },
        { "5",   5 },
        { "6",    6 },
        { "7",  7 },
        { "8",  8 },
        { "9",   9 },
        { "orez",   0 },
        { "eno",    1 },
        { "owt",    2 },
        { "eerht",  3 },
        { "ruof",   4 },
        { "evif",   5 },
        { "xis",    6 },
        { "neves",  7 },
        { "thgie",  8 },
        { "enin",   9 },
    };

    public int Part1(string filePath)
    {
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(filePath);
            int count = 0;

            var line = sr.ReadLine();
            while (line != null)
            {
                count += GetValuePart1(line);
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
            return count;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
            return -1;
        }
    }
    public int Part2(string filePath)
    {
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(filePath);
            int count = 0;

            var line = sr.ReadLine();
            while (line != null)
            {
                count += GetValuePart2(line);
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
            return count;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
            return -1;
        }
    }

    private int GetValuePart1(string line)
    {
        int a = 0, b = 0;
        var first = true;
        foreach (char c in line)
        {
            if (Char.IsDigit(c))
            {
                b = int.Parse(c.ToString());
                if (first)
                {
                    a = int.Parse(c.ToString());
                    first = false;
                }
            }
        }
        int value = a * 10 + b;
        return value;
    }

    private int GetValuePart2(string line)
    {
        string pattern = @"(?=(zero|one|two|three|four|five|six|seven|eight|nine|\d))";
        MatchCollection matches = Regex.Matches(line.ToLower(), pattern, RegexOptions.IgnoreCase);
        int a = GetIntegerValue(matches.First().Groups[1].Value);
        int b = GetIntegerValue(matches.Last().Groups[1].Value);
        int value = a * 10 + b;
        return value;
    }

    private int GetIntegerValue(string value)
    {
        if (SpelledDigitToNumericMapping.TryGetValue(value, out int digit))
        {
            return digit;
        }
        return 0;
    }
}

