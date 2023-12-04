using AOC2023.Logic.Days;

namespace AOC2023.Logic;

public static class DayRegistry
{
    public static IEnumerable<DayBase> GetDays()
    {
        return new List<DayBase> { new Day01(), new Day02(), new Day03(), new Day04() };
    }
}
