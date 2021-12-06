using FluentAssertions;
using NUnit.Framework;

namespace BinaryDiagnostic.Tests
{
    [TestFixture]
    public class StringRatesShould
    {
        [TestCase("00", "00")]
        [TestCase("11", "11")]
        [TestCase("11\r\n11\r\n00", "11")]
        [TestCase("11\n11\n00", "11")]
        public void flatten_input_leaving_the_most_repeated_digit_in_each_column(string input, string expectedFlattenBinary)
        {
            var rates = new StringRates(input);

            var flattenBinaryNumber = rates.FlattenBinaryNumber;

            flattenBinaryNumber.Should().Be(expectedFlattenBinary);
        }

        [TestCase("00", 0)]
        [TestCase("01", 1)]
        [TestCase("10", 2)]
        [TestCase("11", 3)]
        [TestCase("1111", 15)]
        public void return_gamma(string input, int expectedGamma)
        {
            var rates = new StringRates(input);

            var gamma = rates.GetGamma();

            gamma.Should().Be(expectedGamma);
        }

        [TestCase("00", 3)]
        [TestCase("01", 2)]
        [TestCase("10", 1)]
        [TestCase("11", 0)]
        [TestCase("1111", 0)]
        public void return_epsilon(string input, int expectedGamma)
        {
            var rates = new StringRates(input);

            var gamma = rates.GetEpsilon();

            gamma.Should().Be(expectedGamma);
        }

    }
}
