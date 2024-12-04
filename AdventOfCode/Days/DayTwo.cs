namespace AdventOfCode.Days;

public class DayTwo
{
    private const string DayOneFilePath = "./Days/assets/dayTwoInput.txt";

    public int CountSaveReports()
    {
        int sum = 0;

        var lines = File.ReadAllLines(DayOneFilePath);
        List<List<int>> linesAsNumber = [];
        foreach (var line in lines)
        {
            var numbersAsStrings = line.Split(" ");
            var numbers = numbersAsStrings.Select(int.Parse).ToList();
            linesAsNumber.Add(numbers);
        }

        sum = SafeFromList(linesAsNumber);
        return sum;
    }

    public int CountSaveReportsWithDampener()
    {
        int sum = 0;
        int maxStep = 3;
        var lines = File.ReadAllLines(DayOneFilePath);
        List<List<int>> linesAsNumber = [];
        foreach (var line in lines)
        {
            var numbersAsStrings = line.Split(" ");
            var numbers = numbersAsStrings.Select(int.Parse).ToList();
            linesAsNumber.Add(numbers);
        }

        foreach (var numbers in linesAsNumber)
        {
            if (SafeFromList([numbers]) > 0)
            {
                sum++;
                continue;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                List<int> numberwithoutNumber = [];
                numberwithoutNumber.AddRange(numbers);
                numberwithoutNumber.RemoveAt(i);
                var isSafe = SafeFromList( [numberwithoutNumber.ToList()]);
                if (isSafe > 0)
                {
                    sum++;
                    break;
                }
            }
        }
        
        return sum;
    }

    private bool? Ascending(List<int> numbers)
    {
        if (numbers.First() == numbers.Min())
        {
            return true;
        }
        else if (numbers.First() == numbers.Max())
        {
            return false;
        }

        return null;
    }

    private int SafeFromList(List<List<int>> numbers)
    {
        int sum = 0;
        int maxStep = 3;
        foreach (var line in numbers)
        {
            bool? shouldGoUp = Ascending(line);
            if (shouldGoUp is null)
            {
                continue;
            }
            int lastvalue = -1;
            bool safe = false;
            foreach (var number in line)
            {
                if (lastvalue == -1)
                {
                    lastvalue = number;
                    continue;
                }

                if (shouldGoUp.Value)
                {
                    if (lastvalue >= number)
                    {
                        safe = false;
                        break;
                    }

                    var maxallowed = lastvalue + maxStep;
                    if (maxallowed < number)
                    {
                        safe = false;
                        break;
                    }
                }
                else
                {
                    if (lastvalue <= number)
                    {
                        safe = false;
                        break;
                    }

                    var minallowed = lastvalue - maxStep;

                    if (minallowed > number)
                    {
                        safe = false;
                        break;
                    }
                }

                lastvalue = number;
                safe = true;
            }

            if (safe)
            {
                sum++;
            }
        }

        return sum;
    }
}