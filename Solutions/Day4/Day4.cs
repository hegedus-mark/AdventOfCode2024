using AdventOfCode.Helpers;

namespace AdventOfCode.Solutions.Day4;

public class Day4
{
    private readonly string _filePath;
    private char[,] _puzzle;

    private static readonly Coords[] DirectionsPart1 = new Coords[]
    {
        new Coords { X = 0, Y = -1 },  // up
        new Coords { X = 1, Y = -1 },  // up-right
        new Coords { X = 1, Y = 0 },   // right
        new Coords { X = 1, Y = 1 },   // down-right
        new Coords { X = 0, Y = 1 },   // down
        new Coords { X = -1, Y = 1 },  // down-left
        new Coords { X = -1, Y = 0 },  // left
        new Coords { X = -1, Y = -1 }  // up-left
    };
    private static readonly char[] WordToFindPart1 = new[] { 'X', 'M', 'A', 'S' };

    private static readonly Coords[][] DirectionPairsPart2 = new Coords[][]
    {
        new Coords[] { new Coords { X = 1, Y = -1 }, new Coords { X = -1, Y = 1 } }, // up-right and down-left
        new Coords[] { new Coords { X = 1, Y = 1 }, new Coords { X = -1, Y = -1 } }  // down-right and up-left
    };

    private static readonly char[] LettersToFindPart2 = new[] { 'M', 'S' };
    private const int LETTERS_TO_FIND_PART2 = 4;
    private const char STARTING_LETTER_PART2 = 'A';



    
    public Day4(InputFilePathHelper inputFilePathHelper)
    {
        _filePath = inputFilePathHelper.GetInputFilePath(4);
        _puzzle = ReadInput();
    }

    public int Part1()
    {
        var foundWords = 0;
        
        for (int row = 0; row < _puzzle.GetLength(0); row++)
        {
            for (int col = 0; col < _puzzle.GetLength(1); col++)
            {
                if (_puzzle[row, col] == WordToFindPart1[0])
                {
                    foundWords += FindWord(new Coords { X = col, Y = row });
                }
            }
        }

        return foundWords;
    }
    
    
    public int Part2()
    {
        var foundWords = 0;
        
        for (int row = 0; row < _puzzle.GetLength(0); row++)
        {
            for (int col = 0; col < _puzzle.GetLength(1); col++)
            {
                if (_puzzle[row, col] == STARTING_LETTER_PART2)
                {
                    foundWords += FindXShapeLetters(new Coords { X = col, Y = row });
                }
            }
        }

        return foundWords;
    }


    private int FindWord(Coords startingCoords)
    {
        var foundWords = 0;
        var foundLetters = 1;
        var foundDirections = new List<Coords>();
        for (int i = 0; i < DirectionsPart1.Length; i++)
        {
            var nextCoords = startingCoords + DirectionsPart1[i];
            if (OutOfBoundary(nextCoords))
            {
                continue;
            }
            if (_puzzle[nextCoords.Y, nextCoords.X] == WordToFindPart1[foundLetters])
            {
                foundDirections.Add(DirectionsPart1[i]);
            }
        }


        while (foundDirections.Count > 0)
        {
            var direction = foundDirections[^1];
            foundLetters = 2; //Already found index 0 and 1
            for (int i = foundLetters; i < WordToFindPart1.Length; i++)
            {
                var newCoord = startingCoords + direction * i;
                if (OutOfBoundary(newCoord))
                {
                    break;
                }

                if (_puzzle[newCoord.Y, newCoord.X] == WordToFindPart1[i])
                {
                    foundLetters++;
                }
                else
                {
                    break;
                }
            }

            if (foundLetters == WordToFindPart1.Length)
            {
                foundWords++;
            }
            
            foundDirections.RemoveAt(foundDirections.Count -1);
        }

        return foundWords;
    }

    private int FindXShapeLetters(Coords startingCoords)
    {
        var foundWords = 0;
        var foundLetters = 0;

        foreach (var directionPairs in DirectionPairsPart2)
        {
            foundLetters += CheckDirectionPairForCorrectChars(directionPairs, startingCoords);
        }

        if (foundLetters == LETTERS_TO_FIND_PART2)
        {
            foundWords++;
        }

        return foundWords;
    }

    private int CheckDirectionPairForCorrectChars(Coords[] directionPair, Coords startingCoords)
    {
        var foundLetters = 0;
        var missingLetters = LettersToFindPart2.ToList();
        foreach (var coord in directionPair)
        {
            var newCoord = startingCoords + coord;

            if (OutOfBoundary(newCoord))
            {
                break;
            }

            var charToCheck = _puzzle[newCoord.Y, newCoord.X];
            if (!FindAndRemoveCharFromList(charToCheck, missingLetters))
            {
                break;
            };

            foundLetters++;
        }

        return foundLetters;
    }

    private bool FindAndRemoveCharFromList(char charToCheck, List<char> chars)
    {
        for (int i = 0; i < chars.Count; i++)
        {
            if (chars[i] == charToCheck)
            {
                chars.RemoveAt(i);
                return true;
            }
        }

        return false;
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
            }
        }

        return puzzle;
    }

    private bool OutOfBoundary(Coords coords)
    {
        return coords.X < 0 || coords.X > _puzzle.GetLength(1) - 1 
                            || coords.Y < 0 || coords.Y > _puzzle.GetLength(0) - 1;
    }
}