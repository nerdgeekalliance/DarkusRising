using DarkusRising.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DarkusRising.Screens.GameScreens
{
    //TODO: replace the text and backgrounds later
    public class StartMenu : Screen
    {
        #region vars

        private MenuItemComponents menuComponents;
        private readonly string[] menuItems = { "New Game", "Load Game", "Options", "Exit" };
        private Background background;
        private SpriteFont spriteFont;
        private ScreenManager screenManager;
        private SpriteBatch spritebatch;
        private SoundEffect soundEffect;
        private SoundEffectInstance soundEffectInstance;

        #endregion vars

        public StartMenu(Game game, ScreenManager screenManager)
            : base(game)
        {
            content = Game.Content;
            this.screenManager = screenManager;
        }

        #region XNA Methods

        protected override void LoadContent()
        {
            spritebatch = new SpriteBatch(GraphicsDevice);
            spriteFont = content.Load<SpriteFont>(@"Fonts/Menu/MenuFont");
            menuComponents = new MenuItemComponents(spriteFont, menuItems);
            soundEffect = content.Load<SoundEffect>(@"Music/DarkusRisingIntro");
            //Position of the Menu Items
            Vector2 menuPosition = new Vector2(
                (Game.Window.ClientBounds.Width) - 582,
                (Game.Window.ClientBounds.Height) - 512);
            menuComponents.SetPosition(menuPosition);
            background = new Background(content.Load<Texture2D>(@"Backgrounds/bkg_title")); //TODO: Change Background

            soundEffectInstance = soundEffect.CreateInstance();
            soundEffectInstance.IsLooped = true;
            soundEffectInstance.Volume = 0.0005f;
            soundEffectInstance.Pitch = 0.5f;
            soundEffectInstance.Play();
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            //Room Selection

            if ((InputHandler.ButtonReleased(Buttons.A, PlayerIndex.One) && GamePad.GetState(PlayerIndex.One).IsConnected) || Input.InputHandler.KeyReleased(Keys.Enter))
            {
                soundEffectInstance.Stop();
                switch (menuComponents.SelectedIndex)
                {
                    case 0:

                        screenManager.ChangeScreens(gameRef.loadingScreen);

                        break;

                    case 1:
                        //screenManager.ChangeScreens(gameRef.loadGame); //TODO: Load Save
                        break;

                    case 2:
                        //screenManager.ChangeScreens(gameRef.optionsScreen); //TODO: Add Menu
                        break;

                    case 3:
                        Game.Exit();
                        break;
                }
            }
            menuComponents.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Begin(); //Using Public Static spriteBatch in Game1.cs

            background.Draw(Game1.spriteBatch);
            menuComponents.Draw(Game1.spriteBatch);
            base.Draw(gameTime);
            Game1.spriteBatch.End();
        }

        #endregion XNA Methods
    }
}