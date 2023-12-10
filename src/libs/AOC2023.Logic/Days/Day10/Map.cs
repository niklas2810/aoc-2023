using System.Text;

namespace AOC2023.Logic.Days.Day10;

internal class Map
{

    private readonly IReadOnlyList<PositionType[]> _map;

    public Map(IEnumerable<IEnumerable<char>> charMap)
    {
        var parsed = new List<PositionType[]>();
        foreach (var line in charMap)
        {
            var lineArray = line?.ToArray();
            if (lineArray == null || lineArray.Length == 0)
                throw new ArgumentException("Lines can not be empty");

            var parsedLine = new PositionType[lineArray.Length];
            for (var i = 0; i < lineArray.Length; ++i)
                parsedLine[i] = PositionTypeHelper.CharToPos(lineArray[i]);

            parsed.Add(parsedLine);
        }

        _map = parsed;
    }

    public (int, int) Start => FindPosition(PositionType.Start) ?? throw new Exception("No start found");
    
    public int Height => _map.Count;

    public int Width => _map[0].Length;

    private (int, int)? FindPosition(PositionType t)
    {
        for (var y = 0; y < this.Height; ++y)
            for (var x = 0; x < this.Width; ++x)
                if (_map[y][x] == t)
                    return (x, y);

        return null;
    }

    public PositionType At(int x, int y)
    {
        if (x < 0 || y < 0 || y >= this.Height || x >= this.Width)
            return PositionType.Invalid;
        return _map[y][x];
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var line in _map)
        {
            foreach (var pos in line)
                sb.Append(PositionTypeHelper.PosToChar(pos));
            sb.AppendLine();
        }
        return sb.ToString();
    }
}