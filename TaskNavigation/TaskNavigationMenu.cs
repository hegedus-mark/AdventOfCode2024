using System.Reflection;
using AdventOfCode.Helpers;

namespace AdventOfCode.TaskNavigation;

public static class TaskNavigationMenu
{
    public static void Run(InputFilePathHelper inputFilePathHelper)
    {
        ConsoleOutput("Welcome to the Advent of Code Runner!");
        while (true)
        {
            string? dayInput = GetDayInput();
            if (dayInput == "exit") break;

            if (int.TryParse(dayInput, out int day) && IsValidDay(day))
            {
                HandleDaySelection(day, inputFilePathHelper);
            }
            else
            {
                ConsoleOutput("Invalid input. Please select a number between 1 and 25 or type 'exit'.");
            }
        }

        Console.WriteLine("Goodbye!");
    }

    private static string? GetDayInput()
    {
        return ConsoleReadInput("\nSelect a day (1 to 25) or type 'exit' to quit:");
    }

    private static bool IsValidDay(int day)
    {
        return day >= 1 && day <= 25;
    }

    private static void HandleDaySelection(int day, InputFilePathHelper inputFilePathHelper)
    {
        string dayClassName = $"Day{day}";
        Type? dayType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == dayClassName);

        if (dayType != null)
        {
            ExecuteDayTask(day, dayType, inputFilePathHelper);
        }
        else
        {
            ConsoleOutput($"Day {day} class does not exist.");
        }
    }

    private static void ExecuteDayTask(int day, Type dayType, InputFilePathHelper inputFilePathHelper)
    {
        object? dayInstance = Activator.CreateInstance(dayType, inputFilePathHelper);
        if (dayInstance == null)
        {
            ConsoleOutput($"Failed to create an instance of Day {day}.");
            return;
        }

        string? partInput = GetPartInput(day);
        if (int.TryParse(partInput, out int part) && IsValidPart(part))
        {
            ExecutePart(day, part, dayType, dayInstance);
        }
        else
        {
            ConsoleOutput("Invalid part. Please select 1 or 2.");
        }
    }

    private static string? GetPartInput(int day)
    {
       return ConsoleReadInput($"Day {day} loaded. Select a part to run (1 or 2):");
    }

    private static bool IsValidPart(int part)
    {
        return part == 1 || part == 2;
    }

    private static void ExecutePart(int day, int part, Type dayType, object dayInstance)
    {
        string methodName = $"Part{part}";
        MethodInfo? method = dayType.GetMethod(methodName);

        if (method != null)
        {
            InvokeMethod(day, part, method, dayInstance);
        }
        else
        {
            ConsoleOutput($"Part {part} does not exist for Day {day}.");
        }
    }

    private static void InvokeMethod(int day, int part, MethodInfo method, object dayInstance)
    {
        try
        {
            var result = method.Invoke(dayInstance, null);
            ConsoleOutput($"Output of Day {day} - Part {part}: {result}");
        }
        catch (Exception ex)
        {
            ConsoleOutput($"Error executing Part {part} of Day {day}: {ex.Message}");
        }
    }

    private static void ConsoleOutput(string text)
    {
        Console.Clear();
        Console.WriteLine(text);
        Console.WriteLine("Press enter to continue...");
        Console.ReadKey(true);
    }

    private static string? ConsoleReadInput(string question)
    {
        Console.Clear();
        Console.WriteLine(question);
        return Console.ReadLine()?.Trim();
    }
}