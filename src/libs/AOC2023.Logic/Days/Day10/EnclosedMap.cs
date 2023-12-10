using System.Text;

namespace AOC2023.Logic.Days.Day10;

internal class EnclosedMap
{
    private readonly bool[][] _loopElements;
    private readonly bool[][] _enclosed;
    private readonly Map _map;

    public EnclosedMap(Map map, IEnumerable<(int, int)> longestLoop)
    {
        _map = map;
        var loopArray = longestLoop.ToArray();
        _loopElements = new bool[map.Height][];
        for(int i = 0; i < map.Height; ++i)
            _loopElements[i] = new bool[map.Width];
        foreach (var (x, y) in loopArray)
            _loopElements[y][x] = true;
        _enclosed = new bool[map.Height][];

        for (var y = 0; y < map.Height; ++y)
        {
            _enclosed[y] = new bool[map.Width];
            var inLoop = false;
            var x = 0;

            while (x < map.Width)
            {
                if (_loopElements[y][x])
                {
                    var startChar = map.At(x, y);
                    // Can we go east?
                    if (PositionTypeHelper.OpensEast(startChar))
                    {
                        // Go east until we can't
                        while (x < map.Width && PositionTypeHelper.OpensEast(map.At(x, y)))
                            ++x;
                        if(x >= map.Width)
                            break;
                        var endChar = map.At(x, y);
                        // If it was continuous, we're not enclosed
                        if (!PositionTypeHelper.HorizontalEnclosing(startChar, endChar))
                            inLoop = !inLoop;
                    }
                    else // Normal delimiter, can't be continuous
                        inLoop = !inLoop;
                    ++x;
                }
                else
                {
                    if(inLoop)
                        _enclosed[y][x] = true;
                    ++x;
                }
            }
        }
    }

    public long GetEnclosedCount()
    {
        return _enclosed.Sum(line => line.Count(x => x));
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        for (var y = 0; y < _map.Height; ++y)
        {
            for (var x = 0; x < _map.Width; ++x)
            {
                if(_loopElements[y][x])
                    sb.Append(PositionTypeHelper.PosToChar(_map.At(x, y)));
                else if (_enclosed[y][x])
                    sb.Append('I');
                else
                    sb.Append('O');
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}