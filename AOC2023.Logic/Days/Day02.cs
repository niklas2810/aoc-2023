namespace AOC2023.Logic.Days;

public class Day02 : DayBase
{
    public override string Name => "Cube Conundrum";


    public override IEnumerable<string> GenerateInput(params object[] args)
    {
        return args.Length > 0 && args[0] is string p ? ReadFile(p) : ReadFile();
    }

    public IEnumerable<Game> ParseInput(IEnumerable<string> input)
    {
        return input.Select(ParseGame);
    }

    // Generates a Game object from a line of input
    // Input example: "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
    private Game ParseGame(string input)
    {
        var gameName = int.Parse(input.Substring(5, input.IndexOf(':') - 5));
        var result = new Game(gameName);

        var parts = input.Substring(input.IndexOf(':') + 1).Split(';').Select(s => s.Trim());
        foreach (var part in parts)
        {
            var subset = new Subset();
            var colors = part.Split(',').Select(s => s.Trim());
            foreach (var color in colors)
            {
                var number = int.Parse(color.Split(' ')[0]);
                var name = color.Split(' ')[1];
                switch (name)
                {
                    case "red":
                        subset.Red = number;
                        break;
                    case "green":
                        subset.Green = number;
                        break;
                    case "blue":
                        subset.Blue = number;
                        break;
                }
            }
            result.Subsets.Add(subset);
        }
        return result;
    }

    public override long SolvePartOne(IEnumerable<string> input)
    {
        const int MaxRed = 12;
        const int MaxGreen = 13;
        const int MaxBlue = 14;

        return ParseInput(input).Where(game => game.MaxRed <= MaxRed && game.MaxGreen <= MaxGreen && game.MaxBlue <= MaxBlue).Sum(game => game.Id);
    }


    public override long SolvePartTwo(IEnumerable<string> input)
    {
        return ParseInput(input).Sum(game => game.MaxRed * game.MaxGreen * game.MaxBlue);
    }
}

public class Game
{
    public Game(int id)
    {
        Id = id;
    }

    public int Id { get; }
    public List<Subset> Subsets { get; } = [];

    public int MaxRed => Subsets.Max(s => s.Red);

    public int MaxGreen => Subsets.Max(s => s.Green);

    public int MaxBlue => Subsets.Max(s => s.Blue);
}

public class Subset
{
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
}