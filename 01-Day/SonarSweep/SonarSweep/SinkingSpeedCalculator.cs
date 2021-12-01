namespace SonarSweep
{
    public class SinkingSpeedCalculator
    {
        public SinkingSpeedCalculator()
        {
        }

        public int CalculateIncrement(string aGivenReport)
        {
            var measurements = aGivenReport.Split(' ');
            if(measurements.Count() > 1)
                return 1;
            return 0;
        }
    }
}