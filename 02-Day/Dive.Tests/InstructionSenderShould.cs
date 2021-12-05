using Dive.Commands;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace Dive.Tests
{
    [TestFixture]
    public class InstructionSenderShould
    {
        private InstructionSender _sender;
        private CommandRepository _repository;
        private LocatorNotificator _notificator;
        
        [SetUp]
        public void SetUp()
        {
            _notificator = Substitute.For<LocatorNotificator>();
            _repository = Substitute.For<CommandRepository>();
            _sender = new InstructionSender(_repository, _notificator);
        }
        [Test]
        public void move_dive()
        {
            var aGivenDive = new BasicDive();
            var aGivenMovementCommands = new List<MoveCommandParam> { 
                new MoveCommandParam(MoveCommandType.Forward, 5),
                new MoveCommandParam(MoveCommandType.Down, 5),
                new MoveCommandParam(MoveCommandType.Forward, 8),
                new MoveCommandParam(MoveCommandType.Up, 3),
                new MoveCommandParam(MoveCommandType.Down, 8),
                new MoveCommandParam(MoveCommandType.Forward, 2),
            };
            ShouldSearchForCommands(aGivenMovementCommands);

            _sender.Send(aGivenDive);

            _notificator.Received(1).Notify(150);
        }

        private void ShouldSearchForCommands(List<MoveCommandParam> commands)
            => _repository.GetAll().Returns(commands);
    }
}
