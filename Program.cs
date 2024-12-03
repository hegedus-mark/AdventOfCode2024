// See https://aka.ms/new-console-template for more information

using AdventOfCode.Helpers;
using AdventOfCode.TaskNavigation;
using dotenv.net;


var envVars = DotEnv
    .Fluent()
    .WithoutExceptions()
    .WithEnvFiles(".env")
    .Read();


string inputFilePath = envVars.TryGetValue("INPUT_FILE_PATH", out var path) && !string.IsNullOrWhiteSpace(path)
    ? path
    : "input.txt";



Console.WriteLine(inputFilePath);

var inputHelper = new InputFilePathHelper(inputFilePath);

TaskNavigationMenu.Run(inputHelper);