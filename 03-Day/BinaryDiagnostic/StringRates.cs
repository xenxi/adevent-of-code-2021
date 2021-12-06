namespace BinaryDiagnostic
{
    public class StringRates : Rates
    {
        private readonly string[] _lines;

        public StringRates(string input)
        {
            _lines = GetLines(input);

            FlattenBinaryNumber = GetFlattenBinaryNumber(_lines);
        }

        public string FlattenBinaryNumber { get; }

        public int GetCo2Scrubber()
        {
            return 0;
        }

        public int GetEpsilon()
        {
            var invert = new string(FlattenBinaryNumber.Select(x => x == '0' ? '1' : '0').ToArray());
            return ConvertBinaryToInt(invert);
        }

        public int GetGamma() => ConvertBinaryToInt(FlattenBinaryNumber);

        public int GetOxygenGenerator()
        {
            return 0;
        }

        private static string[] GetLines(string input)
        {
            var separator = new string[] { "\r\n", "\n" };
            var lines = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }

        private static char MostRepeated(IEnumerable<char> enumerable)
            => enumerable
                .GroupBy(c => c)
                .OrderByDescending(g => g.Count())
                .First().Key;

        private static IList<string> ReadCharacterInColumns(string[] lines)
        {
            var charactersGroupByColum = lines
                .SelectMany(line => line
                    .Select((Character, Column) => (Character, Column)))
                .GroupBy(line => line.Column);

            return charactersGroupByColum.Select(g => new string(g.Select(d => d.Character).ToArray())).ToList();
        }

        private int ConvertBinaryToInt(string binaryNumber)
        {
            return Convert.ToInt32(binaryNumber, 2);
        }

        private string GetFlattenBinaryNumber(string[] lines)
        {
            var columns = ReadCharacterInColumns(lines);

            var flatCharacters = columns.Select(column => MostRepeated(column));

            return new string(flatCharacters.ToArray());
        }
    }
}