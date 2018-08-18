using DarkusRising.Screens;
using System;

namespace DarkusRising.EventArguments
{
    public class ScreenEventArgs : EventArgs
    {
        public Screen Screen
        {
            get { return Screen; }
            private set { Screen = value; }
        }

        public ScreenEventArgs(Screen screen)
        {
            Screen = screen;
        }
    }
}