using DarkusRising.Animation;

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