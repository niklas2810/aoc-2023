namespace AOC2023.Logic.Days;

public class Day11 : DayBase
{
	public override string Name => "Cosmic Expansion";

	public override Task<long> SolvePartOne(IEnumerable<string> input)
	{
		var galaxies = GenerateGalaxies(input, 1);
		return Task.FromResult(CalculateDistances(galaxies));
	}

	public override Task<long> SolvePartTwo(IEnumerable<string> input)
	{
		var galaxies = GenerateGalaxies(input, 1_000_000-1);
		return Task.FromResult(CalculateDistances(galaxies));
	}

	private long CalculateDistances(List<(long, long)> galaxies)
	{
		var distances = 0L;
		// Calculate manhattan distance between each galaxy
		for (var i = 0; i < galaxies.Count; ++i)
		{
			for (var j = i + 1; j < galaxies.Count; ++j)
			{
				var (x1, y1) = galaxies[i];
				var (x2, y2) = galaxies[j];
				distances += Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
			}
		}

		return distances;
	}

	private List<(long, long)> GenerateGalaxies(IEnumerable<string> input, long scalingFactor)
	{
		// The map includes empty space (.) and galaxies (#)
		// Any rows or columns that contain no galaxies should all actually be twice as big.
		char[][] map = input.Select(x => x.ToCharArray()).ToArray();

		// Collect all the galaxies
		var galaxies = new List<(long x, long y)>();
		for (int y = 0; y < map.Length; y++)
			for (int x = 0; x < map[y].Length; x++)
				if (map[y][x] == '#')
					galaxies.Add((x, y));

		// Collect all empty rows and columns
		var emptyRows = new List<long>();
		for (int y = 0; y < map.Length; y++)
			if (!map[y].Contains('#'))
				emptyRows.Add(y);

		var emptyCols = new List<long>();
		for (int x = 0; x < map[0].Length; x++)
			if (!map.Select(row => row[x]).Contains('#'))
				emptyCols.Add(x);

		// For each empty column before galaxy, add 1 to x
		// For each empty row before galaxy, add 1 to y
		for (var i = 0; i < galaxies.Count; ++i)
		{
			(var x, var y) = galaxies[i];
			var dx = 0L;
			var dy = 0L;
			foreach (var col in emptyCols.Where(c => c < x))
				dx += scalingFactor;
			foreach (var row in emptyRows.Where(r => r < y))
				dy += scalingFactor;
			galaxies[i] = (x + dx, y + dy);
		}

		return galaxies;
	}
}
