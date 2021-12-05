using FluentAssertions;
using NUnit.Framework;
using System;

namespace Dive.Tests
{
    [TestFixture]
    public class AdvancedDiveShould
    {
        private AdvancedDive dive => _dive ?? throw new InvalidOperationException("not initialized");
        private AdvancedDive? _dive;

        [SetUp]
        public void SetUp()
        {
            _dive = new AdvancedDive();
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(44, 44)]
        public void move_down_increase_aim(int step, int expectedAim)
        {
            dive.Down(step);

            dive.Aim.Should().Be(expectedAim);
        }

    }
}
