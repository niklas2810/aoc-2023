namespace AOC2023.Logic.Days.Day10;

internal class MapNavigator
{

    public (int x, int y) Position { get; private set; }

    private readonly List<(int, int)> _knownPositions; // All past positions excluding current
    private readonly Map _map;


    public MapNavigator(Map map, (int x, int y) startDirection)
    {
        this._map = map;

        var (sx, sy) = map.Start;
        Position = (sx + startDirection.x, sy + startDirection.y);
        _knownPositions = new List<(int, int)> { (sx, sy) };
    }

    private (int, int) DistanceToLast()
    {
        var (lx, ly) = _knownPositions.LastOrDefault();
        return (Position.x - lx, Position.y - ly);
    }

    private Direction CurrentDirection()
    {
        var (dx, dy) = DistanceToLast();
        return (dx, dy) switch
        {
            (1, 0) => Direction.East,
            (-1, 0) => Direction.West,
            (0, 1) => Direction.South,
            (0, -1) => Direction.North,
            _ => throw new Exception("Unknown direction")
        };
    }

    public void Step()
    {
        var next = NextStep();
        _knownPositions.Add(Position);
        Position = next;
    }

    private (int, int) NextStep()
    {
        var currentType = _map.At(Position.x, Position.y);
        var currentDir = CurrentDirection();
        // Catch invalid positions
        if (currentType == PositionType.Invalid)
            throw new Exception("Invalid position");
        if (currentType == PositionType.Start)
            throw new Exception("Start is not a direction");
        if (currentType == PositionType.Ground)
            throw new Exception("Ground is not a direction");
        // Basic directions
        if (currentType == PositionType.Horizontal)
        {
            if (currentDir == Direction.East)
                return (Position.x + 1, Position.y);
            if (currentDir == Direction.West)
                return (Position.x - 1, Position.y);
            throw new Exception("Invalid direction");
        }

        if (currentType == PositionType.Vertical)
        {
            if (currentDir == Direction.North)
                return (Position.x, Position.y - 1);
            if (currentDir == Direction.South)
                return (Position.x, Position.y + 1);
            throw new Exception("Invalid direction");
        }

        // Bend directions
        if (currentType == PositionType.BendNorthEast)
        {

            if (currentDir == Direction.South)
                return (Position.x + 1, Position.y);
            if (currentDir == Direction.West)
                return (Position.x, Position.y - 1);
            throw new Exception("Invalid direction");
        }

        if (currentType == PositionType.BendNorthWest)
        {
            if (currentDir == Direction.South)
                return (Position.x - 1, Position.y);
            if (currentDir == Direction.East)
                return (Position.x, Position.y - 1);
            throw new Exception("Invalid direction");
        }

        if (currentType == PositionType.BendSouthWest)
        {
            if (currentDir == Direction.North)
                return (Position.x - 1, Position.y);
            if (currentDir == Direction.East)
                return (Position.x, Position.y + 1);
            throw new Exception("Invalid direction");
        }

        if (currentType == PositionType.BendSouthEast)
        {
            if (currentDir == Direction.North)
                return (Position.x + 1, Position.y);
            if (currentDir == Direction.West)
                return (Position.x, Position.y + 1);
            throw new Exception("Invalid direction");
        }

        throw new Exception("Unknown type");
    }


    public override string ToString()
    {
        var lines = _map.ToString().Split("\n");
        var replace = lines[Position.y];
        replace = replace[..Position.x] + "*" + replace[(Position.x + 1)..];
        lines[Position.y] = replace;
        return string.Join("\n", lines);
    }

    public static IEnumerable<(int, int)> TryAllDirections(Map map)
    {
        var longest = new List<(int, int)>();

        for (var x = -1; x <= 1; ++x)
        {
            for (var y = -1; y <= 1; ++y)
            {
                if (Math.Abs(x) == Math.Abs(y))
                    continue;

                var res = TryLoop(map, (x, y));
                if (res != null && res.Count > longest.Count)
                    longest = res;
            }
        }
        return longest;
    }

    private static List<(int, int)>? TryLoop(Map map, (int, int) startDir)
    {
        try
        {
            var navigator = new MapNavigator(map, startDir);
            while (true)
            {
                navigator.Step();
                if (map.At(navigator.Position.x, navigator.Position.y) == PositionType.Start)
                    return navigator._knownPositions;
            }
        }
        catch
        {
            return null;
        }
    }
}