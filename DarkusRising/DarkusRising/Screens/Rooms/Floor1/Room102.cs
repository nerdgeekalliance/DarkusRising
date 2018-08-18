using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarkusRising.Screens.Rooms
{
    public class Room102 : Room
    {
        #region vars

        private ScreenManager manager;
        private Background background;
        private SpriteBatch spriteBatch;

        #endregion vars

        public Room102(Game game, ScreenManager screenManager)
            : base(game, screenManager)
        {
            content = Game.Content;
            manager = screenManager;
        }

        #region XNA Methods

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
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

            spriteBatch.Begin();

            spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion XNA Methods
    }
}