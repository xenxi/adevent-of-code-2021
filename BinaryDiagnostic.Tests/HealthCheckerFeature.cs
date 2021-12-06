using FluentAssertions;
using NUnit.Framework;

namespace BinaryDiagnostic.Tests
{
    [TestFixture]
    public class HealthCheckerFeature
    {
        [Test]
        public void generate_submarine_power_consumption_report()
        {
            const string input = "00100\r\n11110\r\n10110\r\n10111\r\n10101\r\n01111\r\n00111\r\n11100\r\n10000\r\n11001\r\n00010\r\n01010";
            var repository = new StringRates(input);
            var cheker = new HealthChecker(repository);

            var powerConsumption = cheker.GenerateReport().PowerConsumption;

            powerConsumption.Should().Be(198);
        }

        [Test]
        public void generate_submarine_life_support_report()
        {
            const string input = "00100\r\n11110\r\n10110\r\n10111\r\n10101\r\n01111\r\n00111\r\n11100\r\n10000\r\n11001\r\n00010\r\n01010";
            var repository = new StringRates(input);
            var cheker = new HealthChecker(repository);

            var lifeSupport = cheker.GenerateReport().LifeSupport;

            lifeSupport.Should().Be(230);
        }
    }
}