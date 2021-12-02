using FluentAssertions;
using NUnit.Framework;

namespace Dive.Tests
{
    [TestFixture]
    public class DiveShould
    {
        [Test]
        public void initialize_with_locator_0()
        {
            var dive = new Dive();

            var locator = dive.BroadcastLocator();

            locator.Should().Be(0);
        }

        [Test]
        public void move_one_step_forward()
        {
            var dive = new Dive();
            dive.Forward(1);

            var locator = dive.BroadcastLocator();

            locator.Should().Be(1);
        }
    }
}
