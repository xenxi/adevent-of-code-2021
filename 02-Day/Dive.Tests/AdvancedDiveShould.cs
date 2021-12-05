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

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(44, 44)]
        public void move_down_increase_the_aim(int step, int expectedAim)
        {
            dive.Down(step);

            dive.Aim.Should().Be(expectedAim);
        }

        [SetUp]
        public void SetUp()
        {
            _dive = new AdvancedDive();
        }
    }
}