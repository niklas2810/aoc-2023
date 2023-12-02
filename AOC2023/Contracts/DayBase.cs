
namespace AOC2023.Contracts
{
    public abstract class DayBase : IDay<IEnumerable<string>, long>
    { 
        public abstract string Name { get; }
        public int DayNumber => int.Parse(GetType().Name.Substring(3, 2));



        public IEnumerable<string> ReadFile(string filename = "input.txt")
        {
            return File.ReadAllLines(GenerateFilePath(filename));
        }

        public string GenerateFilePath(string filename)
        {
            return Path.Combine("Inputs", DayNumber.ToString("00"), filename);
        }

        public abstract IEnumerable<string> GenerateInput(params object[] args);
        public abstract long SolvePartOne(IEnumerable<string> input);
        public abstract long SolvePartTwo(IEnumerable<string> input);
    }
}
