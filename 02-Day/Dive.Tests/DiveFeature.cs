using Dive.Commands;
using NSubstitute;
using NUnit.Framework;

namespace Dive.Tests
{
    [TestFixture]
    public class DiveFeature
    {
        [Test]
        public void move()
        {
            var aGivenCommands = "forward 5\r\ndown 5\r\nforward 8\r\nup 3\r\ndown 8\r\nforward 2";
            var commandRepo = new StringCommandRepository(aGivenCommands);
            var notificator = Substitute.For<LocatorNotificator>();
            var sender = new InstructionSender(commandRepo, notificator);

            sender.Send();

            notificator.Received(1).Notify(150);
        }

    }
}
