namespace AOC2023.Logic.Days
{
	public class Day04 : DayBase
	{
		public override string Name => "Scratchcards";

		public override Task<long> SolvePartOne(IEnumerable<string> input)
		{
			long sum = 0;

			foreach(var card in input)
			{
				var matches = ParseCard(card).Matches;
				if(matches > 0)
					sum += (int)Math.Pow(2, matches - 1);
			}
			return Task.FromResult(sum);

		}

		

		public override Task<long> SolvePartTwo(IEnumerable<string> input)
		{
			var cards = input.Select(ParseCard).ToList();
			var instances = cards.Select(c => 1L).ToArray();

			for(int i = 0; i < cards.Count; ++i)
			{
				var card = cards[i];
				var matches = card.Matches;
				for (int j = matches; j > 0; --j)
					instances[i+j] += instances[i];
			}

			return Task.FromResult(instances.Sum());
		}

		private Card ParseCard(string card)
		{
			// Format of card is "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"
			// 1 is number, numbers before | are winning numbers, numbers after are provided numbers
			if (string.IsNullOrWhiteSpace(card))
				throw new ArgumentException("Card is empty", nameof(card));
			var prefix = card.Split(':')[0];
			var rawNum = prefix.Substring(4);
			var number = int.Parse(rawNum);
			var winning = card.Split(':')[1].Split('|')[0].Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
			var provided = card.Split(':')[1].Split('|')[1].Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
			return new Card { Number = number, WinningNumbers = winning, ProvidedNumbers = provided };
		}
	}
}

class Card
{
	public required int Number { get; init; }

	public required IEnumerable<int> WinningNumbers { get; init; }

	public required IEnumerable<int> ProvidedNumbers { get; init; }

	public int Matches => WinningNumbers.Intersect(ProvidedNumbers).Count();

}
