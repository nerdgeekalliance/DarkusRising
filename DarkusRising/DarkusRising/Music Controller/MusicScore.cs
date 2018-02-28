using DarkusRising.Input;
using DarkusRising.Screens;
using DarkusRising.Screens.Rooms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkusRising.Music_Controller
{
    public class MusicScore : Screen
    {
        private ScreenManager manager;
        private SpriteBatch spriteBatch;
        protected Song intoHisLair;

        public MusicScore(Game game, ScreenManager screenManager)
            : base(game)
        {
            content = Game.Content;
            manager = screenManager;
        }

        /*
        public override void Load()
        {
            intoHisLair = content.Load<Song>(@"Music\01Score\Into_his_Lair");
            MediaPlayer.Play(intoHisLair);
            MediaPlayer.IsRepeating = true;
            base.LoadContent();
        }
         * */
    }
}