namespace Dive.Commands
{
    public class MoveCommandParam
    {
        public MoveCommandParam(MoveCommandType type, int step)
        {
            Type = type;
            Step = step;
        }

        public MoveCommandType Type { get; }
        public int Step { get; }
    }
}
