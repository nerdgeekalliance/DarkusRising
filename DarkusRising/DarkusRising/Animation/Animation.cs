using Microsoft.Xna.Framework;
using System;

namespace DarkusRising.Animation
{
    //Keys to be animated, simple
    public enum AnimationKey { Left, Right }

    public class Animation
    {
        private Rectangle[] frames;
        private int framesPerSecond;
        private TimeSpan frameLength;
        private TimeSpan frameTimer;
        private int currentFrame;
        private int frameWidth;
        private int frameHeight;

        public void AnimationFPS(int framesPerSecond)
        {
            this.framesPerSecond = framesPerSecond;
        }

        public Animation(int frameCount, int frameWidth, int frameHeight, int xOffset, int yOffset)
        {
            frames = new Rectangle[frameCount];
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            for (int i = 0; i < frameCount; i++)
            {
                frames[i] = new Rectangle(xOffset + (frameWidth * i),
                    yOffset,
                    frameWidth,
                    frameHeight);
            }
            framesPerSecond = 60;
            Reset();
        }

        private Animation(Animation animation)
        {
            frames = animation.frames;
            framesPerSecond = 5;
        }

        public int FramesPerSecond
        {
            get => framesPerSecond;
            set
            {
                if (value < 1)
                {
                    framesPerSecond = 1;
                }
                else if (value > 60)
                {
                    framesPerSecond = 60;
                }
                else
                {
                    framesPerSecond = value;
                }

                frameLength = TimeSpan.FromSeconds(1 / (double)framesPerSecond);
            }
        }

        public Rectangle CurrentFramerect => frames[currentFrame];

        public int CurrentFrame
        {
            get => currentFrame;
            set => currentFrame = MathHelper.Clamp(value, 0, frames.Length - 1);
        }

        public int FrameWidth => frameWidth;

        public int FrameHeight => frameHeight;

        public void Update(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime;
            if (frameTimer >= frameLength) //If it's greater than the length it loops back to first position
            {
                frameTimer = TimeSpan.Zero;
                currentFrame = (currentFrame + 1) % frames.Length;
            }
        }

        public void Reset()
        {
            currentFrame = 0;
            frameTimer = TimeSpan.Zero;
        }

        public object Clone()
        {
            Animation animationClone = new Animation(this)
            {
                frames = frames,
                frameWidth = frameWidth,
                frameHeight = frameHeight
            };
            animationClone.Reset();

            return animationClone;
        }
    }
}