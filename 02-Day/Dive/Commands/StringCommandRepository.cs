using System.Text.RegularExpressions;

namespace Dive.Commands
{
    public class StringCommandRepository : CommandRepository
    {
        private readonly string _rawData;

        public StringCommandRepository(string? data)
        {
            _rawData = data ?? string.Empty;
        }

        public IList<MoveCommandParam> GetAll()
        {
            var moveCommandParams = new List<MoveCommandParam>();
            MatchForward(moveCommandParams);
            MatchUp(moveCommandParams);
            MatchDown(moveCommandParams);

            return moveCommandParams;
        }

        private void MatchDown(List<MoveCommandParam> moveCommandParams)
        {
            var match = Regex.Match(_rawData, @"(down(\s+)?\d+)", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                int step = ReadStep(match.Value);
                moveCommandParams.Add(new MoveCommandParam(MoveCommandType.Down, step));
            }
        }

        private static int ReadStep(string input)
        {
            var match = Regex.Match(input, @"\d+");
            return int.Parse(match.Value);
        }

        private void MatchForward(List<MoveCommandParam> moveCommandParams)
        {
            var match = Regex.Match(_rawData, @"(forward(\s+)?\d+)", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                int step = ReadStep(match.Value);
                moveCommandParams.Add(new MoveCommandParam(MoveCommandType.Forward, step));
            }
        }

        private void MatchUp(List<MoveCommandParam> moveCommandParams)
        {
            var match = Regex.Match(_rawData, @"(up(\s+)?\d+)", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                int step = ReadStep(match.Value);
                moveCommandParams.Add(new MoveCommandParam(MoveCommandType.Up, step));
            }
        }
    }
}