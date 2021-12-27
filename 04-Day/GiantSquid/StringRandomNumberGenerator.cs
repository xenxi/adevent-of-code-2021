using System.Text.RegularExpressions;

namespace GiantSquid
{
    public class StringRandomNumberGenerator : RandomNumberGenerator
    {
        private readonly IList<int> numbers;
        private readonly IEnumerator<int> iterator;

        public StringRandomNumberGenerator(string input)
        {
            numbers = GetNumbers(input);

            iterator = numbers.GetEnumerator();
        }

        private static List<int> GetNumbers(string input)
        {
            var separator = new string[] { "\r\n", "\n" };
            var firstLine = input.Split(separator, StringSplitOptions.None).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(firstLine))
                return new List<int>();
            var matches = Regex.Matches(firstLine, @"\d+");
            return matches.Select(i => int.Parse(i.Value)).ToList();
        }

        public int Next()
        {
            if (!iterator.MoveNext())
                throw new InvalidOperationException();

            return iterator.Current;
        }
    }
}