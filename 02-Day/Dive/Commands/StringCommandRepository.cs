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

            var matches = Regex.Matches(_rawData.ToLower(), @"((forward|up|down)(\s+)?\d+)");

            foreach (Match match in matches) 
            {
                var type = ReadType(match.Value);
                var step = ReadStep(match.Value);
                moveCommandParams.Add(new MoveCommandParam(type, step));
            }    

            return moveCommandParams;
        }

        private MoveCommandType ReadType(string value)
        {
            if (value.Contains("forward"))
                return MoveCommandType.Forward;

            if(value.Contains("up"))
                return MoveCommandType.Up;

            if(value.Contains("down"))
                return MoveCommandType.Down;

            throw new InvalidOperationException("Invalid command");
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