using System.Text.RegularExpressions;

namespace AdventOfCode.Days;

public class DayThree
{
    private string regex = @"mul\([\d]{1,3},[\d]{1,3}\)";
    private string regexDo = @"do\(\)";
    private string regexDont = @"don\'t\(\)";

    private const string DayThreeFilePath = "./Days/assets/dayThreeInput.txt";
    public int SumMul()
    {
        int mul = 0;
        var input = File.ReadAllText(DayThreeFilePath);
        var matches =Regex.Matches(input, regex);
        foreach (Match match in matches)
        {
            var matchsanitised = match.Value.Substring(4);
          
            matchsanitised = matchsanitised.Remove(matchsanitised.Length - 1, 1);
            var numbers = matchsanitised.Split(',');
            mul += int.Parse(numbers[0]) * int.Parse(numbers[1]);
        }



        return mul;
    }


    public int SumMulEnabled()
    {
        int mul = 0;
        var input = File.ReadAllText(DayThreeFilePath);
        var matchesMul =Regex.Matches(input, regex);
        var matchesDont =Regex.Matches(input, regexDont).Select(item => item.Index).ToList();
        var matchesDo =Regex.Matches(input, regexDo).Select(item => item.Index).ToList();

        bool enabled = true;
        int lastindex = 0;
        foreach (Match match in matchesMul)
        {
            if (matchesDo.Any())
            {
                if (matchesDo[0] > lastindex && matchesDo[0] < match.Index)
                {
                    enabled = true;
                }
                
            }

            if (matchesDont.Any())
            {
                if (matchesDont[0] > lastindex && matchesDont[0] < match.Index)
                {
                    enabled = false;
                }
            }
            
            if (enabled)
            {
                var matchsanitised = match.Value.Substring(4);
                matchsanitised = matchsanitised.Remove(matchsanitised.Length - 1, 1);
                var numbers = matchsanitised.Split(',');
                mul += int.Parse(numbers[0]) * int.Parse(numbers[1]);
            }
            matchesDo = matchesDo.Where(item => item > match.Index).ToList();
            matchesDont = matchesDont.Where(item => item > match.Index).ToList();
            lastindex = match.Index;
        }



        return mul;
    }
}