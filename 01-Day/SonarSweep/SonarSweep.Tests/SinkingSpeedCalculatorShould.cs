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
        public void be_0_when_number_of_measurement_is_less_than_sliding_windows()
        {
            const string aGivenReport = "199 200";

            var depthIncreases = calculator.Calculate(aGivenReport, slideWindow: 3);

            depthIncreases.Should().Be(0);
        }

        [Test]
        public void be_0_when_number_of_measurement_is_equal_than_sliding_windows()
        {
            const string aGivenReport = "199 200";

            var depthIncreases = calculator.Calculate(aGivenReport, slideWindow: 2);

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
        public void be_2_when_report_has_2_increments()
        {
            const string aGivenReport = "199 200 199 200";

            var depthIncreases = calculator.Calculate(aGivenReport);

            depthIncreases.Should().Be(2);
        }
        [Test]
        public void be_0_when_the_depth_does_not_increase()
        {
            const string aGivenReport = "199 198 197";

            var depthIncreases = calculator.Calculate(aGivenReport);

            depthIncreases.Should().Be(0);
        }

        [Test]
        public void be_5_when_the_depth_is_increased_5_times_in_windows_of_3()
        {
            const string aGivenReport = "199 200 208 210 200 207 240 269 260 263 ";

            var depthIncreases = calculator.Calculate(aGivenReport, slideWindow: 3);

            depthIncreases.Should().Be(5);
        }

    }
}
