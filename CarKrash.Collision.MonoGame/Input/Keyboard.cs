using System;
using Microsoft.Xna.Framework.Input;

namespace Collision
{
    public class Keyboard
    {
        private static readonly Lazy<Keyboard> Lazy = new Lazy<Keyboard>(() => new Keyboard());
        public static Keyboard Instance
        {
            get => Lazy.Value;
        }

        private KeyboardState previousKeyboardState;
        private KeyboardState currentKeyboardState;

        public Keyboard()
        {
            previousKeyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            currentKeyboardState = previousKeyboardState;
        }

        public void Update()
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }

        public bool IsKeyDown (Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }
        public bool IsKeyUp(Keys key)
        {
            return currentKeyboardState.IsKeyUp(key);
        }

        public KeyboardState CurrentState => currentKeyboardState;
        public KeyboardState PreviousSate => previousKeyboardState;
    }
}