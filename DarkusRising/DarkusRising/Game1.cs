using DarkusRising.Input;
using DarkusRising.Screens;
using DarkusRising.Screens.GameScreens;
using DarkusRising.Screens.Rooms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DarkusRising
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private readonly GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static Vector2 viewPort;

        #region GameScreens

        //Intializes the use of screenManager.ChangeScreens(gameRef.room102); for example

        public StartMenu startmenu;
        public LoadingScreen loadingScreen;
        public Room101 room101;
        public Room102 room102;

        #endregion GameScreens

        //public OptionsScreen options;
        private readonly ScreenManager screenManager;

        public float fps;
        public float updateInterval = 1.0f;
        public float timeSinceLastUpdate = 0.0f;
        public float frameCount = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "DarkusRising";

            //#region Screen Properties

            IsMouseVisible = true;
            viewPort = new Vector2(1024, 832);
            graphics.PreferredBackBufferWidth = (int)viewPort.X;
            graphics.PreferredBackBufferHeight = (int)viewPort.Y;
            graphics.IsFullScreen = false;

            //#endregion Screen Properties

            //#region Game Components

            Components.Add(new InputHandler(this));
            //Components.Add(screenManager);

            //#endregion Game Components

            //#region GameScreens

            ////Allows the use of screenManager.ChangeScreens(gameRef.room102);

            screenManager = new ScreenManager(this);
            startmenu = new StartMenu(this, screenManager);
            loadingScreen = new LoadingScreen(this, screenManager);
            room101 = new Room101(this, screenManager);
            room102 = new Room102(this, screenManager);

            //#endregion GameScreens

            screenManager.ChangeScreens(startmenu);
            //optionsScreen = new optionsScreen(this, screenManager);
        }

        #region XNA Methods

        protected override void Initialize()
        {
            Window.Title = "CheifDarkChaos Presents: 'Darkus Rising' v0.0.1.0";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                Exit();
            }

            #region FPS Counter Draw

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCount++;
            timeSinceLastUpdate += elapsed;

            if (timeSinceLastUpdate > updateInterval)
            {
                fps = frameCount / timeSinceLastUpdate;
#if XBOX360
                System.Diagnostics.Debug.WriteLine("FPS: " + fps.ToString());
#else
                Window.Title = "CheifDarkChaos Presents: 'Darkus Rising' v0.0.1.0  |  FPS: " + string.Format("{0:0.00}", fps);
#endif
                frameCount = 0;
                timeSinceLastUpdate -= updateInterval;
            }

            #endregion FPS Counter Draw

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }

        #endregion XNA Methods
    }
}