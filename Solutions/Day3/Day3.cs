using System.Text.RegularExpressions;
using AdventOfCode.Helpers;

namespace AdventOfCode.Solutions.Day3;

public class Day3
{

    private readonly string _filePath;
    private const string REGEX_MUL_PATTERN = @"mul\((\d+),(\d+)\)";
    private const string REGEX_DODONT_BLOCK_PATTERN = @"do(?!n't)(.*?)(?=don't|$)";
    private const string REGEX_START_TO_DONT_BLOCK_PATTERN = @"^(.*?)don't";

    public Day3(InputFilePathHelper inputFilePathHelper)
    {
        _filePath = inputFilePathHelper.GetInputFilePath(3);
    }
    
    public int Part1()
    {

        string fileContent = ReadInput();

        return FindAndMultiplyMulInBlock(fileContent);
    }
    
    public int Part2()
    {
        int result = 0;
        
        string fileContent = ReadInput();

        
        var firstBlockRegex = new Regex(REGEX_START_TO_DONT_BLOCK_PATTERN, RegexOptions.Singleline);
        var firstBlock = firstBlockRegex.Match(fileContent);
        
        
        result += FindAndMultiplyMulInBlock(firstBlock.Value);

        var remainingString = fileContent.Substring(firstBlock.Length);
        
        MatchCollection doDontBlocks = Regex.Matches(remainingString, REGEX_DODONT_BLOCK_PATTERN, RegexOptions.Singleline);

        foreach (Match doDontBlock in doDontBlocks)
        {
            result += FindAndMultiplyMulInBlock(doDontBlock.Value);
        }
        

        return result;
    }

    private int FindAndMultiplyMulInBlock(string block)
    {
        var result = 0;
        MatchCollection matches = Regex.Matches(block, REGEX_MUL_PATTERN);
        
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