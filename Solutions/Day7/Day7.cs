using System.Text.RegularExpressions;
using AdventOfCode.Helpers;

namespace AdventOfCode.Solutions.Day7;

public class Day7
{
    private readonly string _filePath;

    public Day7(InputFilePathHelper inputFilePathHelper)
    {
        _filePath = inputFilePathHelper.GetInputFilePath(7);
    }


    public long Part1()
    {
        return SumUpGoodResults(CanProduceTargetPart1);
    }

    public long Part2()
    {
        return SumUpGoodResults(CanProduceTargetPart2);
    }


    private long SumUpGoodResults(Func<long, long, List<long>, int, bool> check)
    {
        long sum = 0;
        foreach (var line in File.ReadLines(_filePath))
        {
            var parts = Regex.Matches(line, @"\d+").Select(m => long.Parse(m.Value)).ToList();
            var target = parts.First();
            var nums = parts.Skip(1).ToList();

            if (check(target, nums[0], nums[1..], 0))
            {
                sum += target;
            }
        }

        return sum;
    }

    private bool CanProduceTargetPart1(long target, long currentResult, List<long> numbers, int index)
    {
        // Base case: If we've processed all numbers, check if the result matches the target
        if (index == numbers.Count)
        {
            return currentResult == target;
        }

        // Recursive case: Try adding and multiplying
        return CanProduceTargetPart1(target, currentResult + numbers[index], numbers, index + 1) ||
               CanProduceTargetPart1(target, currentResult * numbers[index], numbers, index + 1);
    }

    private bool CanProduceTargetPart2(long target, long currentResult, List<long> numbers, int index)
    {
        if (index == numbers.Count)
        {
            return currentResult == target;
        }
        // Recursive case: Try concat, adding and multiplying
        return CanProduceTargetPart2(target, long.Parse($"{currentResult}{numbers[index]}"), numbers, index + 1) ||
               CanProduceTargetPart2(target, currentResult + numbers[index], numbers, index + 1) ||
               CanProduceTargetPart2(target, currentResult * numbers[index], numbers, index + 1);
    }
}