namespace BinaryDiagnostic
{
    public class StringRates : Rates
    {
        public StringRates(string input)
        {
            FlattenBinaryNumber = GetFlattenBinaryNumber(input);
        }

        public string FlattenBinaryNumber { get; }

        public int GetEpsilon()
        {
            var invert = new string(FlattenBinaryNumber.Select(x => x == '0' ? '1' : '0').ToArray());
            return ConvertBinaryToInt(invert);
        }

        public int GetGamma() => ConvertBinaryToInt(FlattenBinaryNumber);

        private int ConvertBinaryToInt(string binaryNumber)
        {
            return Convert.ToInt32(binaryNumber, 2);
        }

        private string GetFlattenBinaryNumber(string input)
        {
            var lines = ReadCharacterInColumns(input);

            var flatCharacters = lines.Select(line => MostRepeated(line));

            return new string(flatCharacters.ToArray());
        }

        private static IList<string> ReadCharacterInColumns(string input)
        {
            var lines = input.Split(Environment.NewLine);
            var charactersGroupByColum = lines
                .SelectMany(line => line
                    .Select((Character, Column) => (Character, Column)))
                .GroupBy(line => line.Column);

            return charactersGroupByColum.Select(g => new string(g.Select(d => d.Character).ToArray())).ToList();
        }

        private static char MostRepeated(IEnumerable<char> enumerable) 
            => enumerable
                .GroupBy(c => c)
                .OrderByDescending(g => g.Count())
                .First().Key;
    }
}