using System.Text;

namespace AOC2023.Logic.Days;

public class Day01 : DayBase
{
    public override string Name => "Trebuchet?!";

    // Dictionary of digit names (e.g. "one", "two", etc.) and their values as chars
    private static readonly Dictionary<string, char> DigitNames = new()
    {
        ["zero"] = '0',
        ["one"] = '1',
        ["two"] = '2',
        ["three"] = '3',
        ["four"] = '4',
        ["five"] = '5',
        ["six"] = '6',
        ["seven"] = '7',
        ["eight"] = '8',
        ["nine"] = '9'
    };

    public override IEnumerable<string> GenerateInput(params object[] args)
    {
        return args.Length > 0 && args[0] is string p ? ReadFile(p) : ReadFile();
    }

    public override long SolvePartOne(IEnumerable<string> input)
    {
        var sums = new List<int>();
        foreach (var line in input)
        {
            var all = line.Where(c => c >= '0' && c <= '9').Select(c => c - '0').ToArray();
            var s = all[0] * 10 + all[all.Count() - 1];
            sums.Add(s);
        }
        return sums.Sum();
    }

    public override long SolvePartTwo(IEnumerable<string> input)
    {
        var sums = new List<int>();
        foreach (var line in input)
        {
            var filtered = Convert(line);
            //find first and list digit in line
            var first = filtered.FirstOrDefault(char.IsDigit) - '0';
            var last = filtered.LastOrDefault(char.IsDigit) - '0';
            sums.Add(first * 10 + last);
        }
        return sums.Sum();
    }

    private static string Convert(string line)
    {
        // Build new line, keeping digits and replacing written numbers (e.g. "one") with digits
        var newLine = new StringBuilder();

        for (int i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                newLine.Append(line[i]);
            }
            else
            {
                foreach (var (name, digit) in DigitNames)
                {
                    if (line[i..].StartsWith(name))
                    {
                        newLine.Append(digit);
                    }
                }
            }
        }

        return newLine.ToString();
    }
}
