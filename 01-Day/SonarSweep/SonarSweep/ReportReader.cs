namespace SonarSweep
{
    public class ReportReader
    {
        public IList<int> ParseMeasurementsFrom(string report) => report.Split(' ').Select(strNum => (int.Parse(strNum))).ToList();
    }
}