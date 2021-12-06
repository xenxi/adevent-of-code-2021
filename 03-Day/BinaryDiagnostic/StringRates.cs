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
            throw new NotImplementedException();
        }

        public int GetGamma()
        {
            return 0;
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