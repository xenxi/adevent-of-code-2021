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
            var binary = FilterByBitCriteria(true);
            return ConvertBinaryToInt(binary);
        }

        public int GetEpsilon()
        {
            string invert = InvertBinary(FlattenBinaryNumber);
            return ConvertBinaryToInt(invert);
        }

        public int GetGamma() => ConvertBinaryToInt(FlattenBinaryNumber);

        public int GetOxygenGenerator()
        {
            var binary = FilterByBitCriteria(false);
            return ConvertBinaryToInt(binary);
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
                .ThenByDescending(g => g.Key == '1')
                .First().Key;

        private static IList<string> ReadCharacterInColumns(string[] lines)
        {
            var charactersGroupByColum = lines
                .SelectMany(line => line
                    .Select((Character, Column) => (Character, Column)))
                .GroupBy(line => line.Column);

            return charactersGroupByColum.Select(g => new string(g.Select(d => d.Character).ToArray())).ToList();
        }

        private int ConvertBinaryToInt(string binaryNumber) => Convert.ToInt32(binaryNumber, 2);

        private string FilterByBitCriteria(bool invertCursorCharacter)
        {
            var filterLines = _lines.ToList();
            var columnIndex = 0;
            while (filterLines.Count > 1)
            {
                var mainBit = GetFlattenBinaryNumber(filterLines.ToArray());
                var filterCharacter = mainBit[columnIndex];
                if (invertCursorCharacter)
                    filterCharacter = InvertBinary(filterCharacter);
                filterLines = filterLines.Where(line => line[columnIndex] == filterCharacter).ToList();
                columnIndex++;
            }
            return filterLines.First();
        }
        private string GetFlattenBinaryNumber(string[] lines)
        {
            var columns = ReadCharacterInColumns(lines);

            var flatCharacters = columns.Select(column => MostRepeated(column));

            return new string(flatCharacters.ToArray());
        }

        private string InvertBinary(string binary) => new string(binary.Select(x => InvertBinary(x)).ToArray());

        private static char InvertBinary(char x) => x == '0' ? '1' : '0';
    }
}