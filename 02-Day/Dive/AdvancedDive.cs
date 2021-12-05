namespace Dive
{
    public sealed class AdvancedDive : Dive
    {
        public int Aim { get; private set; } = 0;

        public override void Down(int step)
        {
            Aim += step;
        }

        public override void Forward(int step)
        {
            Horizontal += step;
            Depth += (step * Aim);
        }

        public override void Up(int step)
        {
            Aim -= step;
        }
    }
}