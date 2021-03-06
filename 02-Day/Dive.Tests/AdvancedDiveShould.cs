using FluentAssertions;
using NUnit.Framework;
using System;

namespace Dive.Tests
{
    [TestFixture]
    public class AdvancedDiveShould
    {
        private AdvancedDive? _dive;
        private AdvancedDive dive => _dive ?? throw new InvalidOperationException("not initialized");

        [Test]
        public void has_0_aim_when_created()
        {
            dive.Aim.Should().Be(0);
        }

        [Test]
        public void has_0_depth_when_created()
        {
            dive.Depth.Should().Be(0);
        }

        [Test]
        public void has_0_horizontal_when_created()
        {
            dive.Horizontal.Should().Be(0);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(44, 44)]
        public void move_down_increases_the_aim(int step, int expectedAim)
        {
            dive.Down(step);

            dive.Aim.Should().Be(expectedAim);
        }

        [TestCase(1, 100, 99)]
        [TestCase(2, 100, 98)]
        [TestCase(3, 100, 97)]
        public void move_up_decreases_the_depth(int step, int initialAim, int expectedAim)
        {
            dive.Down(initialAim);
           
            dive.Up(step);

            dive.Aim.Should().Be(expectedAim);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(44, 44)]
        public void move_forward_increases_the_horizontal_position(int step, int expectedHorizontalPosition)
        {
            dive.Forward(step);

            dive.Horizontal.Should().Be(expectedHorizontalPosition);
        }

        [TestCase(1, 0, 0)]
        [TestCase(2, 1, 2)]
        [TestCase(3, 3, 9)]
        public void move_forward_increases_the_depth_by_aim_multiplied_by_step(int step, int aim, int expectedDepth)
        {
            dive.Down(aim);

            dive.Forward(step);

            dive.Depth.Should().Be(expectedDepth);
        }

        [SetUp]
        public void SetUp()
        {
            _dive = new AdvancedDive();
        }
    }
}