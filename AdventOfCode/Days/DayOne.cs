namespace AdventOfCode.Days;

public class DayOne
{
     private const string DayOneFilePath = "./Days/assets/dayOneInput.txt";

     public int GetDifferenceSum()
     {
          int sum = 0;
          var lines = File.ReadAllLines(DayOneFilePath);
          var firstList = new int[lines.Length];
          var secondList = new int[lines.Length];

          for (var i = 0; i < lines.Length; i++)
          {
               var line = lines[i];
               var numbers = line.Split("   ");
               firstList[i] = int.Parse(numbers[0].Trim());
               secondList[i] = int.Parse(numbers[1].Trim());
          }
          var firstListSorted = firstList.OrderBy(x => x).ToArray();
          var secondListSorted = secondList.OrderBy(x => x).ToArray();
          for (var i = 0; i < lines.Length; i++)
          {
               sum += Math.Abs( secondListSorted[i] - firstListSorted[i]);
               
          }
          
          return sum;
     }

     public int GetSimilarityScore()
     {
          int sum = 0;
          var lines = File.ReadAllLines(DayOneFilePath);
          var firstList = new int[lines.Length];
          var secondList = new int[lines.Length];
          for (var i = 0; i < lines.Length; i++)
          {
               var line = lines[i];
               var numbers = line.Split("   ");
               firstList[i] = int.Parse(numbers[0].Trim());
               secondList[i] = int.Parse(numbers[1].Trim());
          }
          
          for (int i = 1; i < firstList.Length; i++)
          {
              sum += secondList.Count(item => item == firstList[i]) * firstList[i];
               
          }
          
          return sum;
     }
}