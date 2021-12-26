namespace GiantSquid
{
    public class StringRandomNumberGenerator : RandomNumberGenerator
    {
        private readonly IEnumerable<int> numbers;
        private readonly IEnumerator<int> iterator;

        public StringRandomNumberGenerator(string input)
        {
            numbers = GetNumbers(input);

            iterator = numbers.GetEnumerator();
        }

        private static IEnumerable<int> GetNumbers(string input)
        {
            var stringNumbers = input.Split(',', options: StringSplitOptions.RemoveEmptyEntries);
            var numbers = stringNumbers.Select(strNumber => int.TryParse(strNumber, out var number) ? number : (int?)null);
            return numbers.Where(x => x.HasValue).Select(x => x.Value);
        }

        public int Next()
        {
            if (!iterator.MoveNext())
                throw new InvalidOperationException();

            return iterator.Current;
        }
    }
}