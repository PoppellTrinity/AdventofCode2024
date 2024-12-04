using System.ComponentModel;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days;

public class DayFour
{
    private const string DayOneFilePath = "./Days/assets/dayFourInput.txt";

    private const string xmas = "XMAS";
    private const string backwards = "SAMX";

    public int CountXmas()
    {
        int sum = 0;
        var lines = File.ReadAllLines(DayOneFilePath);

        for (int i = 0; i < lines.Length; i++)
        {
            sum += Regex.Matches(lines[i], xmas).Count;
            sum += Regex.Matches(lines[i], backwards).Count;

            if (i < lines.Length - 3)
            {
                // vertical
                for (int j = 0; j < lines[i].Length; j++)
                {
                    string vertical = lines[i].Substring(j, 1) + lines[i + 1].Substring(j, 1) +
                                      lines[i + 2].Substring(j, 1) + lines[i + 3].Substring(j, 1);
                    sum += Regex.Matches(vertical, xmas).Count;
                    sum += Regex.Matches(vertical, backwards).Count;
                }

                // Diagonal nach rechts unten
                for (int j = 0; j < lines[i].Length - 3; j++)
                {
                    string diagonal = lines[i].Substring(j, 1) + lines[i + 1].Substring(j + 1, 1) +
                                      lines[i + 2].Substring(j + 2, 1) + lines[i + 3].Substring(j + 3, 1);

                    sum += Regex.Matches(diagonal, xmas).Count;
                    sum += Regex.Matches(diagonal, backwards).Count;
                }

                // Diagonal nach links unten
                for (int j = 3; j < lines[i].Length; j++)
                {
                    string diagonal = lines[i].Substring(j, 1) + lines[i + 1].Substring(j - 1, 1) +
                                      lines[i + 2].Substring(j - 2, 1) + lines[i + 3].Substring(j - 3, 1);

                    sum += Regex.Matches(diagonal, xmas).Count;
                    sum += Regex.Matches(diagonal, backwards).Count;
                }
            }
        }

        return sum;
    }

    public int CountX_Mas()
    {
        int sum = 0;
        var lines = File.ReadAllLines(DayOneFilePath);
        for (int i = 0; i < lines.Length - 2; i++)
        {
            for (int j = 0; j < lines[i].Length - 2; j++)
            {
                string[] inputblock =
                [
                    lines[i].Substring(j, 3),
                    lines[i + 1].Substring(j, 3),
                    lines[i + 2].Substring(j, 3),
                ];
                sum += CheckForXmas(inputblock);
            }
        }

        return sum;
    }

    private int CheckForXmas(string[] lines)
    {
        if (!lines[1].Substring(1, 1).Equals("A"))
        {
            return 0;
        }
        
        if (!checkValid(lines[0].Substring(0, 1)))
        {
            return 0;
        }
        if (!checkValid(lines[0].Substring(2, 1)))
        {
            return 0;
        }
        if (!checkValid(lines[2].Substring(0, 1)))
        {
            return 0;
        }
        if (!checkValid(lines[2].Substring(2, 1)))
        {
            return 0;
        }

        // links unten
        if (!(lines[0].Substring(0, 1).Equals("M") && lines[2].Substring(2, 1).Equals("S"))
            &&
            !(lines[0].Substring(0, 1).Equals("S") && lines[2].Substring(2, 1).Equals("M")))
        {
            return 0;
        }

        //  rechts oben
        if (!(lines[2].Substring(0, 1).Equals("M") && lines[0].Substring(2, 1).Equals("S"))
           &&
            !(lines[2].Substring(0, 1).Equals("S") && lines[0].Substring(2, 1).Equals("M")))
        {
            return 0;
        }

        return 1;
    }
    
    private bool checkValid(string input)
    {
        return input.Equals("S") || input.Equals("M");
    }
}

