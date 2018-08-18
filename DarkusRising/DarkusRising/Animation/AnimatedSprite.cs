using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DarkusRising.Animation
{
    public class AnimatedSprite
    {
        private readonly Dictionary<AnimationKey, Animation> animations;
        private AnimationKey currentAnimation; //Up, Down, Left, Right
        private bool isAnimating;

        private readonly Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;
        private float speed;

        public AnimatedSprite(Texture2D textures, Dictionary<AnimationKey, Animation> animation)
        {
            texture = textures;
            animations = animation;
        }

        public AnimationKey CurrentAnimation
        {
            get => currentAnimation;
            set => currentAnimation = value;
        }

        public bool IsAnimating
        {
            get => isAnimating;
            set => isAnimating = value;
        }

        public int Width => animations[currentAnimation].FrameWidth;

        public int Height => animations[currentAnimation].FrameHeight;

        public float Speed
        {
            get => speed;
            set => speed = MathHelper.Clamp(speed, 1.0f, 5.0f);
        }

        public Vector2 Position
        {
            get => position;
            set => position = value;
        }

        public Vector2 Velocity
        {
            get => velocity;
            set
            {
                velocity = value;
                if (velocity != Vector2.Zero)
                {
                    velocity.Normalize(); //Because of the stupid a^2 + b^2 = c^2 and pressing 2 keys is twice as fast, normalize sets it back to 1
                }
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