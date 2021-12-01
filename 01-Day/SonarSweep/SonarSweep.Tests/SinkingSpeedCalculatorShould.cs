using FluentAssertions;
using NUnit.Framework;

namespace SonarSweep.Tests
{
    [TestFixture]
    public class SinkingSpeedCalculatorShould
    {
        [Test]
        public void be_0_when_report_has_a_single_measurement()
        {
            var calculator = new SinkingSpeedCalculator();
            const string aGivenReport = "199";

            var depthIncreases = calculator.CalculateIncrement(aGivenReport);

            depthIncreases.Should().Be(0);
        }

    }
}
