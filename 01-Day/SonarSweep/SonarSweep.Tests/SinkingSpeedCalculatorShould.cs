using FluentAssertions;
using NUnit.Framework;
using System;

namespace SonarSweep.Tests
{
    [TestFixture]
    public class SinkingSpeedCalculatorShould
    {
        private SinkingSpeedCalculator calculator => _calculator ?? throw new InvalidOperationException("not initialized");
        private SinkingSpeedCalculator? _calculator;
        [SetUp]
        public void SetUp()
        {
            _calculator = new SinkingSpeedCalculator();
        }

        [Test]
        public void be_0_when_report_has_a_single_measurement()
        {
            const string aGivenReport = "199";

            var depthIncreases = calculator.Calculate(aGivenReport);

            depthIncreases.Should().Be(0);
        }
        [Test]
        public void be_1_when_report_has_one_increment()
        {
            const string aGivenReport = "199 200";

            var depthIncreases = calculator.Calculate(aGivenReport);

            depthIncreases.Should().Be(1);
        }
        [Test]
        public void be_0_when_the_depth_does_not_increase()
        {
            const string aGivenReport = "199 198 197";

            var depthIncreases = calculator.Calculate(aGivenReport);

            depthIncreases.Should().Be(0);
        }
    }
}
