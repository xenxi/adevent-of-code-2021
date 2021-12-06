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
            var lines = input.Split(Environment.NewLine).SelectMany(line => line.Select((c, index) => new { character = c, column = index}));

            var invertInput = lines.GroupBy(line => line.column).Select(g => MostRepeated(g.Select(d => d.character))).ToArray();


            return new string(invertInput);
        }

        private char MostRepeated(IEnumerable<char> enumerable) 
            => enumerable
                .GroupBy(c => c)
                .OrderByDescending(g => g.Count())
                .First().Key;
    }
}