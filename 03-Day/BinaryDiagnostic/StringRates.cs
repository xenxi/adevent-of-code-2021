namespace BinaryDiagnostic
{
    public class StringRates : Rates
    {
        public StringRates(string input)
        {
            FlattenBinaryNumber = GetFlattenBinaryNumber(input);
        }

        private string GetFlattenBinaryNumber(string input)
        {
            return input;
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
    }
}
