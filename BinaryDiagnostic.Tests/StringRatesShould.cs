using FluentAssertions;
using NUnit.Framework;

namespace BinaryDiagnostic.Tests
{
    [TestFixture]
    public class StringRatesShould
    {
        [Test]
        public void flatten_input_leaving_the_most_repeated_digit_in_each_column()
        {
            var input = "00";

            var rates = new StringRates(input);

            rates.Flatten.Should().Be("00");
        }

    }
}
