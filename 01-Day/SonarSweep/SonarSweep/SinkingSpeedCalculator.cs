namespace SonarSweep
{
    public class SinkingSpeedCalculator
    {
        public SinkingSpeedCalculator()
        {
        }

        public int CalculateIncrement(string report)
        {
            var measurements = report.Split(' ');
            if(measurements.Count() > 1)
                return 1;
            return 0;
        }
    }
}