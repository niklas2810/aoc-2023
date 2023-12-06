

namespace AOC2023.Logic.Days
{
	public class Day06 : DayBase
	{
		public override string Name => "Wait For It";

		public override Task<long> SolvePartOne(IEnumerable<string> input)
		{
			var races = ParseInput(input).ToArray();

			var sum = 1L;
			foreach((long time, long distance) race in races)
			{
				sum *= GetOptions(race.time, race.distance);
			}

			return Task.FromResult(sum);
		}

		public override Task<long> SolvePartTwo(IEnumerable<string> input)
		{
			(long time, long distance) race = ParseInputTwo(input);
			var opts = GetOptions(race.time, race.distance);
			return Task.FromResult(opts);
		}

		private long GetOptions(long time, long record)
		{
			// Time is in milliseconds
			// Distance is in millimeters
			// Speed is in millimeters per milliseconds
			// For every millisecond passed, your speed increases by 1 millimeter per millisecond.
			for (int mmPerMs = 1; mmPerMs < time; ++mmPerMs)
			{
				var timeLeft = time - mmPerMs;
				var currentDistance = mmPerMs * timeLeft;


				if (currentDistance <= record)
					continue;

				var min = mmPerMs;
				var max = time - mmPerMs;
				return max-min+1;
			}

			return 0L;
		}


		private (long, long) ParseInputTwo(IEnumerable<string> input)
		{
			var timeChars = input.ElementAt(0)[10..].ToCharArray().Where(char.IsDigit).ToArray();
			var time = long.Parse(new string(timeChars));

			var distanceChars = input.ElementAt(1)[10..].ToCharArray().Where(char.IsDigit).ToArray();
			var distance = long.Parse(new string(distanceChars));

			return (time, distance);
		}

		private IEnumerable<(long, long)> ParseInput(IEnumerable<string> input)
		{
			var times = input.ElementAt(0)[10..].Trim().Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(long.Parse).ToList();
			var distances = input.ElementAt(1)[10..].Trim().Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(long.Parse).ToList();

			for (int i = 0; i < times.Count; i++)
				yield return (times[i], distances[i]);
		}
	}
}
