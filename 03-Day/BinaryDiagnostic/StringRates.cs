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
            var filterLines = _lines.ToList();
            var columnIndex = 0;
            while (filterLines.Count > 1)
            {
                var mainBit = GetFlattenBinaryNumber(filterLines.ToArray(), '1');
                var filterCharacter = mainBit[columnIndex];
                var invertFilterCharacter = filterCharacter == '1' ? '0' : '1';
                filterLines = filterLines.Where(line => line[columnIndex] == invertFilterCharacter).ToList();
                columnIndex++;
            }
            return ConvertBinaryToInt(filterLines.First());
        }

        public int GetEpsilon()
        {
            string invert = InvertBinary(FlattenBinaryNumber);
            return ConvertBinaryToInt(invert);
        }

        private string InvertBinary(string binary) => new string(binary.Select(x => x == '0' ? '1' : '0').ToArray());

        public int GetGamma() => ConvertBinaryToInt(FlattenBinaryNumber);

        public int GetOxygenGenerator()
        {
            var filterLines = _lines.ToList();
            var columnIndex = 0;
            while (filterLines.Count > 1)
            {
                var mainBit = GetFlattenBinaryNumber(filterLines.ToArray(), '1');
                var filterCharacter = mainBit[columnIndex];
                filterLines = filterLines.Where(line => line[columnIndex] == filterCharacter).ToList();
                columnIndex++;
            }
            return ConvertBinaryToInt(filterLines.First());
        }

        private static string[] GetLines(string input)
        {
            var separator = new string[] { "\r\n", "\n" };
            var lines = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }

        private static char MostRepeated(IEnumerable<char> enumerable, char? sortChar)
        {
            var result = enumerable
                           .GroupBy(c => c)
                           .OrderByDescending(g => g.Count());
            var distinct = result.Select(c => c.Count()).Distinct().Count();
            if (distinct == 1 && sortChar.HasValue)
                result = result.OrderByDescending(g => g.Key == sortChar.Value);

            return result.First().Key;
        }

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

        private string GetFlattenBinaryNumber(string[] lines, char? sortChar = null)
        {
            var columns = ReadCharacterInColumns(lines);

            var flatCharacters = columns.Select(column => MostRepeated(column, sortChar));

            return new string(flatCharacters.ToArray());
        }
    }
}