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
            throw new NotImplementedException();
        }

        private string GetFlattenBinaryNumber(string input)
        {
            var lines = ReadCharacterInColumns(input);

            var invertInput = lines.GroupBy(line => line.Column).Select(g => MostRepeated(g.Select(d => d.Character))).ToArray();


            return new string(invertInput);
        }

        private static IList<(char Character, int Column)> ReadCharacterInColumns(string input)
        {
            var lines = input.Split(Environment.NewLine);
            var chartersWithColumnIndex = lines.SelectMany(line => line.Select((Character, Column) => (Character, Column)));

            return chartersWithColumnIndex.ToList();
        }

        private char MostRepeated(IEnumerable<char> enumerable) 
            => enumerable
                .GroupBy(c => c)
                .OrderByDescending(g => g.Count())
                .First().Key;
    }
}