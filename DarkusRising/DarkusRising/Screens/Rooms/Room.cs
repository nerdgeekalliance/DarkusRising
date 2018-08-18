using DarkusRising.Animation;
using DarkusRising.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DarkusRising.Screens.Rooms
{
    public class Room : Screen
    {
        #region vars

        private readonly ScreenManager manager;
        private Background background;
        private SpriteBatch spriteBatch;
        private AnimatedSprite sprite;

        private Vector2 playerPos;
        private PlayerIndex playerIndex;

        private string roomSelect, floorSelect;
        private string backgroundSelect;

        private float timer = 0;

        #endregion vars

        public Room(Game game, ScreenManager screenManager)
            : base(game) //Inherits Screen and ScreenManager
        {
            content = Game.Content;
            manager = screenManager;
        }

        public PlayerIndex PlayerIndex
        {
            get => playerIndex;
            set => playerIndex = value;
        }

        public string RoomSelect
        {
            get => roomSelect;
            set => roomSelect = value;
        }

        public string FloorSelect
        {
            get => floorSelect;
            set => floorSelect = value;
        }

        public Vector2 PlayerPos
        {
            get => playerPos;
            set => playerPos = value;
        }

        #region XNA Methods

        public override void Initialize()
        {
            backgroundSelect = string.Concat("Backgrounds/Rooms/", floorSelect, "/bkg_", roomSelect);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = new Background(content.Load<Texture2D>(@backgroundSelect)); //TODO: Change Background, Put backgrounds in folders, notice the reference
            Dictionary<AnimationKey, Animation.Animation> animations = new Dictionary<AnimationKey, Animation.Animation>();
            Texture2D sprS_PierreWalk = Game.Content.Load<Texture2D>(@"Sprites/Characters/JohnPierre-Walk");
            Texture2D sprS_PierreAttack = Game.Content.Load<Texture2D>(@"Sprites/Characters/JohnPierre-Attack");

            Animation.Animation animation = new Animation.Animation(9, sprS_PierreWalk.Width / 9, sprS_PierreWalk.Height / 2, 0, sprS_PierreWalk.Height / 2);
            animations.Add(AnimationKey.Left, animation);
            animation = new Animation.Animation(9, sprS_PierreWalk.Width / 9, sprS_PierreWalk.Height / 2, 0, 0);
            animations.Add(AnimationKey.Right, animation);

            sprite = new AnimatedSprite(sprS_PierreWalk, animations)
            {
                Position = playerPos,
                Speed = 2f
            };
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);

            timer += gameTime.ElapsedGameTime.Seconds; //1 Second

            // Jared was here

            bool movementFlag = false;

            #region Inputs

            #region Movements

            #region Move Up

            if (InputHandler.ButtonDown(Buttons.LeftThumbstickUp, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                InputHandler.ButtonDown(Buttons.DPadUp, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                InputHandler.KeyDown(Keys.W))
            {
                if (playerPos.Y > 114 - sprite.Height)
                {
                    playerPos.Y -= 2.5f;
                    sprite.Position = playerPos;
                }

                movementFlag = true;
            }

            #endregion Move Up

            #region Move Left

            if (InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                InputHandler.ButtonDown(Buttons.DPadLeft, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                InputHandler.KeyDown(Keys.A))
            {
                if (playerPos.X > 100)
                {
                    sprite.CurrentAnimation = AnimationKey.Left;
                    playerPos.X -= 2.5f;
                    sprite.Position = playerPos;
                }

                movementFlag = true;
            }

            #endregion Move Left

            #region Move Down

            if (InputHandler.ButtonDown(Buttons.LeftThumbstickDown, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                InputHandler.ButtonDown(Buttons.DPadDown, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                InputHandler.KeyDown(Keys.S))
            {
                if (playerPos.Y < 754 - sprite.Height)
                {
                    playerPos.Y += 2.5f;
                    sprite.Position = playerPos;
                }

                movementFlag = true;
            }

            #endregion Move Down

            #region Move Right

            if (InputHandler.ButtonDown(Buttons.LeftThumbstickRight, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                InputHandler.ButtonDown(Buttons.DPadRight, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                InputHandler.KeyDown(Keys.D))
            {
                if (playerPos.X < 924 - sprite.Width)
                {
                    sprite.CurrentAnimation = AnimationKey.Right;
                    playerPos.X += 2.5f;
                    sprite.Position = playerPos;
                }

                movementFlag = true;
            }

            #endregion Move Right

            #endregion Movements

            #region Normalize Diagonals (Offset + or - 1.0355339059327f)

            #region Move Diag TopLeft

            if (InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, playerIndex) && InputHandler.ButtonDown(Buttons.LeftThumbstickUp, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                  InputHandler.ButtonDown(Buttons.DPadLeft, playerIndex) && InputHandler.ButtonDown(Buttons.LeftThumbstickUp, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                  InputHandler.KeyDown(Keys.A) && InputHandler.KeyDown(Keys.W))
            {
                playerPos.X += 1.0355339059327f;
                playerPos.Y += 1.0355339059327f;
                sprite.Position = playerPos;

                movementFlag = true;
            }

            #endregion Move Diag TopLeft

            #region Move Diag TopRight

            if (InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, playerIndex) && InputHandler.ButtonDown(Buttons.LeftThumbstickUp, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                  InputHandler.ButtonDown(Buttons.DPadLeft, playerIndex) && InputHandler.ButtonDown(Buttons.LeftThumbstickUp, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                  InputHandler.KeyDown(Keys.A) && InputHandler.KeyDown(Keys.W))
            {
                playerPos.X -= 1.0355339059327f;
                playerPos.Y += 1.0355339059327f;
                sprite.Position = playerPos;

                movementFlag = true;
            }

            #endregion Move Diag TopRight

            #region Move Diag BottomLeft

            if (InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, playerIndex) && InputHandler.ButtonDown(Buttons.LeftThumbstickUp, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                  InputHandler.ButtonDown(Buttons.DPadLeft, playerIndex) && InputHandler.ButtonDown(Buttons.LeftThumbstickUp, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                  InputHandler.KeyDown(Keys.A) && InputHandler.KeyDown(Keys.S))
            {
                playerPos.X += 1.0355339059327f;
                playerPos.Y -= 1.0355339059327f;
                sprite.Position = playerPos;

                movementFlag = true;
            }

            #endregion Move Diag BottomLeft

            #region Move Diag BottomRight

            if (InputHandler.ButtonDown(Buttons.LeftThumbstickRight, playerIndex) && InputHandler.ButtonDown(Buttons.LeftThumbstickUp, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                  InputHandler.ButtonDown(Buttons.DPadLeft, playerIndex) && InputHandler.ButtonDown(Buttons.LeftThumbstickUp, playerIndex) && GamePad.GetState(playerIndex).IsConnected ||
                  InputHandler.KeyDown(Keys.D) && InputHandler.KeyDown(Keys.S))
            {
                playerPos.X -= 1.0355339059327f;
                playerPos.Y -= 1.0355339059327f;
                sprite.Position = playerPos;

                movementFlag = true;
            }

            #endregion Move Diag BottomRight

            #endregion Normalize Diagonals (Offset + or - 1.0355339059327f)

            #endregion Inputs

            #region Jared is the best or How I learned to stop worrying and love Jared's fixes

            //Thanks Jared for simplifying IsAnimating

            if (movementFlag)
            {
                sprite.IsAnimating = true;
            }
            else
            {
                sprite.IsAnimating = false;
            }

            #endregion Jared is the best or How I learned to stop worrying and love Jared's fixes

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Begin(); //Using Public Static spriteBatch in Game1.cs
            background.Draw(Game1.spriteBatch);
            Game1.spriteBatch.End();

            spriteBatch.Begin(
 SpriteSortMode.Immediate,
 BlendState.AlphaBlend,
 SamplerState.PointClamp, null,
 null,
 null,
 Matrix.Identity);
            sprite.Draw(gameTime, spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        #endregion XNA Methods
    }
}