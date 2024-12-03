using AdventOfCode.Helpers;

namespace AdventOfCode.Solutions.Day1;

public class Day1
{

    private readonly string _filePath;
    private static readonly List<int> Column1 = new();
    private static readonly List<int> Column2 = new();
    private static readonly Dictionary<int, int> Occurrences = new Dictionary<int, int>();


    public Day1(InputFilePathHelper inputFilePathHelper)
    {
        _filePath = inputFilePathHelper.GetInputFilePath(1);
    }
    public  int Part1()
    {
        ReadFromInput();
        
        Column1.Sort();
        Column2.Sort();

        var sum = 0;
        for (int i = 0; i < Column1.Count; i++)
        {
            sum += Math.Abs(Column1[i] - Column2[i]);
        }

        return sum;
    }
    
    public  int Part2()
    {
        ReadFromInput();
        CountOccurencesInRightCol();
        
        var similarityScore = 0;
        foreach (var num in Column1)
        {
            if (Occurrences.ContainsKey(num))
            {
                similarityScore += num * Occurrences[num];
            }
        }

        return similarityScore;
    }

    private  void CountOccurencesInRightCol()
    {
        foreach (var num in Column2)
        {
            if (!Occurrences.ContainsKey(num))
            {
                Occurrences[num] = 1;
            }
            else
            {
                Occurrences[num] += 1;
            }
        }
    }

    private  void ReadFromInput()
    {
        foreach (var line in File.ReadLines(_filePath))
        {
            string[] columns = line.Split("   ");

            if (columns.Length == 2)
            {
                Column1.Add(int.Parse(columns[0]));
                Column2.Add(int.Parse(columns[1]));
            }
        }
    }
}