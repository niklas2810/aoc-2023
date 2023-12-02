namespace AOC2023.Contracts;

interface IDay<TIn, TOut>
{
    public string Name { get; }

    public int DayNumber { get; }

    public abstract TIn GenerateInput(params object[] args);
    public abstract TOut SolvePartOne(TIn input);
    public abstract TOut SolvePartTwo(TIn input);
}