using DarkusRising.Animation;
using DarkusRising.Input;
using DarkusRising.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkusRising.Characters
{
    public abstract class Character
    {
        #region vars

        protected GameOver gameOver;

        public AttributePair hitPoints;
        protected AnimatedSprite animatedSprite;

        public Vector2 position;

        protected long coins;

        protected string characterName;

        protected bool isCharacterAlive;

        protected int Level;
        protected long experience;
        protected long experienceWorth;

        #endregion vars

        public Character(AnimatedSprite sprite)
        {
            animatedSprite = sprite; //This sprite in this class is passed in from Antimated Sprite
        }

        public virtual void Update(GameTime gameTime)
        {
            if (hitPoints.CurrentValue == 0)
            {
                isCharacterAlive = false;
            }
            if (isCharacterAlive == false)
            {
                //TODO: Change to GameOver 'You Died' Screen
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            animatedSprite.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }
    }
}