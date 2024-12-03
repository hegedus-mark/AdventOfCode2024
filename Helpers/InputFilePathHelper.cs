namespace AdventOfCode.Helpers;

public class InputFilePathHelper
{
    private readonly string _inputFilePath;


    public InputFilePathHelper(string inputFilePath)
    {
        _inputFilePath = inputFilePath;
    }

    public string GetInputFilePath(int dayNum)
    {
        return $"Solutions/Day{dayNum}/{_inputFilePath}";
    }
}