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

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(44, 44)]
        public void move_forward(int step, int expectedLocator)
        {
            var dive = new Dive();
            dive.Forward(step);

            var locator = dive.BroadcastLocator();

            locator.Should().Be(expectedLocator);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(44, 44)]
        public void move_down(int step, int expectedLocator)
        {
            var dive = new Dive();
            dive.Down(step);

            var locator = dive.BroadcastLocator();

            locator.Should().Be(expectedLocator);
        }
    }
}
