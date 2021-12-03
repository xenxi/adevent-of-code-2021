using NSubstitute;
using NUnit.Framework;
using System;

namespace Dive.ConsoleApp.Tests
{
    [TestFixture]
    public class ConsoleLocatorNotificatorShould
    {

        [TestCase(2)]
        [TestCase(4)]
        [TestCase(0)]
        [TestCase(20)]
        public void write_locator_to_the_console (int locator)
        {
            var writer = Substitute.For<Action<string>>();
            var notificator = new ConsoleLocatorNotificator(writer);

            notificator.Notify(locator);

            writer.Received(1)($"LOCATOR: {locator}");
        }
    }
}