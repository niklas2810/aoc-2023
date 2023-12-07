using AOC2023;
using AOC2023.Cli;
using AOC2023.Logic;
using System.Diagnostics;

if(!Directory.Exists("Inputs"))
{
    Console.WriteLine($"Directory does not exist: {Path.GetFullPath("Inputs")}");
    Console.WriteLine("Please place your input files in the Inputs folder and restart.");
    return;
}

var days = DayRegistry.GetDays().ToList();
if (args != null && args.Length > 0)
{
    var runMode = args[0].ToString();
    if(runMode == "all")
    {
        var sw = new Stopwatch();
        sw.Start();
        foreach(var d in days)
            await ExecuteDay(d);
        Console.WriteLine(string.Empty.Bordered());
        Console.WriteLine($"TOTAL TIME: {sw.Elapsed.TotalMilliseconds:00.00}ms");

    } else if(int.TryParse(runMode, out int dayNumber))
    {
        var dayFromArgs = SelectDayFromNumber(dayNumber) ?? throw new ArgumentException($"Day {dayNumber} not found!");
        await ExecuteDay(dayFromArgs);
    } else
    {
        Console.WriteLine($"Invalid arguments: '{args}'");
    }
    return;
}
    

var dayFromPrompt = PromptUserForDay(days);
if(dayFromPrompt == null)
    throw new ArgumentException("No day selected!");
if(dayFromPrompt.GetAvailableFiles().Count() == 0)
    throw new ArgumentException($"No input files found for day {dayFromPrompt.DayNumber}!");
var filename = PromptUserForFile(dayFromPrompt);

await ExecuteDay(dayFromPrompt, filename);

async Task ExecuteDay(DayBase selected, string filename = "input.txt")
{
    Console.WriteLine($"Day {selected.DayNumber:00}: {selected.Name}".Bordered());
    // Create stopwatch sw and start
    var sw = new Stopwatch();
    sw.Start();
    var input = selected.GenerateInput(filename);
    if (input == null)
    {
        Console.WriteLine("No input generated!");
        return;
    }
    var sw1 = new Stopwatch();
    sw1.Start();
    long partOne = await selected.SolvePartOne(input);
    sw1.Stop();
    var sw2 = new Stopwatch();
    sw2.Start();
    long partTwo = await selected.SolvePartTwo(input);
    sw2.Stop();

    Console.WriteLine($"PART   ONE: {partOne} [{sw1.Elapsed.TotalMilliseconds:00.00}ms]");
    Console.WriteLine($"PART   TWO: {partTwo} [{sw2.Elapsed.TotalMilliseconds:00.00}ms]");

    // Write elapsed milliseconds with 2 digits precision based on sw.Elapsed.TotalNanoseconds
    Console.WriteLine($"EXEC  TIME: {sw.Elapsed.TotalMilliseconds:00.00}ms");
}

string PromptUserForFile(DayBase day)
{
    Console.WriteLine("SELECT FILE".Bordered());
    int i = 0;
    var files = day.GetAvailableFiles().ToList();
    foreach (var f in files)
    {
        Console.WriteLine($"[{++i}] {f}");
    }
    Console.WriteLine(string.Empty.Bordered());
    var fileIndex = ConsoleUtils.ReadInt(val => val > 0 && val <= files.Count, files.FindIndex(str => str == "input.txt")+1);
    return day.GetAvailableFiles().ElementAt(fileIndex - 1);
}

DayBase? PromptUserForDay(List<DayBase> days)
{
    Console.WriteLine("SELECT DAY".Bordered());
    foreach (var d in days)
        Console.WriteLine($"[{d.DayNumber:00}] {d.Name,15} ({d.GetAvailableFiles().Count()} input files available)");

    Console.WriteLine(string.Empty.Bordered());
    var selectedDay = ConsoleUtils.ReadInt(val => days.Any(d => d.DayNumber == val));
    return SelectDayFromNumber(selectedDay);
}

DayBase? SelectDayFromNumber(int selectedDay)
{
    return days.FirstOrDefault(d => d.DayNumber == selectedDay);
}