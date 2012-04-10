using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace SpaceGame.KeyboardHandler
{
    public class PlayerKeyboard
    {
        public static Keys UP;

        public static Keys DOWN;

        public static Keys LEFT;

        public static Keys RIGHT;

        public static Keys SPACE;

        static PlayerKeyboard()
        {
            //Configure the keys
            PlayerKeyboard.DOWN = Keys.Down;
            PlayerKeyboard.UP = Keys.Up;
            PlayerKeyboard.LEFT = Keys.Left;
            PlayerKeyboard.RIGHT = Keys.Right;
            PlayerKeyboard.SPACE = Keys.Space;
        }

    }
}
