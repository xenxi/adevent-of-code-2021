namespace BinaryDiagnostic
{
    public class BinaryNumber
    {
        public BinaryNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static BinaryNumber From(IEnumerable<char> chars) => new BinaryNumber(new string(chars.ToArray()));

        public BinaryNumber At(int index) => BinaryNumber.From(Value[index]);

        public BinaryNumber Invert() => new BinaryNumber(new string(Value.Select(x => InvertBinary(x)).ToArray()));

        public int ToInt() => Convert.ToInt32(Value, 2);

        private static BinaryNumber From(char character) => new BinaryNumber(character.ToString());

        private static char InvertBinary(char x) => x == '0' ? '1' : '0';
    }
}