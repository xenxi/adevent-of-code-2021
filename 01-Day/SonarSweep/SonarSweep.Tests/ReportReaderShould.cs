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
            var aGivenEmptyReport = string.Empty;

            var measurements = reader.ParseMeasurementsFrom(aGivenEmptyReport);
            
            measurements.Should().BeEmpty();
        }

    }
}
