using DarkusRising.EventArguments;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace DarkusRising.Screens
{
    /// <summary>
    /// Keeps track the screens in the stack
    /// </summary>
    public class ScreenManager : GameComponent
    {
        private Stack<Screen> screens = new Stack<Screen>();

        public event EventHandler<ScreenEventArgs> OnScreenChange;

        //Starting Position Stack Order
        private const int startDrawOrder = 5000;

        //var to increase Draw order by 100
        private const int drawOrderInc = 100;

        private int drawOrder;

        public ScreenManager(Game game)
            : base(game)
        {
            //Initalize Draw Order
            drawOrder = startDrawOrder;
        }

        public Screen CurrentScreen => screens.Peek();

        public void PopScreen()
        {
            RemoveScreen();
            drawOrder = drawOrderInc;

            OnScreenChange?.Invoke(this, new ScreenEventArgs(screens.Peek()));
        }

        public void RemoveScreen() //Part of PopScreen()
        {
            Screen screen = screens.Peek();
            //Shows or Hides the screen
            OnScreenChange -= screen.ScreenChange;
            //Actual Removal of Screen
            Game.Components.Remove(screen);
            screens.Pop();
        }

        public void PushScreen(Screen newScreen)
        {
            drawOrder += drawOrderInc;
            newScreen.DrawOrder = drawOrder;

            AddScreen(newScreen);

            if (OnScreenChange != null)
            {
                OnScreenChange += newScreen.ScreenChange;
            }
        }

        public void AddScreen(Screen newScreen)
        {
            //Inserts new screen at the top of the stack
            screens.Push(newScreen);
            Game.Components.Add(newScreen);
            OnScreenChange += newScreen.ScreenChange;
        }

        public void ChangeScreens(Screen newScreen)
        {
            while (screens.Count > 0)
            {
                RemoveScreen();
            }

            newScreen.DrawOrder = startDrawOrder;
            AddScreen(newScreen);

            if (OnScreenChange != null)
            {
                OnScreenChange += newScreen.ScreenChange;
            }
        }
    }
}