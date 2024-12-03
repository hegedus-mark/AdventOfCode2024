using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Day3;

public class Day3
{
    
    private const string FILE_PATH = "./Solutions/Day3/input.txt";
    private const string REGEX_PATTERN_TASK1 = @"mul\((\d+),(\d+)\)";
    private const string REGEX_PATTERN_TASK2 = @"mul\((\d+),(\d+)\)";
    
    
    public static int Part1()
    {
        var result = 0;

        string fileContent = ReadInput();

        MatchCollection matches = Regex.Matches(fileContent, REGEX_PATTERN_TASK1);

        foreach (Match match in matches)
        {
            int num1 = int.Parse(match.Groups[1].Value);
            int num2 = int.Parse(match.Groups[2].Value);

            result += num1 * num2;
        }

        return result;
    }
    
    public static int Part2()
    {
        var result = 0;
        
        string fileContent = ReadInput();

        MatchCollection matches = Regex.Matches(fileContent, REGEX_PATTERN_TASK2);

        foreach (Match match in matches)
        {
            int num1 = int.Parse(match.Groups[1].Value);
            int num2 = int.Parse(match.Groups[2].Value);

            result += num1 * num2;
        }

        return result;
    }
    
    

    private static string ReadInput()
    {
        string fileContent = File.ReadAllText(FILE_PATH);
        return fileContent;
    }
}