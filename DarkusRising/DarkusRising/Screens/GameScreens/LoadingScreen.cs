using DarkusRising.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkusRising.Screens
{
    public class LoadingScreen : Screen
    {
        #region vars

        private ScreenManager screenManager;
        private Background background;
        private SpriteFont spriteFont_Loading, spriteFont_Fact;
        private SpriteBatch spriteBatch;

        private float timer = 20;
        private float loadingTimer = 0;
        private float factTimer = 0;

        private string[] str_loading = { "         ", "L         ", "Lo        ", "Loa       ", "Load      ", "Loadi     ",
                                           "Loadin    ", "Loading   ", "Loading.  ", "Loading.. ", "Loading..." };

        private Vector2 loading_pos = new Vector2(730, 730);

        #region facts

        private Vector2 mStringOrgin;
        private Vector2 factPos;

        private string[] str_storyFact = {
                                        "First rule. Darkus is pure evil.",
                                        "Thou shall collect gems to unlock the boss.",
                                        "There are multiple floors in this dungeon.",
                                        "Hmm...I wonder if I can consume a black heart.",
                                        "Do not be afraid, trust your insticts.",
                                        "There is treasure hidden in the rooms.",
                                        "Collect gold if you must. Beware. Evil lurks.",
                                        "The story parts must be burned after read."
                                        };

        #endregion facts

        #endregion vars

        public LoadingScreen(Game game, ScreenManager screenManager)
            : base(game)
        {
            content = Game.Content;
            this.screenManager = screenManager;
        }

        #region XNA Methods

        public override void Initialize()
        {
            Random rnd = new Random();
            factTimer = rnd.Next(0, str_storyFact.Length - 1);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont_Loading = content.Load<SpriteFont>(@"Fonts/Loading/LoadingTitle");
            spriteFont_Fact = content.Load<SpriteFont>(@"Fonts/Loading/LoadingFact");
            background = new Background(content.Load<Texture2D>(@"Backgrounds/bkg_loading")); //TODO: Change Background
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (timer != 0)
            {
                timer -= (float)gameTime.ElapsedGameTime.TotalSeconds; //Subtracts 1 Second to timer
            }

            #region loadingTimer

            loadingTimer += (float)gameTime.ElapsedGameTime.TotalSeconds * 3; //Adds 3 seconds to Loading Timer

            if (loadingTimer > str_loading.Length)
            {
                loadingTimer = 0;
            }

            #endregion loadingTimer

            #region factTimer

            factTimer += (float)gameTime.ElapsedGameTime.TotalSeconds / str_storyFact.Length;

            if (factTimer > str_storyFact.Length)
            {
                factTimer = 0;
            }

            #endregion factTimer

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Begin(); //Using Public Static spriteBatch in Game1.cs
            background.Draw(Game1.spriteBatch);
            Game1.spriteBatch.End();

            spriteBatch.Begin();

#if false //For Debugging, Skips Loading
            screenManager.ChangeScreens(gameRef.room101);
#endif

            if (timer > 0)
            {
                mStringOrgin = spriteFont_Fact.MeasureString(str_storyFact[(int)factTimer]) / 2;
                factPos = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height * 3 / 4);

                spriteBatch.DrawString(spriteFont_Loading, str_loading[(int)loadingTimer], loading_pos, Color.Coral);
                spriteBatch.DrawString(spriteFont_Fact, str_storyFact[(int)factTimer], factPos, Color.Gold, 0, mStringOrgin, 1.0f, SpriteEffects.None, 0.5f);
            }
            else
            {
                mStringOrgin = spriteFont_Fact.MeasureString("Darkus is Rising. Embrace your fears!") / 2;
                spriteBatch.DrawString(spriteFont_Fact, "Darkus is Rising. Embrace your fears!", factPos, Color.Coral, 0, mStringOrgin, 1.0f, SpriteEffects.None, 0.5f);
                if (GamePad.GetState(PlayerIndex.One).IsConnected)
                {
                    spriteBatch.DrawString(spriteFont_Loading, "Press Start", loading_pos, Color.Gold);
                    if (Input.InputHandler.ButtonReleased(Buttons.Start, PlayerIndex.One))
                    {
                        screenManager.ChangeScreens(gameRef.room101);
                    }
                }
                else
                {
                    spriteBatch.DrawString(spriteFont_Loading, "Press Enter", loading_pos, Color.Gold);
                    if (Input.InputHandler.KeyReleased(Keys.Enter))
                    {
                        screenManager.ChangeScreens(gameRef.room101);
                    }
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion XNA Methods
    }
}