﻿namespace Dive
{
    public class Dive
    {
        private int _locator = 0;
        public void ExecuteComands(string aGivenCommands)
        {
            throw new NotImplementedException();
        }

        public int BroadcastLocator()
        {
           return _locator;
        }

        public void Forward(int step)
        {
            _locator = 1;
        }
    }
}
