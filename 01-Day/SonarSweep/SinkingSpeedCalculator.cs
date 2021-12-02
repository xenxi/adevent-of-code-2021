namespace SonarSweep
{
    public class SinkingSpeedCalculator
    {
        private readonly ReportReader _reader = new ReportReader();
        public int Calculate(string report, int slideWindow = 0)
        {
            var measurements = _reader.ParseMeasurementsFrom(report);

            if(measurements.Count <= slideWindow)
                return 0;
            if (slideWindow > 0)
            {
                var slideMeasurements = Slide(measurements, slideWindow);
                return CalculeSpeed(slideMeasurements);
            }
            return CalculeSpeed(measurements);
        }

        private IList<int> Slide(IList<int> measurements, int slideWindow)
        {
            var index = 0;
            return measurements
                .Select(measurement 
                    => measurements
                        .Skip(index++)
                        .Take(slideWindow).Sum())
                .ToList();
        }

        private static int CalculeSpeed(IList<int> measurements)
        {
            var increments = 0;
            for (int i = 0; i < measurements.Count - 1; i++)
            {
                var currentMeasurement = measurements.ElementAt(i);
                var nextMeasurement = measurements.ElementAt(i + 1);
                if (currentMeasurement < nextMeasurement)
                    increments++;
            }

            return increments;
        }

       
    }
}