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

            var depthIncreases = calculator.Calculate(aGivenReport);

            depthIncreases.Should().Be(7);
        }

        [Test]
        public void calculate_depth_increments_when_report_has_sliding()
        {
            var calculator = new SinkingSpeedCalculator();
            const string aGivenReport = "199  A      \r\n200  A B    \r\n208  A B C  \r\n210    B C D\r\n200  E   C D\r\n207  E F   D\r\n240  E F G  \r\n269    F G H\r\n260      G H\r\n263        H";
            const int aGivenSlideWindows = 3;

            var depthIncreases = calculator.Calculate(aGivenReport, slideWindow: aGivenSlideWindows);

            depthIncreases.Should().Be(5);
        }
    }
}
