namespace GiantSquid
{
    public class StringRandomNumberGenerator : RandomNumberGenerator
    {
        private string input;

        public StringRandomNumberGenerator(string input)
        {
            this.input = input;
        }

        public int? Next()
        {
            return int.Parse(input);
        }
    }
}
