using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarkusRising.Screens
{
    public class GameOver : Screen
    {
        #region vars

        private ScreenManager screenManager;
        private Background background;
        private SpriteFont spriteFont_Loading, spriteFont_Fact;
        private SpriteBatch spriteBatch;

        public bool gameOver = false;

        #endregion vars

        public GameOver(Game game, ScreenManager screenManager)
            : base(game)
        {
            content = Game.Content;
            this.screenManager = screenManager;
        }

        #region XNA Methods

        public override void Initialize()
        {
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
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Begin(); //Using Public Static spriteBatch in Game1.cs
            background.Draw(Game1.spriteBatch);
            Game1.spriteBatch.End();
            /*
            if (GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                spriteBatch.DrawString(spriteFont_Loading, "Press Start", loading_pos, Color.Aqua);
                if (Input.InputHandler.ButtonReleased(Buttons.Start, PlayerIndex.One))
                {
                    screenManager.ChangeScreens(gameRef.room101);
                }
            }
            else
            {
                spriteBatch.DrawString(spriteFont_Loading, "Press Enter", loading_pos, Color.Aqua);
                if (Input.InputHandler.KeyReleased(Keys.Enter))
                {
                    screenManager.ChangeScreens(gameRef.room101);
                }
            }
            */
            spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion XNA Methods
    }
}