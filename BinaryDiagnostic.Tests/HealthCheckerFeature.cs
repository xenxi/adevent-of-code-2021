using FluentAssertions;
using NUnit.Framework;

namespace BinaryDiagnostic.Tests
{
    [TestFixture]
    public class HealthCheckerFeature
    {
        private HealthChecker _cheker;
        [SetUp]
        public void SetUp()
        {
            const string input = "00100\r\n11110\r\n10110\r\n10111\r\n10101\r\n01111\r\n00111\r\n11100\r\n10000\r\n11001\r\n00010\r\n01010";
            var repository = new StringRates(input);
            _cheker = new HealthChecker(repository);
        }
            
        [Test]
        public void generate_submarine_power_consumption_report()
        {
            var powerConsumption = _cheker.GenerateReport().PowerConsumption;

            powerConsumption.Should().Be(198);
        }

        [Test]
        public void generate_submarine_life_support_report()
        {
            var lifeSupport = _cheker.GenerateReport().LifeSupport;

            lifeSupport.Should().Be(230);
        }
    }
}