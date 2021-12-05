using Dive.Commands;

namespace Dive
{
    public class InstructionSender
    {
        private readonly CommandRepository _repository;
        private readonly LocatorNotificator _notificator;

        public InstructionSender(CommandRepository repository, LocatorNotificator notificator) 
        {
            _repository = repository;
            _notificator = notificator;
        }

        public void Send()
        {
            var dive = new BasicDive();
            var commands = _repository.GetAll();

            foreach (var command in commands)
            {
                ProcessCommand(dive, command);
            }

            _notificator.Notify(dive.BroadcastLocator());
        }

        private static void ProcessCommand(BasicDive dive, MoveCommandParam command)
        {
            switch (command.Type)
            {
                case MoveCommandType.Forward:
                    dive.Forward(command.Step);
                    break;
                case MoveCommandType.Down:
                    dive.Down(command.Step);
                    break;
                case MoveCommandType.Up:
                    dive.Up(command.Step);
                    break;
            }
        }
    }
}
