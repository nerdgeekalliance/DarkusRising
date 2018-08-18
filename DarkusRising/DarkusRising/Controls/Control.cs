using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace DarkusRising.Controls
{
    public abstract class Control
    {
        #region Field Region

        protected string name;
        protected string text;
        protected Vector2 size;
        protected Vector2 position;
        protected object value;
        protected bool hasFocus;
        protected bool enabled;
        protected bool visible;
        protected bool tabStop;
        protected SpriteFont spriteFont;
        protected Color color;
        protected string type;

        #endregion Field Region

        #region Event Region

        public event EventHandler Selected;

        #endregion Event Region

        #region Property Region

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Text
        {
            get => text;
            set => text = value;
        }

        public Vector2 Size
        {
            get => size;
            set => size = value;
        }

        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
                position.Y = (int)position.Y;
            }
        }

        public object Value
        {
            get => value;
            set => this.value = value;
        }

        public bool HasFocus
        {
            get => hasFocus;
            set => hasFocus = value;
        }

        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public bool Visible
        {
            get => visible;
            set => visible = value;
        }

        public bool TabStop
        {
            get => tabStop;
            set => tabStop = value;
        }

        public SpriteFont SpriteFont
        {
            get => spriteFont;
            set => spriteFont = value;
        }

        public Color Color
        {
            get => color;
            set => color = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }

        #endregion Property Region

        #region Constructor Region

        public Control()
        {
            Color = Color.White;
            Enabled = true;
            Visible = true; SpriteFont = ControlManager.SpriteFont;
        }

        #endregion Constructor Region

        #region Abstract Methods

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void HandleInput(PlayerIndex playerIndex);

        #endregion Abstract Methods

        #region Virtual Methods

        protected virtual void OnSelected(EventArgs e)
        {
            Selected?.Invoke(this, e);
        }

        #endregion Virtual Methods
    }
}