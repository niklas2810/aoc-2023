namespace AOC2023.Logic.Contracts;

interface IDay<TIn, TOut>
{
    public string Name { get; }

    public int DayNumber { get; }

    public abstract TIn GenerateInput(params object[] args);
    public abstract Task<TOut> SolvePartOne(TIn input);
    public abstract Task<TOut> SolvePartTwo(TIn input);
}