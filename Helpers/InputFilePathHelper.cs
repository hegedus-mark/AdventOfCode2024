namespace AdventOfCode.Helpers;

public class InputFilePathHelper
{
    
    public string GetInputFilePath(int dayNum)
    {
        string dayInputFolder = $"Solutions/Day{dayNum}/Input";

        if (!Directory.Exists(dayInputFolder))
        {
            throw new DirectoryNotFoundException($"Directory {dayInputFolder} does not exist.");
        }


        var files = Directory.GetFiles(dayInputFolder).Where(f => f.EndsWith(".txt")).ToList();

        if (files.Count == 0)
        {
            throw new FileNotFoundException($"No input files found in {dayInputFolder}.");
        }
        else if (files.Count == 1)
        {
            return files[0];
        }
        else
        {
            Console.WriteLine("Multiple input files detected:");
            for (int i = 0; i < files.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
            }

            int selectedIndex;
            do
            {
                Console.Write("Select a file by number: ");
            } while (!int.TryParse(Console.ReadLine(), out selectedIndex) || selectedIndex < 1 ||
                     selectedIndex > files.Count);

            return files[selectedIndex - 1];
        }
    }
}