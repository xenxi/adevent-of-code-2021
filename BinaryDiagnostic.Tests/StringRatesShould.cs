﻿using FluentAssertions;
using NUnit.Framework;

namespace BinaryDiagnostic.Tests
{
    [TestFixture]
    public class StringRatesShould
    {
        [TestCase("00", "00")]
        [TestCase("11", "11")]
        [TestCase("11\r\n11\r\n00", "11")]
        public void flatten_input_leaving_the_most_repeated_digit_in_each_column(string input, string expectedFlattenBinary)
        {
            var rates = new StringRates(input);

            rates.FlattenBinaryNumber.Should().Be(expectedFlattenBinary);
        }

    }
}