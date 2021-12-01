namespace SonarSweep
{
    public class ReportReader
    {
        public IList<int> ParseMeasurementsFrom(string report)
        {
            if(report.Length == 0)
                return new List<int>();
            return report.Split(' ').Select(strNum => (int.Parse(strNum))).ToList();
        }
    }
}