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
            => input.Split(',', options: StringSplitOptions.RemoveEmptyEntries).Select(strNumber => int.Parse(strNumber));

        public int? Next()
        {
            if (!iterator.MoveNext())
                throw new InvalidOperationException();

            return iterator.Current;
        }
    }
}