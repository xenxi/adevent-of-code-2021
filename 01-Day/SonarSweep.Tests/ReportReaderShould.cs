using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

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

        [Test]
        public void return_empty_list_when_report_not_conains_any_number()
        {
            var reader = new ReportReader();

            var measurements = reader.ParseMeasurementsFrom("asdfasdf");

            measurements.Should().BeEmpty();
        }

        [Test]
        public void return_list_of_measurements()
        {
            var reader = new ReportReader();
            var aGivenReport = "200 1 3 24 asdf ";

            var measurements = reader.ParseMeasurementsFrom(aGivenReport);

            var expectedMeasurements = new List<int> { 200, 1, 3, 24};
            measurements.Should().BeEquivalentTo(expectedMeasurements);
        }
    }
}
