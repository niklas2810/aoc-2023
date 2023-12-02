
using AOC2023;
using AOC2023.Days;

var days = new List<IDay> { new Day01(), new Day02() };

foreach (var d in days)
{
    Console.WriteLine($"[{d.DayNumber:00}] {d.Name}");
}

Console.WriteLine("======");
Console.Write("=> ");
var selectedDay = int.Parse(Console.ReadLine() ?? string.Empty);
var selected = days.Where(d => d.DayNumber == selectedDay).FirstOrDefault();

if (selected == null)
{
    Console.WriteLine("No day selected!");
    return;
}

var solvePartOneMethod = selected.GetType().GetMethod("SolvePartOne");
var solvePartTwoMethod = selected.GetType().GetMethod("SolvePartTwo");
var generateInputMethod = selected.GetType().GetMethod("GenerateInput");

var input = generateInputMethod?.Invoke(selected, new object[] { Array.Empty<object>() });
if(input == null)
{
    Console.WriteLine("No input generated!");
    return;
}
var partOne = solvePartOneMethod?.Invoke(selected, new object[] { input });
var partTwo = solvePartTwoMethod?.Invoke(selected, new object[] { input });

Console.WriteLine($"PART ONE: {partOne}");
Console.WriteLine($"PART TWO: {partTwo}");

