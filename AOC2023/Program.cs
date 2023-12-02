using AOC2023.Contracts;
using AOC2023.Days;

var days = new List<DayBase> { new Day01(), new Day02() };

var selected = SelectDay(days);

if(selected == null)
{
    throw new ArgumentException("No day selected!");
}

var input = selected.GenerateInput();
if(input == null)
{
    Console.WriteLine("No input generated!");
    return;
}
var partOne = selected.SolvePartOne(input);
var partTwo = selected.SolvePartTwo(input);

Console.WriteLine($"PART ONE: {partOne}");
Console.WriteLine($"PART TWO: {partTwo}");

DayBase? SelectDay(List<DayBase> days)
{
    if(args != null && args.Length > 0)
        return SelectDayFromNumber(int.Parse(args[0]));

    foreach (var d in days)
    {
        Console.WriteLine($"[{d.DayNumber:00}] {d.Name}");
    }

    Console.WriteLine("======");
    Console.Write("=> ");
    var selectedDay = int.Parse(Console.ReadLine() ?? string.Empty);
    return SelectDayFromNumber(selectedDay);
}

DayBase? SelectDayFromNumber(int selectedDay)
{
    return days.Where(d => d.DayNumber == selectedDay).FirstOrDefault();
}