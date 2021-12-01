using FluentAssertions;
using NUnit.Framework;

namespace SonarSweep.Tests
{
    [TestFixture]
    public class ReportReaderShould
    {
        [Test]
        public void return_empty_list_when_report_is_empty()
        {
            var reader = new ReportReader();

            var measurements = reader.ParseMeasurementsFrom(string.Empty);
            
            measurements.Should().BeEmpty();
        }

        [Test]
        public void return_empty_list_when_report_is_null()
        {
            var reader = new ReportReader();

            var measurements = reader.ParseMeasurementsFrom(null);

            measurements.Should().BeEmpty();
        }

    }
}
