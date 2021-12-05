using FluentAssertions;
using NUnit.Framework;
using System;

namespace Dive.Tests
{
    [TestFixture]
    public class BasicDiveShould
    {
        private BasicDive dive => _dive ?? throw new InvalidOperationException("not initialized");
        private BasicDive? _dive;

        [SetUp]
        public void SetUp()
        {
            _dive = new BasicDive();
        }

        [Test]
        public void initialize_with_locator_0()
        {
            var locator = dive.BroadcastLocator();

            locator.Should().Be(0);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(44, 44)]
        public void move_forward(int step, int expectedLocator)
        {
            dive.Forward(step);
            dive.Down(1);

            var locator = dive.BroadcastLocator();

            locator.Should().Be(expectedLocator);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(44, 44)]
        public void move_down(int step, int expectedLocator)
        {
            dive.Forward(1);
            dive.Down(step);

            var locator = dive.BroadcastLocator();

            locator.Should().Be(expectedLocator);
        }

        [Test]
        public void move_up_decreases_the_depth()
        {
            dive.Down(2);
            dive.Up(1);
            dive.Forward(1);

            var locator = dive.BroadcastLocator();

            locator.Should().Be(1);
        }

        [Test]
        public void calcule_locator_as_the_product_of_the_depth_and_the_horizontal_position()
        {
            dive.Forward(5);
            dive.Down(5);
            dive.Forward(8);
            dive.Up(3);
            dive.Down(8);
            dive.Forward(2);

            var locator = dive.BroadcastLocator();

            locator.Should().Be(150);
        }
    }
}
