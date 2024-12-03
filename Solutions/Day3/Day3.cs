using System.Text.RegularExpressions;
using AdventOfCode.Helpers;

namespace AdventOfCode.Solutions.Day3;

public class Day3
{

    private readonly string _filePath;
    private const string REGEX_PATTERN_TASK1 = @"mul\((\d+),(\d+)\)";
    private const string REGEX_PATTERN_TASK2 = @"mul\((\d+),(\d+)\)";


    public Day3(InputFilePathHelper inputFilePathHelper)
    {
        _filePath = inputFilePathHelper.GetInputFilePath(3);
    }
    
    public int Part1()
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
    
    public int Part2()
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
    
    

    private  string ReadInput()
    {
        string fileContent = File.ReadAllText(_filePath);
        return fileContent;
    }
}