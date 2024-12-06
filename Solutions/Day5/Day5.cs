using AdventOfCode.Helpers;

namespace AdventOfCode.Solutions.Day5;

public class Day5
{
    private readonly string _filePath;
    private Dictionary<int, List<int>> _dagGraph = new Dictionary<int, List<int>>(); //Directed acyclic graph
    private List<int[]> _updatedPages = new List<int[]>();
    
    //remove
    
    public Day5(InputFilePathHelper inputFilePathHelper)
    {
        _filePath = inputFilePathHelper.GetInputFilePath(5);
        ReadInput();
    }
    
    public int Part1()
    {
        var sumOfMiddlePages = 0;
        foreach (var updatedPage in _updatedPages)
        {
            var subGraph = GetSubSetOfMainGraph(updatedPage);
            var order = SortGraphTopologically(subGraph);
            int pagesInCorrectOrder = 0;
            foreach (var pageInOrder in order)
            {
                if (pagesInCorrectOrder == updatedPage.Length)
                {
                    break;
                }
                if (updatedPage[pagesInCorrectOrder] == pageInOrder)
                {
                    pagesInCorrectOrder++;
                }
            }

            if (updatedPage.Length == pagesInCorrectOrder)
            {
                var middlePage = (int)Math.Floor((double)updatedPage.Length / 2);
                sumOfMiddlePages += updatedPage[middlePage];
            }
        }

        return sumOfMiddlePages;
    }
    
    
    

    public int Part2()
    {
        var sumOfMiddlePages = 0;
        foreach (var updatedPage in _updatedPages)
        {
            var subGraph = GetSubSetOfMainGraph(updatedPage);
            var order = SortGraphTopologically(subGraph);
            int pagesInCorrectOrder = 0;
            foreach (var pageInOrder in order)
            {
                if (pagesInCorrectOrder == updatedPage.Length)
                {
                    break;
                }
                if (updatedPage[pagesInCorrectOrder] == pageInOrder)
                {
                    pagesInCorrectOrder++;
                }
            }

            if (updatedPage.Length != pagesInCorrectOrder)
            {
                var correctOrderList = updatedPage.OrderBy(n => order.IndexOf(n)).ToList();
                var middlePage = (int)Math.Floor((double)updatedPage.Length / 2);
                sumOfMiddlePages += correctOrderList[middlePage];
            }
        }

        return sumOfMiddlePages;
    }


    private List<int> SortGraphTopologically(Dictionary<int, List<int>> graph)
    {
        //This implements the Topological sorting algorithm https://en.wikipedia.org/wiki/Topological_sorting
        var sortedList = new List<int>();
        var inDegrees = new Dictionary<int, int>();
        
        foreach (var node in graph)
        {
            inDegrees.TryAdd(node.Key, 0);

            foreach (var neighbour in graph[node.Key])
            {
                if (!inDegrees.TryAdd(neighbour, 1))
                {
                    inDegrees[neighbour] += 1;
                }
            }
        }
        
        var queue = new Queue<int>();

        foreach (var node in inDegrees)
        {
            if (node.Value == 0)
            {
                queue.Enqueue(node.Key);
            }
        }

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            sortedList.Add(node);

            foreach (var neighbour in graph[node])
            {
                inDegrees[neighbour] -= 1;
                if (inDegrees[neighbour] == 0)
                {
                    queue.Enqueue(neighbour);
                }
            }
        }

        if (sortedList.Count != graph.Keys.Count)
        {
            throw new InvalidOperationException("Graph has a cycle! Topological sorting is not possible");
        }

        return sortedList;

    }

    private Dictionary<int, List<int>> GetSubSetOfMainGraph(int[] pages)
    {
        var subGraph = new Dictionary<int, List<int>>();

        foreach (var page in pages)
        {
            subGraph[page] = new List<int>();

            foreach (var neighbour in _dagGraph[page])
            {
                if (pages.Contains(neighbour))
                {
                    subGraph[page].Add(neighbour);
                }
            }
        }

        return subGraph;
    }

    private void ReadInput()
    {
        var switched = false;
        foreach (var line in File.ReadLines(_filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                switched = true;
                continue;
            }

            if (!switched)
            {
                var (first, second) = ConvertLineToTwoNumbers(line);
                AddNumbersToGraph(first, second);
            }
            else
            {
                var arr = ConvertLineToNumArray(line);
                _updatedPages.Add(arr);
            }
            
        }
    }

    private int[] ConvertLineToNumArray(string line)
    {
        return line.Split(",").Select(n => int.Parse(n)).ToArray();
    }
    
    private (int first, int second) ConvertLineToTwoNumbers(string line)
    {
        var arr = line.Split("|");
        return (int.Parse(arr[0]), int.Parse(arr[1]));
    }
    
    private void AddNumbersToGraph(int firstNumber, int secondNumber)
    {
        if (!_dagGraph.ContainsKey(firstNumber))
        {
            _dagGraph[firstNumber] = new List<int> { secondNumber };
        }
        else
        {
            _dagGraph[firstNumber].Add(secondNumber);
        }

        if (!_dagGraph.ContainsKey(secondNumber))
        {
            _dagGraph[secondNumber] = new List<int>();
        }
        
    }
    
}