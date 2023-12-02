namespace AOC2023.Cli
{
    class ConsoleUtils
    {

        public static int ReadInt(Func<int, bool> validator, int? defaultValue = null)
        {
            while(true)
            {
                if(defaultValue.HasValue)
                    Console.Write($"[{(defaultValue.HasValue ? defaultValue.Value : '?'),0}] => ");
                else
                    Console.Write("=> ");
                var input = Console.ReadLine();
                if(defaultValue.HasValue && string.IsNullOrWhiteSpace(input))
                    return defaultValue.Value;
                else if (int.TryParse(input, out var result) && validator.Invoke(result))
                    return result;
                Console.WriteLine($"Invalid input, please try again");
            }
        }
    }
}
