namespace SonarSweep
{
    public class SinkingSpeedCalculator
    {
        public int Calculate(string report)
        {
            var measurements = ParseMeasurementsFrom(report);
            return CalculeSpeed(measurements);
        }

        private static int CalculeSpeed(IList<int> measurements)
        {
            var increments = 0;
            for (int i = 0; i < measurements.Count() - 1; i++)
            {
                var currentMeasurement = measurements.ElementAt(i);
                var nextMeasurement = measurements.ElementAt(i + 1);
                if (currentMeasurement < nextMeasurement)
                    increments++;
            }

            return increments;
        }

        private static IList<int> ParseMeasurementsFrom(string report) => report.Split(' ').Select(strNum => (int.Parse(strNum))).ToList();
    }
}