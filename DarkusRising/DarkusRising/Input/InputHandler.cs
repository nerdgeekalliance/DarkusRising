using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DarkusRising.Input
{
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        #region Keyboard Field Region

        private static KeyboardState keyboardState;
        private static KeyboardState lastKeyboardState;

        #endregion Keyboard Field Region

        #region Game Pad Field Region

        private static GamePadState[] gamePadStates;
        private static GamePadState[] lastGamePadStates;

        #endregion Game Pad Field Region

        #region Keyboard Property Region

        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }

        #endregion Keyboard Property Region

        #region Game Pad Property Region

        public static GamePadState[] GamePadStates
        {
            get { return gamePadStates; }
        }

        public static GamePadState[] LastGamePadStates
        {
            get { return lastGamePadStates; }
        }

        #endregion Game Pad Property Region

        #region Constructor Region

        public InputHandler(Game game)
            : base(game)
        {
            keyboardState = Keyboard.GetState();

            gamePadStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];

            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
                gamePadStates[(int)index] = GamePad.GetState(index);
        }

        #endregion Constructor Region

        #region XNA methods

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            lastGamePadStates = (GamePadState[])gamePadStates.Clone();
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
                gamePadStates[(int)index] = GamePad.GetState(index);

            base.Update(gameTime);
        }

        #endregion XNA methods

        #region General Method Region

        public static void Flush()
        {
            lastKeyboardState = keyboardState;
        }

        #endregion General Method Region

        #region Keyboard Region

        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) &&
                lastKeyboardState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) &&
                lastKeyboardState.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        #endregion Keyboard Region

        #region Game Pad Region

        public static bool ButtonReleased(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonUp(button) &&
                lastGamePadStates[(int)index].IsButtonDown(button);
        }

        public static bool ButtonPressed(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonDown(button) &&
                lastGamePadStates[(int)index].IsButtonUp(button);
        }

        public static bool ButtonDown(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonDown(button);
        }

        #endregion Game Pad Region
    }
}