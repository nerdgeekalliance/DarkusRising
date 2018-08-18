using DarkusRising.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace DarkusRising.Music_Controller
{
    public class MusicScore : Screen
    {
        private readonly ScreenManager manager;
        private readonly SpriteBatch spriteBatch;
        protected Song intoHisLair;

        public MusicScore(Game game, ScreenManager screenManager)
            : base(game)
        {
            content = Game.Content;
            manager = screenManager;
        }

        public void Load()
        {
            intoHisLair = content.Load<Song>(@"Music\01Score\Into_his_Lair");
            MediaPlayer.Play(intoHisLair);
            MediaPlayer.IsRepeating = true;
            base.LoadContent();
        }
    }
}