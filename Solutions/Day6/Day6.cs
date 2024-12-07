using AdventOfCode.Helpers;
using AdventOfCode.Solutions.Day4;

namespace AdventOfCode.Solutions.Day6;

public class Day6
{
    private readonly string _filePath;


    private static readonly List<Coord> GuardCycle = new List<Coord>()
    {
         new Coord { X = 0, Y = -1 } , //up
         new Coord { X = 1, Y = 0 } , // right
         new Coord { X = 0, Y = 1 } , //down
         new Coord { X = -1, Y = 0 }  //left
    };


    private Coord _startingPos;
    private Dictionary<Coord, char> _map = new Dictionary<Coord, char>();

    public Day6(InputFilePathHelper inputFilePathHelper)
    {
        _filePath = inputFilePathHelper.GetInputFilePath(6);
        ReadInput();
    }

    //5564
    public int Part1()
    {
        return SimulateGuardMovement(_map, _startingPos, GuardCycle[0]).positions.Count();
    }

    public int Part2()
    {
        var loops = 0;

        var positions = SimulateGuardMovement(_map, _startingPos, GuardCycle[0]).positions;

        var emptyZonesInPositions = positions.Where(p => _map[p] == '.');
        
        //Simulate the guard movement by placing obstacles at every visited location and placing an obstacle
        //This won't place an obstacle at a startingPos or at a place with an obstacle and can only place one obstacle at every empty visited zone
        foreach (var emptyZone in emptyZonesInPositions)
        {
            _map[emptyZone] = '#';
            if (SimulateGuardMovement(_map, _startingPos, GuardCycle[0]).isLoop)
            {
                loops++;
            }

            _map[emptyZone] = '.';
        }

        return loops;
    }

    private (IEnumerable<Coord> positions, bool isLoop) SimulateGuardMovement(Dictionary<Coord, char> map, Coord position, Coord direction)
    {
        var visited = new HashSet<(Coord pos, Coord dir)>();

        while (map.ContainsKey(position) && !visited.Contains((position, direction)))
        {
            visited.Add((position, direction));
            if (map.GetValueOrDefault(position + direction) == '#')
            {
                direction = GetNextDirection(direction);
            }
            else
            {
                position += direction;
            }
        }

        return (
            positions : visited.Select(s => s.pos).Distinct(),
            isLoop: visited.Contains((position, direction))
        );
    }
    
    

    private Coord GetNextDirection(Coord coord)
    {
        var currentIndex = GuardCycle.IndexOf(coord);
        var nextIndex = (currentIndex + 1) % GuardCycle.Count;
        return GuardCycle[nextIndex];
    }
    

    private void ReadInput()
    {
        var lines = File.ReadLines(_filePath).ToList();
        for (int y = 0; y < lines.Count; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                var ch = lines[y][x];
                var coord = new Coord { X = x, Y = y };
                
                if (ch == '^')
                {
                    _startingPos = coord;
                }

                _map[coord] = ch;
            }
        }
    }
    
}