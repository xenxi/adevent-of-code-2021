namespace BinaryDiagnostic
{
    public class StringRates : Rates
    {
        private readonly string _rawInput;

        public StringRates(string input)
        {
            _rawInput = input;

            FlattenBinaryNumber = input;
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
