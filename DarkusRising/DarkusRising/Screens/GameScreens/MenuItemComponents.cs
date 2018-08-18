using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace DarkusRising.Screens.GameScreens
{
    internal class MenuItemComponents
    {
        private string[] menuItems;
        private int selectedIndex;
        private float width;
        private float height;
        private Vector2 position;
        private SpriteFont spriteFont;

        public Color NormalColor
        {
            get;
            set;
        }

        public Color HighlightedColor
        {
            get;
            set;
        }

        public float Width
        {
            get { return width; }
        }

        public float Height
        {
            get { return height; }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
        }

        public MenuItemComponents(SpriteFont spriteFont, String[] items)
        {
            this.spriteFont = spriteFont;
            SetMenuItems(items);
            NormalColor = Color.GhostWhite; //TODO: Change Menu Color
            HighlightedColor = Color.Gold;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public void SetMenuItems(String[] items)
        {
            menuItems = (string[])items.Clone(); //Takes the items passed in and clones it as an new array
            MeasureMenu();
        }

        private void MeasureMenu()
        {
            width = 0;
            height = 0;
            foreach (string s in menuItems)
            {
                if (width < spriteFont.MeasureString(s).X)
                {
                    width = spriteFont.MeasureString(s).X;
                }
                height += spriteFont.LineSpacing;
            }
        }

        public void Update(GameTime gameTime)
        {
            #region Input

            if ((Input.InputHandler.KeyReleased(Keys.Up) || Input.InputHandler.KeyReleased(Keys.W)) ||
               ((Input.InputHandler.ButtonReleased(Buttons.DPadUp, PlayerIndex.One) || Input.InputHandler.ButtonPressed(Buttons.LeftThumbstickUp, PlayerIndex.One)) && GamePad.GetState(PlayerIndex.One).IsConnected))
            {
                selectedIndex--;

                if (selectedIndex < 0)
                {
                    selectedIndex = menuItems.Length - 1;
                }
            }

            if (Input.InputHandler.KeyReleased(Keys.Down) || Input.InputHandler.KeyReleased(Keys.S) ||
                (Input.InputHandler.ButtonReleased(Buttons.DPadDown, PlayerIndex.One) && GamePad.GetState(PlayerIndex.One).IsConnected) ||
               (Input.InputHandler.ButtonPressed(Buttons.LeftThumbstickDown, PlayerIndex.One) && GamePad.GetState(PlayerIndex.One).IsConnected))
            {
                selectedIndex++;

                if (selectedIndex >= menuItems.Length)
                {
                    selectedIndex = 0;
                }
            }

            #endregion Input
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 menuPosition = position;
            for (int index = 0; index < menuItems.Length; index++)
            {
                if (index == selectedIndex)
                {
                    spriteBatch.DrawString(spriteFont, menuItems[index], menuPosition, HighlightedColor);
                }
                else
                {
                    spriteBatch.DrawString(spriteFont, menuItems[index], menuPosition, NormalColor);
                }
                menuPosition.Y += spriteFont.LineSpacing;
            }
        }
    }
}