namespace SonarSweep
{
    public class SinkingSpeedCalculator
    {
        public int CalculateIncrement(string report)
        {
            var measurements = report.Split(' ').Select(strNum => (int.Parse(strNum)));
            var increments = 0;
            for (int i = 0; i < measurements.Count() - 1; i++)
            {
                var currentMeasurement = measurements.ElementAt(i);
                var nextMeasurement = measurements.ElementAt(i + 1);
                if(currentMeasurement < nextMeasurement)
                    increments++;
            }

            return increments;
        }
    }
}