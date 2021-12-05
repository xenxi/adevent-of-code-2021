namespace Dive
{
    public abstract class Dive
    {
        protected int depth = 0;
        protected int horizontal = 0;

        public int BroadcastLocator()
        {
            return horizontal * depth;
        }

        public abstract void Down(int step);

        public abstract void Forward(int step);

        public abstract void Up(int step);
    }
}