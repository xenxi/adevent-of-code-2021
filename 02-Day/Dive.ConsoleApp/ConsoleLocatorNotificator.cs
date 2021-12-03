namespace Dive.ConsoleApp
{
    public class ConsoleLocatorNotificator : LocatorNotificator
    {
        private readonly Action<string> _writteLine;

        public ConsoleLocatorNotificator(Action<string> writteLine)
        {
            _writteLine = writteLine;
        }

        public void Notify(int expectedLocator)
        {
            _writteLine($"LOCATOR: {expectedLocator}");
        }
    }
}