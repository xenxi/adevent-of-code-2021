using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace BinaryDiagnostic.Tests
{
    [TestFixture]
    public class HealthCheckerShould
    {
        [Test]
        public void search_gamma_rate()
        {
            var repository = Substitute.For<Rates>();
            var checker = new HealthChecker(repository);

            checker.GenerateReport();

            repository.Received(1).GetGamma();
        }

        [Test]
        public void search_epsilon_rate()
        {
            var repository = Substitute.For<Rates>();
            var checker = new HealthChecker(repository);

            checker.GenerateReport();

            repository.Received(1).GetEpsilon();
        }

        [TestCase(1,1,1)]
        [TestCase(2,2,4)]
        [TestCase(0,44,0)]
        public void calcule_energy_consumption(int gamma, int epsilon, int expectedPowerConsumption)
        {
            var repository = Substitute.For<Rates>();
            var checker = new HealthChecker(repository);
            repository.GetEpsilon().Returns(epsilon);
            repository.GetGamma().Returns(gamma);

            var report = checker.GenerateReport();

            report.PowerConsumption.Should().Be(expectedPowerConsumption);
        }

    }
}
