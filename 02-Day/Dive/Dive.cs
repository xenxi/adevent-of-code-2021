namespace Dive
{
    public class Dive
    {
        private int _depth = 0;
        private int _locator = 0;

        public int BroadcastLocator()
        {
            return _locator * _depth;
        }

        public void Down(int step)
        {
            _depth += step;
        }

        public void Forward(int step)
        {
            _locator += step;
        }
        public void Up(int step)
        {
            _depth -= step;
        }
    }
}