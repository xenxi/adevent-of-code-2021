namespace BinaryDiagnostic
{
    public class StringRates : Rates
    {
        private readonly string _rawInput;

        public StringRates(string input)
        {
            _rawInput = input;

            Flatten = input;
        }

        public string Flatten { get; }

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
