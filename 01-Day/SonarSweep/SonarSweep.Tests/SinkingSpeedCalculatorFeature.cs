using FluentAssertions;
using NUnit.Framework;

namespace SonarSweep.Tests
{

    [TestFixture]
    public class SinkingSpeedCalculatorFeature
    {
        [Test]
        public void calculate_depth_increments()
        {
            var calculator = new SinkingSpeedCalculator();
            const string aGivenReport = "199 200 208 210 200 207 240 269 260 263 ";

            var depthIncreases = calculator.CalculateIncrement(aGivenReport);

            depthIncreases.Should().Be(7);
        }
    }
}
