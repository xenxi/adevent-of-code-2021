using System.Text.RegularExpressions;

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
            var firstLine = input.Split(Environment.NewLine).FirstOrDefault();
            if(string.IsNullOrWhiteSpace(firstLine))
                return Enumerable.Empty<int>();
            var matches = Regex.Matches(firstLine, @"\d+");
            return matches.Select(i => int.Parse(i.Value));
        }

        public int Next()
        {
            if (!iterator.MoveNext())
                throw new InvalidOperationException();

            return iterator.Current;
        }
    }
}