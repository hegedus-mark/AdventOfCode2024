# Advent of Code 2024 - Solutions

This repository contains my solutions to the Advent of Code 2024 challenge. Each day of the challenge is represented by a separate folder, with solutions for both Part 1 and Part 2 of the challenge. The solutions are implemented in C#.

## Project Structure

The project is structured as follows:

```
root/
│
├── Solutions/
│   ├── Day1/
│   │   ├── Day1.cs
│   │   └── input.txt 
│   ├── Day2/
│   │   ├── Day2.cs
│   │   └── input.txt 
│   └── ...
├── AdventOfCode.csproj
└── README.md
```

### Folder Breakdown:
- **root/Solutions/DayX/**: Each `DayX` folder corresponds to a specific day's challenge. It contains:
  - **DayX.cs**: The C# class implementing the solution for Day X. Each class contains two static methods, `Part1` and `Part2`, for solving the respective parts of the challenge.
  - **input.txt**: The input data file used for testing the solution. This file is unique for each day.

### Solution Structure:

Each `DayX.cs` file contains two methods:
- **Part1()**: This method implements the solution for Part 1 of the challenge.
- **Part2()**: This method implements the solution for Part 2 of the challenge.

The idea is to keep each day's solution encapsulated in its own class file to maintain organization and readability.

## Input Files

Due to copyright issues, the input files for the Advent of Code challenge cannot be uploaded to this repository and the repository is using sample input files. However, you can easily download the input files for each day directly from the [Advent of Code website](https://adventofcode.com/2024). Once you've obtained the input files, place them in the corresponding `Solutions/DayX/` folder in your local project directory, and you’ll be able to run the solutions using the provided input.

## Planned Features

One of the planned features for this project is a **terminal-based application** that will allow you to easily navigate through the solutions of each day and view the corresponding answers for Part 1 and Part 2. This terminal will provide a simple interface to:

- Navigate through each day of the Advent of Code challenge (up to Day 25).
- Run the solutions for Part 1 and Part 2 for any day.
- View the task description with a direct link to the official Advent of Code website.

This feature is designed to provide an interactive experience while exploring the solutions, making it easier to keep track of progress and revisit any day’s solution at any time.

## Running the Solutions

To run the solutions, follow these steps:

1. Clone this repository to your local machine.
2. Download the input files for each day from the [Advent of Code website](https://adventofcode.com/2024) and place them in the respective `Solutions/DayX/` folders.
3. Open the project in your preferred C# IDE or terminal.
4. Build and run the project. You can invoke the solutions for a specific day by running the respective methods (e.g., `Day1.Part1()`).

The terminal-based navigation will be implemented soon, and you’ll be able to navigate through the solutions using simple commands.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
