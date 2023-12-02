

namespace AOC2023
{
    static class StringExtensions
    {
        public static string Bordered(this string s, int targetLength = 50, char borderChar = '=')
        {
            if(string.IsNullOrWhiteSpace(s))
                return new string(borderChar, targetLength);

            var filler = (targetLength - s.Length - 2) / 2;

            // Repeat "=" fillter times
            var border = new string(borderChar, filler);
            var fillerChar = ((targetLength-s.Length) % 2) != 0 ? "=" : string.Empty;

            return $"{border} {s} {border}{fillerChar}";
        }
    }
}
