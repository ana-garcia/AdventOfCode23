namespace AdventOfCode23.Solutions;

public class Day2
{
    private int _maxRed;
    private int _maxGreen;
    private int _maxBlue;

    public Day2(int maxRed, int maxGreen, int maxBlue)
    {
        _maxRed = maxRed;
        _maxGreen = maxGreen;
        _maxBlue = maxBlue;
    }

    public int GetSolution(string filePath, bool isPartOne)
    {
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(filePath);

            var line = sr.ReadLine();
            int count = 0;
            if (isPartOne)
            {
                int index = 1;
                while (line != null)
                {
                    string gameLine = line.Split(": ")[1];
                    if (PossibleGame(gameLine))
                    {
                        count += index;
                    }
                    line = sr.ReadLine();
                    index++;
                }
            }
            else
            {
                while (line != null)
                {
                    string gameLine = line.Split(": ")[1];
                    (int red, int green, int blue) = GetPossibleGame(gameLine);
                    count += (red * green * blue);
                    line = sr.ReadLine();
                }
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

    private bool PossibleGame(string gameLine)
    {
        string[] gameSets = gameLine.Split("; ");
        foreach (string set in gameSets)
        {
            string[] colorsInfo = set.Split(", ");
            foreach (var colorInfo in colorsInfo)
            {
                var numAndColor = colorInfo.Split(" ");
                var amount = Int32.Parse(numAndColor[0]);
                var color = numAndColor[1].Trim().ToLower();
                if (!IsPossible(amount, color))
                {
                    return false;
                }
            }
        }
        return true;
    }

    private bool IsPossible(int amount, string color)
    {
        switch (color)
        {
            case "red":
                return _maxRed >= amount;
            case "green":
                // code block
                return _maxGreen >= amount;
            case "blue":
                // code block
                return _maxBlue >= amount;
        }
        return true;
    }

    private (int, int, int) GetPossibleGame(string gameLine)
    {
        int red = 0, green = 0, blue = 0;

        string[] gameSets = gameLine.Split("; ");
        foreach (string set in gameSets)
        {
            (int newRed, int newGreen, int newBlue) = GetMaxValue(set);
            if (red < newRed) red = newRed;
            if (green < newGreen) green = newGreen;
            if (blue < newBlue) blue = newBlue;
        }

        return (red, green, blue);
    }

    private (int, int, int) GetMaxValue(string set)
    {
        int red = 0, green = 0, blue = 0;

        string[] colorsInfo = set.Split(", ");
        foreach (var colorInfo in colorsInfo)
        {
            var numAndColor = colorInfo.Split(" ");
            switch (numAndColor[1].Trim().ToLower())
            {
                case "red":
                    red = Int32.Parse(numAndColor[0]);
                    break;
                case "green":
                    green = Int32.Parse(numAndColor[0]);
                    break;
                case "blue":
                    blue = Int32.Parse(numAndColor[0]);
                    break;
            }
        }
        return (red, green, blue);
    }
}
