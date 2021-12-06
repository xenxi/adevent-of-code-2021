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

        public BinaryNumber FlattenBinaryNumber { get; }

        public int GetCo2Scrubber()
        {
            var binary = FilterByBitCriteria(true);
            return binary.ToInt();
        }

        public int GetEpsilon() => FlattenBinaryNumber.Invert().ToInt();

        public int GetGamma() => FlattenBinaryNumber.ToInt();

        public int GetOxygenGenerator()
        {
            var binary = FilterByBitCriteria(false);
            return binary.ToInt();
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

        private BinaryNumber FilterByBitCriteria(bool invertCursorCharacter)
        {
            var filterLines = _lines.ToList();
            var columnIndex = 0;
            while (filterLines.Count > 1)
            {
                var mainBit = GetFlattenBinaryNumber(filterLines.ToArray());
                var filterCharacter = mainBit.At(columnIndex);
                if (invertCursorCharacter)
                    filterCharacter = filterCharacter.Invert();
                filterLines = filterLines.Where(line => line[columnIndex] == filterCharacter.Value[0]).ToList();
                columnIndex++;
            }
            return new BinaryNumber(filterLines.First());
        }

        private BinaryNumber GetFlattenBinaryNumber(string[] lines)
        {
            var columns = ReadCharacterInColumns(lines);

            var flatCharacters = columns.Select(column => MostRepeated(column));

            return BinaryNumber.From(flatCharacters);
        }
    }
}