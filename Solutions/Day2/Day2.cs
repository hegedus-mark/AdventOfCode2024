using AdventOfCode.Helpers;

namespace AdventOfCode.Solutions.Day2;

public class Day2
{
    private const int MIN_LIMIT = 1;
    private const int MAX_LIMIT = 3;
    private string _filePath;
    private List<int[]> _levels;
    
    public Day2(InputFilePathHelper inputFilePathHelper)
    {
        _filePath = inputFilePathHelper.GetInputFilePath(2);
        _levels = ReadFromInput();
    }
    
    public  int Part1()
    {
        var safeLevels = 0;
        foreach (var level in _levels)
        {
            var correctDifferences = CalculateCorrectDifferences(level);

            if (correctDifferences >= level.Length - 1)
            {
                safeLevels++;
            }
        }

        return safeLevels;
    }
    
    public  int Part2()
    {
        var safeLevels = 0;
        foreach (var level in _levels)
        {
            var correctDifferences = CalculateCorrectDifferences(level);

            if (correctDifferences >= level.Length - 2)
            {
                safeLevels++;
            }
        }

        return safeLevels;
    }

    private  int CalculateCorrectDifferences(int[] levels)
    {
        bool ascending = true;
        int correctDifferences = 0;
        for (int i = 1; i < levels.Length; i++)
        {
            if (i == 1)
            {
                ascending = levels[i] > levels[i - 1];
            }

            var difference = levels[i] - levels[i - 1];
            if (ascending)
            {
                if (difference is >= MIN_LIMIT and <= MAX_LIMIT)
                {
                    correctDifferences++;
                }
            }
            else
            {
                if (difference is <= - 1 * MIN_LIMIT and >= -1 * MAX_LIMIT)
                {
                    correctDifferences++;
                }
            }
        }

        return correctDifferences;
    }

    private  List<int[]> ReadFromInput()
    {
        var list = new List<int[]>();
        foreach (var line in File.ReadLines(_filePath))
        {
            string[] numbers = line.Split(" ");

            var arr = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                arr[i] = int.Parse(numbers[i]);
            }

            list.Add(arr);
        }

        return list;
    }
}