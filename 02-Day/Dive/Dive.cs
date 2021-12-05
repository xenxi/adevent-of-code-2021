namespace Dive
{
    public class Dive
    {
        private int _depth = 0;
        private int _horizontal = 0;

        public int BroadcastLocator()
        {
            return _horizontal * _depth;
        }

        public void Down(int step)
        {
            _depth += step;
        }

        public void Forward(int step)
        {
            _horizontal += step;
        }
        public void Up(int step)
        {
            _depth -= step;
        }
    }
}