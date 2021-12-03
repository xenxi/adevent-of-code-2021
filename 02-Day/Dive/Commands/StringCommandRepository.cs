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
            var maches = Regex.Match(_rawData, @"(down\s+\d+)", RegexOptions.IgnoreCase);

            if (maches.Success)
            {
                var step = int.Parse(maches.Value.Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());
                moveCommandParams.Add(new MoveCommandParam(MoveCommandType.Down, step));
            }
        }

        private void MatchForward(List<MoveCommandParam> moveCommandParams)
        {
            var maches = Regex.Match(_rawData, @"(forward\s+\d+)", RegexOptions.IgnoreCase);

            if (maches.Success)
            {
                var step = int.Parse(maches.Value.Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());
                moveCommandParams.Add(new MoveCommandParam(MoveCommandType.Forward, step));
            }
        }

        private void MatchUp(List<MoveCommandParam> moveCommandParams)
        {
            var maches = Regex.Match(_rawData, @"(up\s+\d+)", RegexOptions.IgnoreCase);

            if (maches.Success)
            {
                var step = int.Parse(maches.Value.Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());
                moveCommandParams.Add(new MoveCommandParam(MoveCommandType.Up, step));
            }
        }
    }
}