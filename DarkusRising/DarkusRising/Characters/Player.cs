using DarkusRising.Animation;
using DarkusRising.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkusRising.Characters
{
    public enum Gender { Male, Female }

    public class Player : Character
    {
        public Player(AnimatedSprite sprite)
            : base(sprite) //Inherits Character.cs
        {
        }
    }
}