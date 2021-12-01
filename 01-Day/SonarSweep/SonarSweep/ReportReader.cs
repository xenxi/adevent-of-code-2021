using System.Text.RegularExpressions;

namespace SonarSweep
{
    public class ReportReader
    {
        public IList<int> ParseMeasurementsFrom(string? report)
        {
            var matches = Regex.Matches(report ?? String.Empty, @"\d+").Where(match => match.Success).Select(match => match.Value);
            return matches.Select(match => int.Parse(match)).ToList();
        }
    }
}