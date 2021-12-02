using System.Text.RegularExpressions;

namespace SonarSweep
{
    public class ReportReader
    {
        public IList<int> ParseMeasurementsFrom(string? report)
        {
            var strNumbers = GetStrNumbers(report ?? string.Empty);
            return strNumbers.Select(match => int.Parse(match)).ToList();
        }

        private static IEnumerable<string> GetStrNumbers(string report) 
            => Regex.Matches(report, @"\d+")
                .Where(match => match.Success)
                .Select(match => match.Value);
    }
}