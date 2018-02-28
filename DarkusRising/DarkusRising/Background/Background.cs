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

namespace DarkusRising
{
    public class Background
    {
        private Texture2D backgroundImage;

        public Background(Texture2D texture)
        {
            Visible = true;
            backgroundImage = texture;
        }

        public bool Visible { get; set; }

        public Texture2D BackgroundImage
        {
            get { return backgroundImage; }
            private set { backgroundImage = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(backgroundImage, Vector2.Zero, Color.White); //TODO: Define Accessibility Color
            }
        }
    }
}