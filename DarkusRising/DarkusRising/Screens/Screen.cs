using DarkusRising.EventArguments;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace DarkusRising.Screens
{
    /// <summary>
    /// Component Screens such as Title, Room 1, Settings, Gameover etc.
    /// </summary>
    public abstract class Screen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private List<GameComponent> childComponents;
        protected ContentManager content;
        protected Game1 gameRef;

        public Screen(Game game)
            : base(game)
        {
            childComponents = new List<GameComponent>();
            gameRef = (Game1)game;
        }

        public List<GameComponent> Components
        {
            get { return childComponents; }
        }

        #region XNA Methods

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            //Checks to see if a screen is enabled from the stack
            foreach (GameComponent component in childComponents)
            {
                if (component.Enabled)
                    component.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent drawComponent;
            //Looking through the stack indexes, if the screen is drawable, then draw it
            foreach (GameComponent component in childComponents)
            {
                if (component is DrawableGameComponent)
                {
                    drawComponent = component as DrawableGameComponent;
                    if (drawComponent.Visible)
                        drawComponent.Draw(gameTime);
                }
            }
            base.Draw(gameTime);
        }

        #endregion XNA Methods

        #region GUI

        protected internal virtual void ScreenChange(object sender, ScreenEventArgs eventOccured)
        {
            if (eventOccured.Screen == this)
            {
                Show(); //Setting the Screen Visible
            }
            else
            {
                Hide(); //Setting the Screen invisible
            }
        }

        private void Show()
        {
            Visible = true;
            Enabled = true;

            foreach (GameComponent component in childComponents)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = true;
            }
        }

        private void Hide()
        {
            Visible = false;
            Enabled = false;

            foreach (GameComponent component in childComponents)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = false;
            }
        }

        #endregion GUI
    }
}