namespace GiantSquid
{
    public class StringRandomNumberGenerator : RandomNumberGenerator
    {
        private readonly string input;
        private readonly IEnumerable<int> numbers;
        private readonly IEnumerator<int> iterator;

        public StringRandomNumberGenerator(string input)
        {
            this.input = input;

            numbers = GetNumbers(input);

            iterator = numbers.GetEnumerator();
        }

        private static IEnumerable<int> GetNumbers(string input) 
            => input.Split(',', options: StringSplitOptions.RemoveEmptyEntries).Select(strNumber => int.Parse(strNumber));

        public int? Next()
        {
            iterator.MoveNext();
            return iterator.Current;
        }
    }
}