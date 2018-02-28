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
using System.Text;

namespace DarkusRising.Animation
{
    public class AnimatedSprite
    {
        private Dictionary<AnimationKey, Animation> animations;
        private AnimationKey currentAnimation; //Up, Down, Left, Right
        private bool isAnimating;

        private Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;
        private float speed;

        public AnimatedSprite(Texture2D textures, Dictionary<AnimationKey, Animation> animation)
        {
            this.texture = textures;
            this.animations = animation;
        }

        public AnimationKey CurrentAnimation
        {
            get { return currentAnimation; }
            set { currentAnimation = value; }
        }

        public bool IsAnimating
        {
            get { return isAnimating; }
            set { isAnimating = value; }
        }

        public int Width
        {
            get { return animations[currentAnimation].FrameWidth; }
        }

        public int Height
        {
            get { return animations[currentAnimation].FrameHeight; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = MathHelper.Clamp(speed, 1.0f, 5.0f); }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set
            {
                velocity = value;
                if (velocity != Vector2.Zero)
                    velocity.Normalize(); //Because of the stupid a^2 + b^2 = c^2 and pressing 2 keys is twice as fast, normalize sets it back to 1
            }
        }

        public void Update(GameTime gameTime)
        {
            if (isAnimating)
            {
                animations[currentAnimation].Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animations[currentAnimation].CurrentFramerect, Color.White);
        }

        public void LockToViewport()
        {
            position.X = MathHelper.Clamp(position.X, 0, (int)Game1.viewPort.X - Width);
            position.X = MathHelper.Clamp(position.X, 0, (int)Game1.viewPort.Y - Height);
        }
    }
}