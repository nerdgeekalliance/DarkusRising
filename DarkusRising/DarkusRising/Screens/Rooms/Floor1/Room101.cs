using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace DarkusRising.Screens.Rooms
{
    public class Room101 : Room //All Code in Room is automactically copied here
    {
        #region vars

        private ScreenManager manager;
        private SpriteBatch spriteBatch;
        private Music_Controller.MusicScore musicScore;
        protected Song intoHisLair;

        private string floorSelect = "Floor1", roomSelect = "RoomA";
        private Vector2 playerPos = new Vector2(500, 500);

        private int playerHealth = 4;

        #endregion vars

        public Room101(Game game, ScreenManager screenManager)
            : base(game, screenManager)
        {
            content = Game.Content;
            manager = screenManager;
            FloorSelect = floorSelect;
            RoomSelect = roomSelect;
            PlayerPos = playerPos;
            PlayerIndex = PlayerIndex.One;
        }

        #region XNA Methods

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //musicScore.LoadContent();
            intoHisLair = content.Load<Song>(@"Music\01Score\IntoHisLair");
            MediaPlayer.Play(intoHisLair);
            MediaPlayer.Volume = 0.002f;
            MediaPlayer.IsRepeating = true;
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion XNA Methods
    }
}