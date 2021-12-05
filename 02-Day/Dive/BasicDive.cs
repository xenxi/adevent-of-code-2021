namespace Dive
{
    public class BasicDive : Dive
    {
        public override void Down(int step)
        {
            depth += step;
        }

        public override void Forward(int step)
        {
            horizontal += step;
        }

        public override void Up(int step)
        {
            depth -= step;
        }
    }
}