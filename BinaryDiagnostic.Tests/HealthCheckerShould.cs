using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace BinaryDiagnostic.Tests
{
    [TestFixture]
    public class HealthCheckerShould
    {
        private HealthChecker checker;
        private Rates repository;

        [TestCase(1, 1, 1)]
        [TestCase(2, 2, 4)]
        [TestCase(0, 44, 0)]
        public void calcule_energy_consumption(int gamma, int epsilon, int expectedPowerConsumption)
        {
            repository.GetEpsilon().Returns(epsilon);
            repository.GetGamma().Returns(gamma);

            var report = checker.GenerateReport();

            report.PowerConsumption.Should().Be(expectedPowerConsumption);
        }

        [Test]
        public void search_co2_scrubber_rate()
        {
            checker.GenerateReport();

            repository.Received(1).GetCo2Scrubber();
        }

        [Test]
        public void search_epsilon_rate()
        {
            checker.GenerateReport();

            repository.Received(1).GetEpsilon();
        }

        [Test]
        public void search_gamma_rate()
        {
            checker.GenerateReport();

            repository.Received(1).GetGamma();
        }

        [Test]
        public void search_oxygen_generator_rate()
        {
            checker.GenerateReport();

            repository.Received(1).GetOxygenGenerator();
        }
        [SetUp]
        public void SetUp()
        {
            repository = Substitute.For<Rates>();
            checker = new HealthChecker(repository);
        }
    }
}