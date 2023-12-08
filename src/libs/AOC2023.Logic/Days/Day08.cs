namespace AOC2023.Logic.Days
{
	public class Day08 : DayBase
	{
		public override string Name => "Haunted Wasteland";

		public override Task<long> SolvePartOne(IEnumerable<string> input)
		{
			var (directions, map) = Parse(input);
			var result = new Solver(directions, map, "AAA", true).SolveFull();
			return Task.FromResult(result);
		}

		public override Task<long> SolvePartTwo(IEnumerable<string> input)
		{
			var (directions, map) = Parse(input);
			var result = map.Keys
				.Where(k => k.EndsWith('A'))
				.Select(k => new Solver(directions, map, k, false).SolveFull())
				.Aggregate(LeastCommonMultiple);
			return Task.FromResult(result);
		}

		private static long LeastCommonMultiple(long a, long b)
		{
			// https://en.wikipedia.org/wiki/Least_common_multiple....
			return a * b / GreatedCommonDivisor(a, b);
		}

		private static long GreatedCommonDivisor(long a, long b)
		{
			// Calculate greated common divisor via euclidean algorithm
			while (b != 0)
			{
				var t = b;
				b = a % b;
				a = t;
			}
			return a;
		}

		private static (char[] directions, Dictionary<string, (string, string)> map) Parse(IEnumerable<string> input)
		{
			var directions = input.ElementAt(0).ToCharArray();

			int i = 0;
			var map = new Dictionary<string, (string, string)>();
			foreach (var line in input)
			{
				if (i++ < 2)
					continue;

				var parts = line.Split("=").Select(s => s.Trim()).ToArray();
				var src = parts[0];
				var dest = parts[1][1..^1].Split(",").Select(s => s.Trim()).ToArray();
				if (dest.Length != 2)
					throw new ArgumentException("Invalid node dest " + dest);

				if (map.ContainsKey(src))
					throw new ArgumentException("Duplicate node " + src);
				map[src] = (dest[0], dest[1]);
			}

			return (directions, map);
		}

		class Solver
		{
			private readonly char[] _steps;
			private readonly Dictionary<string, (string, string)> _map;
			private readonly string _startNode;
			private readonly bool _fullMatch;
			private long stepsTaken;

			public string Current { get; internal set; } = string.Empty;
			public bool IsSolved => _fullMatch ? Current == "ZZZ" : Current.EndsWith('Z');

			public Solver(char[] steps, Dictionary<string, (string, string)> map, string startNode, bool fullMatch)
			{
				_steps = steps;
				_map = map;
				_startNode = startNode;
				_fullMatch = fullMatch;
				Reset();
			}

			public void Reset()
			{
				stepsTaken = 0;
				Current = _startNode;
			}

			public void StepAhead()
			{
				_ = _steps[stepsTaken % _steps.Length] switch
				{
					'L' => Current = _map[Current].Item1,
					'R' => Current = _map[Current].Item2,
					_ => throw new ArgumentException("Invalid direction " + _steps[stepsTaken % _steps.Length])
				};
				++stepsTaken;
			}

			public long SolveFull()
			{
				while (!IsSolved) { StepAhead(); }
				return stepsTaken;
			}
		}
	}
}
