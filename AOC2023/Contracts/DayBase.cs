
namespace AOC2023.Contracts
{
    public abstract class DayBase<TIn, TOut> : IDay
    { 
        public abstract string Name { get; }
        public int DayNumber => int.Parse(GetType().Name.Substring(3, 2));

        public abstract TIn GenerateInput(params object[] args);
        public abstract TOut SolvePartOne(TIn input);
        public abstract TOut SolvePartTwo(TIn input);

        public IEnumerable<string> ReadFile(string filename = "input.txt")
        {
            return File.ReadAllLines(GenerateFilePath(filename));
        }

        public string GenerateFilePath(string filename)
        {
            return Path.Combine("Inputs", DayNumber.ToString("00"), filename);
        }
    }
}
