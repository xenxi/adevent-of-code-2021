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
        [TestCase("1,2", 1,2)]
        [TestCase("2,5,1,2", 2, 5, 1, 2)]
        [TestCase("5,5,8,55,12", 5, 5, 8, 55, 12)]
        public void return_numbers_given_in_string_with_one_number(string input, params int[] expectedNumbers)
        {
            var generator = new StringRandomNumberGenerator(input);

            foreach (var expectedNumber in expectedNumbers)
                generator.Next().Should().Be(expectedNumber);
        }
    }
}
