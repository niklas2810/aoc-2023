namespace AOC2023.Logic.Days;

public class Day09 : DayBase
{
	public override string Name => "Mirage Maintenance";

	public override Task<long> SolvePartOne(IEnumerable<string> input)
	{
		// Each line is a list of numbers, separated by spaces
		var result = input
			.Select(line => line.Split(" ").Select(long.Parse).ToArray())
			.Select(seq => Extrapolate(seq, true))
			.Sum();

		return Task.FromResult(result);
	}

	public override Task<long> SolvePartTwo(IEnumerable<string> input)
	{
		// Each line is a list of numbers, separated by spaces
		var result = input
			.Select(line => line.Split(" ").Select(long.Parse).ToArray())
			.Select(seq => Extrapolate(seq, false))
			.Sum();

		return Task.FromResult(result);
	}

	private static long Extrapolate(long[] seq, bool last)
	{
		var seqs = new List<long[]> { seq };

		while (seqs.Last().Any(v => v != 0))
		{
			var prev = seqs.Last();
			var currSeq = new long[prev.Length - 1];
			for (int i = 0; i < currSeq.Length; i++)
				currSeq[i] = prev[i + 1] - prev[i];
			seqs.Add(currSeq);
		}

		var extrapolated = 0L;
		for (int i = seqs.Count - 1; i >= 0; i--)
			extrapolated = seqs[i][last ? seqs[i].Length - 1 : 0] + extrapolated * (last ? 1 : -1);
		return extrapolated;
	}
}
