using FluentAssertions;
using NUnit.Framework;
using System;

namespace GiantSquid.Tests
{
    public class StringRandomNumberGeneratorShould
    {
        [TestCase("1\r\n\r\n22 15",1)]
        [TestCase("2\r\n33,22",2)]
        [TestCase("21\n33,22",21)]
        public void read_only_first_line_of_string(string input,  int expectedNumber)
        {
            var generator = new StringRandomNumberGenerator(input);

            generator.Next().Should().Be(expectedNumber);
            Action action = () => generator.Next();
            action.Should().Throw<Exception>();
        }

        [TestCase("2,5,1,2,3d,8", 2, 5,1,3,2,8)]
        [TestCase("2,5,1,asdf,3d,8", 2, 5,1,3,8)]
        public void ignore_numbers_with_invalid_format(string input, params int[] expectedNumbers)
        {
            var generator = new StringRandomNumberGenerator(input);

            foreach (var expectedNumber in expectedNumbers)
                generator.Next().Should().Be(expectedNumber);
        }
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
        public void return_numbers_sequentially_given_in_string_separated_by_commas(string input, params int[] expectedNumbers)
        {
            var generator = new StringRandomNumberGenerator(input);

            foreach (var expectedNumber in expectedNumbers)
                generator.Next().Should().Be(expectedNumber);
        }

        [Test]
        public void not_allow_request_a_number_when_there_are_no_numbers_left_unused()
        {
            var generator = new StringRandomNumberGenerator("1");
            generator.Next();

            Action action = () => generator.Next();

            action.Should().Throw<InvalidOperationException>();
        }


    }
}
