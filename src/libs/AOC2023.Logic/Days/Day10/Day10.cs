namespace AOC2023.Logic.Days.Day10;

public class Day10 : DayBase
{
    public override string Name => "Pipe Maze";

    public override Task<long> SolvePartOne(IEnumerable<string> input)
    {
        var map = new Map(input.Select(x => x.ToCharArray()).ToArray());
        var longestLoop = MapNavigator.TryAllDirections(map);
        return Task.FromResult((long) longestLoop.Count() / 2);
    }

    public override Task<long> SolvePartTwo(IEnumerable<string> input)
    {
        var map = new Map(input.Select(x => x.ToCharArray()).ToArray());
        var longestLoop = MapNavigator.TryAllDirections(map);
        var enclosed = new EnclosedMap(map, longestLoop);
        return Task.FromResult(enclosed.GetEnclosedCount());
    }
}