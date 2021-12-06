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

        [Test]
        public void calcule_energy_consumption()
        {
            var repository = Substitute.For<Rates>();
            var checker = new HealthChecker(repository);
            repository.GetEpsilon().Returns(1);
            repository.GetGamma().Returns(1);

            var report = checker.GenerateReport();

            report.PowerConsumption.Should().Be(1);
        }

    }
}
