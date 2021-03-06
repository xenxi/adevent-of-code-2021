namespace Dive
{
    public sealed class BasicDive : Dive
    {
        public override void Down(int step)
        {
            Depth += step;
        }

        public override void Forward(int step)
        {
            Horizontal += step;
        }

        public override void Up(int step)
        {
            Depth -= step;
        }
    }
}