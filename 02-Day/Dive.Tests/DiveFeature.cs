using FluentAssertions;
using NUnit.Framework;

namespace Dive.Tests
{
    [TestFixture]
    public class DiveFeature
    {
        [Test]
        public void move()
        {
            var dive = new Dive();
            var aGivenCommands = "forward 5\r\ndown 5\r\nforward 8\r\nup 3\r\ndown 8\r\nforward 2";
            dive.ExecuteComands(aGivenCommands);

            var locator = dive.BroadcastLocation();
            
            locator.Should().Be(150);
        }

    }
}
