namespace AOC2023;

internal interface IDay
{
    public string Name { get; }

    public int DayNumber { get; }
}
internal interface IDay<TIn, TOut> : IDay
{

    public TIn GenerateInput(params object[] args);

    public TOut SolvePartOne(TIn input);

    public TOut SolvePartTwo(TIn input);

}
