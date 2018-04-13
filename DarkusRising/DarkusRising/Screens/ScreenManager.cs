using DarkusRising.EventArguments;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Screen CurrentScreen
        {
            //Looking at the screen to the top of the stack without removing it from the stack
            get { return screens.Peek(); }
        }

        public void PopScreen()
        {
            RemoveScreen();
            drawOrder = drawOrderInc;

            if (OnScreenChange != null)
            {
                OnScreenChange(this, new ScreenEventArgs(screens.Peek()));
            }
        }

        public void RemoveScreen() //Part of PopScreen()
        {
            Screen screen = (Screen)screens.Peek();
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
                OnScreenChange += newScreen.ScreenChange;
        }
    }
}