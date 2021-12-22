using FluentAssertions;
using NUnit.Framework;

namespace GiantSquid.Tests
{
    public class StringRandomNumberGeneratorShould
    {
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("5", 5)]
        public void return_number_given_in_string_with_one_number(string input, int expectedNumber)
        {
            var generator = new StringRandomNumberGenerator(input);

            var number = generator.Next();

            number.Should().Be(expectedNumber);
        }

    }
}
