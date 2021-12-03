namespace Dive.Commands
{
    public class MoveCommandParam : IEquatable<MoveCommandParam?>
    {
        public MoveCommandParam(MoveCommandType type, int step)
        {
            Type = type;
            Step = step;
        }

        public MoveCommandType Type { get; }
        public int Step { get; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as MoveCommandParam);
        }

        public bool Equals(MoveCommandParam? other)
        {
            return other != null &&
                   Type == other.Type &&
                   Step == other.Step;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Step);
        }

        public static bool operator ==(MoveCommandParam? left, MoveCommandParam? right)
        {
            return EqualityComparer<MoveCommandParam>.Default.Equals(left, right);
        }

        public static bool operator !=(MoveCommandParam? left, MoveCommandParam? right)
        {
            return !(left == right);
        }
    }
}
