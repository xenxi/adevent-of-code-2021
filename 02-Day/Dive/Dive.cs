namespace Dive
{
    public abstract class Dive
    {
        public int Depth { get; protected set; } = 0;
        public int Horizontal { get; protected set; } = 0;

        public int BroadcastLocator()
        {
            return Horizontal * Depth;
        }

        public abstract void Down(int step);

        public abstract void Forward(int step);

        public abstract void Up(int step);
    }
}