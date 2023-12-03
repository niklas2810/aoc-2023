using System.Security.Cryptography.X509Certificates;

namespace AOC2023.Logic.Days;

/*
 The engineer explains that an engine part seems to be missing from the engine, but nobody can figure out which one. If you can add up all the part numbers in the engine schematic, it should be easy to work out which part is missing.

The engine schematic (your puzzle input) consists of a visual representation of the engine. There are lots of numbers and symbols you don't really understand, but apparently any number adjacent to a symbol, even diagonally, is a "part number" and should be included in your sum. (Periods (.) do not count as a symbol.)
 */
public class Day03 : DayBase
{
	public override string Name => "Gear Ratios";

	private char[][]? map;
	private readonly List<Number> numbers = new List<Number>();
	private readonly List<(int, int)> symbols = new();

	public override Task<long> SolvePartOne(IEnumerable<string> input)
	{
		ParseMap(input);
		if (map == null)
			return Task.FromResult(-1L);

		long sum = 0;
		foreach(var number in numbers)
		{
			if(number.IsPartOfSymbols(symbols))
				sum += number.Value;
		}

		return Task.FromResult(sum);
	}

	public override Task<long> SolvePartTwo(IEnumerable<string> input)
	{
		ParseMap(input);
		if (map == null)
			return Task.FromResult(-1L);

		long sum = 0;
		foreach (var symbol in symbols)
		{
			var adjacentNumbers = numbers.Where(number => number.IsPartOfSymbol(symbol)).ToList();
			if (adjacentNumbers.Count != 2)
				continue;
			sum += adjacentNumbers[0].Value * adjacentNumbers[1].Value;
		}
		return Task.FromResult(sum);
	}

	private void ParseMap(IEnumerable<string> input)
	{

		map = input.Select(line => line.ToCharArray()).ToArray();
		var width = map[0].Length;
		if (!map.All(line => line.Length == width))
			throw new ArgumentException("Map is not rectangular");

		symbols.Clear();
		numbers.Clear();

		int numberStart = -1;
		for (var y = 0; y <= Height; y++)
		{
			if (numberStart >= 0)
			{
				var value = int.Parse(new string(map[y - 1][numberStart..(map[y - 1].Length)]));
				numbers.Add(new Number { Value = value, Y = y - 1, XStart = numberStart, XEnd = map[y - 1].Length-1 });
				numberStart = -1;
			}

			for (var x = 0; x <= Width; x++)
			{
				if (char.IsDigit(map[y][x]))
				{
					if (numberStart < 0)
					{
						numberStart = x;
					}
				}
				else if (numberStart >= 0)
				{
					var value = int.Parse(new string(map[y][numberStart..x]));
					numbers.Add(new Number { Value = value, Y = y, XStart = numberStart, XEnd = x-1 });
					numberStart = -1;
				}

				if (!char.IsDigit(map[y][x]) && map[y][x] != '.')
					symbols.Add((y, x));
			}
		}
	}

	private int Width => this.map?[0].Length - 1 ?? 0;

	private int Height => this.map?.Length - 1 ?? 0;
}

class Number
{

	public int Value { get; init; }

	public int Y { get; init; }

	public int XStart { get; init; }

	public int XEnd { get; init; }

	public bool IsPartOfSymbols(List<(int, int)> symbols)
	{
		return symbols.Any(IsPartOfSymbol);
	}

	public bool IsPartOfSymbol((int y, int x) sympos)
	{
		return Math.Abs(sympos.y - Y) < 2 && sympos.x >= XStart - 1 && sympos.x <= XEnd + 1;
	}

	public int Length => XEnd - XStart;

}
