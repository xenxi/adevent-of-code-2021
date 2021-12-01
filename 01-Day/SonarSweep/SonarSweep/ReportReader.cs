namespace SonarSweep
{
    public class ReportReader
    {
        public IList<int> ParseMeasurementsFrom(string? report)
        {
            if (report == null || report.Length == 0)
                return new List<int>();

            var strMeasurements = report.Split(' ');
            return ReadNumbers(strMeasurements);
        }

        private static IList<int> ReadNumbers(string[] strMeasurements)
        {
            List<int> measurements = new List<int>();
            foreach (var strMeasurement in strMeasurements)
            {
                if(int.TryParse(strMeasurement, out var measurement))
                    measurements.Add(measurement);
            }
            return measurements;
        }
    }
}