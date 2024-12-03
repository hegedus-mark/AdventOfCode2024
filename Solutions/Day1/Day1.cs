namespace AdventOfCode.Solutions.Day1;

public class Day1
{
    private static string filePath = "./Solutions/Day1/input.txt";
    private static List<int> _column1 = new();
    private static List<int> _column2 = new();
    private static Dictionary<int, int> _occurences = new Dictionary<int, int>();

    
    
    public static int Part1()
    {
        ReadFromInput();
        
        _column1.Sort();
        _column2.Sort();

        var sum = 0;
        for (int i = 0; i < _column1.Count; i++)
        {
            sum += Math.Abs(_column1[i] - _column2[i]);
        }

        return sum;
    }
    
    public static int Part2()
    {
        ReadFromInput();
        CountOccurencesInRightCol();
        
        var similarityScore = 0;
        foreach (var num in _column1)
        {
            if (_occurences.ContainsKey(num))
            {
                similarityScore += num * _occurences[num];
            }
        }

        return similarityScore;
    }

    private static void CountOccurencesInRightCol()
    {
        foreach (var num in _column2)
        {
            if (!_occurences.ContainsKey(num))
            {
                _occurences[num] = 1;
            }
            else
            {
                _occurences[num] += 1;
            }
        }
    }

    private static void ReadFromInput()
    {
        foreach (var line in File.ReadLines(filePath))
        {
            string[] columns = line.Split("   ");

            if (columns.Length == 2)
            {
                _column1.Add(int.Parse(columns[0]));
                _column2.Add(int.Parse(columns[1]));
            }
        }
    }
}