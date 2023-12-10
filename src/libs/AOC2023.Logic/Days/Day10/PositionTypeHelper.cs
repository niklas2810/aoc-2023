namespace AOC2023.Logic.Days.Day10;

internal static class PositionTypeHelper
{
    public static PositionType CharToPos(char c)
    {
        return c switch
        {
            'S' => PositionType.Start,
            '.' => PositionType.Ground,
            '-' => PositionType.Horizontal,
            '|' => PositionType.Vertical,
            'L' => PositionType.BendNorthEast,
            'J' => PositionType.BendNorthWest,
            '7' => PositionType.BendSouthWest,
            'F' => PositionType.BendSouthEast,
            _ => throw new Exception($"Unknown character {c}")
        };
    }

    public static char PosToChar(PositionType pos)
    {
        return pos switch
        {
            PositionType.Start => 'S',
            PositionType.Ground => '.',
            PositionType.Horizontal => '-',
            PositionType.Vertical => '|',
            PositionType.BendNorthEast => 'L',
            PositionType.BendNorthWest => 'J',
            PositionType.BendSouthWest => '7',
            PositionType.BendSouthEast => 'F',
            _ => throw new Exception($"Unknown position type {pos}")
        };
    }

    public static bool OpensEast(PositionType? startChar)
    {
        return startChar == PositionType.Horizontal || startChar == PositionType.BendNorthEast ||
               startChar == PositionType.BendSouthEast || startChar == PositionType.Start;
    }


    public static bool MatchesTypes(PositionType actual, params PositionType[] test)
    {
        return test.Contains(actual);
    }

    public static bool IsTypeOrStart(PositionType actual, PositionType test)
    {
        return MatchesTypes(actual, test, PositionType.Start);
    }

    public static bool HorizontalEnclosing(PositionType startChar, PositionType endChar)
    {
        var isNorthFacingEnclosing = IsTypeOrStart(startChar, PositionType.BendSouthEast) && IsTypeOrStart(endChar, PositionType.BendSouthWest);
        var isSouthFacingEnclosing = IsTypeOrStart(startChar, PositionType.BendNorthEast) &&
                                     IsTypeOrStart(endChar, PositionType.BendNorthWest);

        return isNorthFacingEnclosing || isSouthFacingEnclosing;
    }
}