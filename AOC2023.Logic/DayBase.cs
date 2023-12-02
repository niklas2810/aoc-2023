using AOC2023.Logic.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace AOC2023.Logic;

public abstract class DayBase : IDay<IEnumerable<string>, long>
{
    private const string InputsFolder = "Inputs";
    private string DayFolder => Path.Combine(InputsFolder, DayNumber.ToString("00"));

    private static readonly char[] digits = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    public abstract string Name { get; }
    public int DayNumber => int.Parse(GetType().Name.Substring(GetType().Name.IndexOfAny(digits), 2));


    public IEnumerable<string> GetAvailableFiles()
    {
        if (!Directory.Exists(DayFolder))
            return Enumerable.Empty<string>();

        return Directory.GetFiles(DayFolder).Select(path => Path.GetFileName(path));
    }

    public IEnumerable<string> ReadFile(string filename = "input.txt")
    {
        return File.ReadAllLines(GenerateFilePath(filename));
    }

    public string GenerateFilePath(string filename)
    {
        return Path.Combine(DayFolder, filename);
    }

    public abstract IEnumerable<string> GenerateInput(params object[] args);
    public abstract long SolvePartOne(IEnumerable<string> input);
    public abstract long SolvePartTwo(IEnumerable<string> input);
}
