namespace AOC2023.Logic.Days;

public class Day07 : DayBase
{
	private static readonly List<char> VALUES = ['A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2'];
	private static readonly List<char> VALUES2 = ['A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J'];

	public override string Name => "Camel Cards";

	public override Task<long> SolvePartOne(IEnumerable<string> input)
	{
		var parsed = ParseInput(input);
		parsed.Sort((a, b) => -CompareCards(a.cards, b.cards, GetCardType, VALUES));
		return Task.FromResult(parsed.Select((v, index) => (long)v.bid * (index + 1)).Sum());
	}

	public override Task<long> SolvePartTwo(IEnumerable<string> input)
	{
		var parsed = ParseInput(input);
		parsed.Sort((a, b) => -CompareCards(a.cards, b.cards, GetCardTypeTwo, VALUES2));
		return Task.FromResult(parsed.Select((v, index) => (long)v.bid * (index + 1)).Sum());
	}

	private static List<(char[] cards, int bid)> ParseInput(IEnumerable<string> input)
	{
		return input.Select(line => (line.Split(' ')[0].ToCharArray(), int.Parse(line.Split(' ')[1]))).ToList();
	}

	private static int CompareCards(char[] cards1, char[] cards2, Func<char[], CardType> typeFunction, List<char> values)
	{
		var type1 = typeFunction.Invoke(cards1);
		var type2 = typeFunction.Invoke(cards2);

		if (type1 > type2)
			return 1;
		if (type1 < type2)
			return -1;

		for (int i = 0; i < 5; i++)
		{
			if (cards1[i] != cards2[i])
				return values.IndexOf(cards1[i]) - values.IndexOf(cards2[i]);
		}
		throw new ArgumentException("Cards are equal");
	}
	private static CardType GetCardType(char[] cards)
	{
		if (cards.Length != 5)
			throw new ArgumentException("Cards must be 5 in length");

		var groups = cards.GroupBy(c => c);
		if (groups.Any(g => g.Count() == 5))
			return CardType.FiveOfAKind;
		if (groups.Any(g => g.Count() == 4))
			return CardType.FourOfAKind;
		if (groups.Any(g => g.Count() == 3) && groups.Any(g => g.Count() == 2))
			return CardType.FullHouse;
		if (groups.Any(g => g.Count() == 3))
			return CardType.ThreeOfAKind;
		if (groups.Count(g => g.Count() == 2) == 2)
			return CardType.TwoPair;
		if (groups.Any(g => g.Count() == 2))
			return CardType.OnePair;
		return CardType.HighCard;
	}

	private static CardType GetCardTypeTwo(char[] cards)
	{
		if (cards.Length != 5)
			throw new ArgumentException("Cards must be 5 in length");

		if (!cards.Contains('J'))
			return GetCardType(cards);

		return cards
				.Select(c => new string(cards).Replace("J", new string(new[] { c })).ToCharArray())
				.Select(GetCardType)
				.Min();
	}

	enum CardType
	{
		FiveOfAKind,
		FourOfAKind,
		FullHouse,
		ThreeOfAKind,
		TwoPair,
		OnePair,
		HighCard
	}
}
