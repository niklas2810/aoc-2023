using AOC2023.Logic.Days;
using AOC2023.Logic.Days.Day10;

namespace AOC2023.Logic;

public static class DayRegistry
{
    public static IEnumerable<DayBase> GetDays()
    {
        return new List<DayBase> { new Day01(), new Day02(), new Day03(), new Day04(), new Day05(), new Day06(), new Day07(), new Day08(), new Day09(), new Day10(), new Day11() };
    }
}
