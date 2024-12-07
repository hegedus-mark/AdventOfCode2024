using AdventOfCode.Helpers;
using AdventOfCode.Solutions.Day4;

namespace AdventOfCode.Solutions.Day6;

public class Day6
{
    private readonly string _filePath;
    

    private static readonly Dictionary<char, Coords> GuardDirections = new Dictionary<char, Coords>
    {
        { '^', new Coords { X = 0, Y = -1 } }, //up
        { '>', new Coords { X = 1, Y = 0 } }, // right
        { 'v', new Coords { X = 0, Y = 1 } }, //down
        { '<', new Coords { X = -1, Y = 0 } } //left
    };

    private static readonly List<char> GuardCycle = GuardDirections.Keys.ToList();


    private Coords _startingPos;
    private char[,] _map;

    public Day6(InputFilePathHelper inputFilePathHelper)
    {
        _filePath = inputFilePathHelper.GetInputFilePath(6);
        _map = ReadInput();
    }

    public int Part1()
    {
        var newPos = _startingPos;
        var currentGuard = GetCharFromCoords(newPos);
        var direction = GuardDirections[currentGuard];
        var cycleCount = GuardCycle.IndexOf(currentGuard);
        _map[newPos.Y, newPos.X] = 'X';
        var zonesVisited = 1;
        while (true)
        {
            newPos += direction;
            if (OutOfBoundary(newPos))
            {
                break;
            }

            var zone = GetCharFromCoords(newPos);

            if (zone == '#')
            {
                cycleCount = (cycleCount + 1) % GuardCycle.Count;
                currentGuard = GuardCycle[cycleCount];
                newPos -= direction;
                direction = GuardDirections[currentGuard];
            }
            else if (zone == '.')
            {
                _map[newPos.Y, newPos.X] = 'X';
                zonesVisited++;
            }
            
        }

        return zonesVisited;
    }

    public int Part2()
    {
        var newPos = _startingPos;
        var currentGuard = GetCharFromCoords(newPos);
        var direction = GuardDirections[currentGuard];
        var cycleCount = GuardCycle.IndexOf(currentGuard);
        var cycleChanges = 0;
        _map[newPos.Y, newPos.X] = 'X';
        while (true)
        {
            newPos += direction;
            if (OutOfBoundary(newPos))
            {
                break;
            }

            var zone = GetCharFromCoords(newPos);

            if (zone == '#')
            {
                cycleCount = (cycleCount + 1) % GuardCycle.Count;
                currentGuard = GuardCycle[cycleCount];
                newPos -= direction;
                direction = GuardDirections[currentGuard];
                cycleChanges++;
            }
            
        }
        
        

        return cycleChanges / GuardCycle.Count -1;
    }

    
    private bool OutOfBoundary(Coords coords)
    {
        return coords.X < 0 || coords.X > _map.GetLength(1) - 1 
                            || coords.Y < 0 || coords.Y > _map.GetLength(0) - 1;
    }

    private char GetCharFromCoords(Coords coords)
    {
        return _map[coords.Y, coords.X];
    }

    private char[,] ReadInput()
    {
        var lines = File.ReadLines(_filePath).ToList();
        int rows = lines.Count;
        int cols = lines[0].Length; 

        var puzzle = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                puzzle[i, j] = lines[i][j];
                if (GuardCycle.Contains(puzzle[i, j]))
                {
                    _startingPos = new Coords { X = j, Y = i };
                }
            }
        }

        return puzzle;
    }
}