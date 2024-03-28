using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Collision
{
    public class Mouse
    {
        private static readonly Lazy<Mouse> Lazy = new Lazy<Mouse>(() => new Mouse());
        public static Mouse Instance
        {
            get => Lazy.Value;
        }

        private Screen screen;
        private MouseState previousMouseState;
        private MouseState currentMouseState;

        private bool isheld = false;

        public Mouse()
        {
            previousMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            currentMouseState = previousMouseState;
        }

        public void SetScreen (Screen screen)
        {
            this.screen = screen;
        }
        public void Update ()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();

            //if (CurrentMouseState != PreviousMouseState) LogMouseStates();
        }

        public bool IsLeftMouseClicked()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed &&
                   previousMouseState.LeftButton == ButtonState.Released;
        }
        public bool IsLeftMouseDown ()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Pressed;
        }
        public bool IsLeftMouseUp()
        {
            return currentMouseState.LeftButton == ButtonState.Released && previousMouseState.LeftButton == ButtonState.Pressed;
        }

        public bool IsRightMouseClicked()
        {
            return currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released;
        }
        public bool IsRightMouseDown()
        {
            return currentMouseState.RightButton == ButtonState.Pressed;
        }
        public bool IsRightMouseUp()
        {
            return currentMouseState.RightButton == ButtonState.Released;
        }

        public bool IsMiddleMouseClicked()
        {
            return currentMouseState.MiddleButton == ButtonState.Pressed && previousMouseState.MiddleButton == ButtonState.Released;
        }
        public bool IsMiddleMouseDown()
        {
            return currentMouseState.MiddleButton == ButtonState.Pressed;
        }
        public bool IsMiddleMouseUp()
        {
            return currentMouseState.MiddleButton == ButtonState.Released;
        }

        public bool MouseEntered (Rectangle rect, Screen screen)
        {
            Vector2 mousePos = GetCurrentScreenPosition(screen);
            Rectangle mouseRect = new Rectangle((int)mousePos.X, (int)mousePos.Y, 1, 1);
            Vector2 previousMousePos = GetPreviousScreenPosition(screen);
            Rectangle previousMouseRect = new Rectangle((int)previousMousePos.X, (int)previousMousePos.Y, 1, 1);

            return mouseRect.Intersects(rect) && !previousMouseRect.Intersects(rect);
        }
        public bool MouseExited(Rectangle rect, Screen screen)
        {
            Vector2 mousePos = GetCurrentScreenPosition(screen);
            Rectangle mouseRect = new Rectangle((int)mousePos.X, (int)mousePos.Y, 1, 1);
            Vector2 previousMousePos = GetPreviousScreenPosition(screen);
            Rectangle previousMouseRect = new Rectangle((int)previousMousePos.X, (int)previousMousePos.Y, 1, 1);

            return !mouseRect.Intersects(rect) && previousMouseRect.Intersects(rect);
        }
        public bool IsHovering (Rectangle rect, Screen screen)
        {
            Vector2 mousePos = GetCurrentScreenPosition(screen);
            Rectangle mouseRect = new Rectangle((int)mousePos.X, (int)mousePos.Y, 1, 1);

            //Console.WriteLine("Previous State: " + previousMouseState.Position.ToString());
            //Console.WriteLine("Current State: " + currentMouseState.Position.ToString());
            //Console.WriteLine("rect: " + rect.ToString());
            //Console.WriteLine("Intersects: " + mouseRect.Intersects(rect));

            return previousMouseState == currentMouseState && mouseRect.Intersects(rect);
        }

        public Vector2 GetCurrentScreenPosition (Screen screen)
        {
            Rectangle screenDestinationRectangle = screen.CalculateDestinationRectangle();
            Point windowPosition = CurrentWindowPosition;

            float sx = windowPosition.X - screenDestinationRectangle.X;
            float sy = windowPosition.Y - screenDestinationRectangle.Y;

            sx /= screenDestinationRectangle.Width;
            sy /= screenDestinationRectangle.Height;

            sx *= screen.Width;
            sy *= screen.Height;

            return new Vector2(sx, sy);
        }
        public Vector2 GetPreviousScreenPosition(Screen screen)
        {
            Rectangle screenDestinationRectangle = screen.CalculateDestinationRectangle();
            Point windowPosition = PreviousWindowPosition;

            float sx = windowPosition.X - screenDestinationRectangle.X;
            float sy = windowPosition.Y - screenDestinationRectangle.Y;

            sx /= screenDestinationRectangle.Width;
            sy /= screenDestinationRectangle.Height;

            sx *= screen.Width;
            sy *= screen.Height;

            return new Vector2(sx, sy);
        }

        public void LogMouseVerbose ()
        {
            string debug = "";
            debug += $"States Similar:".PadRight(25) + (CurrentMouseState == PreviousMouseState);
            debug += $" Curr Mouse Position:".PadRight(25) + CurrentScreenPosition.ToPoint().ToString();
            debug += $" Prev Mouse Position:".PadRight(25) + PreviousScreenPosition.ToPoint().ToString();
            debug += $" Mouse Rectangle:".PadRight(25) + CurrentMouseRectangle.ToString();
            debug += $" LeftMouseClicked:".PadRight(25) + IsLeftMouseClicked();
            debug += $" RightMouseClicked:".PadRight(25) + IsRightMouseClicked();
            debug += $" MiddleMouseClicked:".PadRight(25) + IsMiddleMouseClicked();

            Utils.Logger.Log(Utils.LogType.info1, debug);
        }

        public void LogMouseStates()
        {
            string debug = "[ Mouse States ]" + Environment.NewLine;
            debug += $"States Similar:".PadRight(25) + (CurrentMouseState == PreviousMouseState) + Environment.NewLine;
            debug += $" Curr Mouse Position:".PadRight(25) + CurrentScreenPosition.ToPoint().ToString() + Environment.NewLine;
            debug += $" Prev Mouse Position:".PadRight(25) + PreviousScreenPosition.ToPoint().ToString() + Environment.NewLine;
            debug += $" Curr Left Mouse: ".PadRight(25) + currentMouseState.LeftButton.ToString() + Environment.NewLine;
            debug += $" Prev Right Mouse: ".PadRight(25) + previousMouseState.LeftButton.ToString() + Environment.NewLine;

            Utils.Logger.Log(Utils.LogType.info1, debug);
        }

        public MouseState CurrentMouseState => currentMouseState;
        public MouseState PreviousMouseState => previousMouseState;

        public Point CurrentWindowPosition => currentMouseState.Position;
        public Point PreviousWindowPosition => previousMouseState.Position;
        public Vector2 CurrentScreenPosition => GetCurrentScreenPosition(screen);
        public Vector2 PreviousScreenPosition => GetPreviousScreenPosition(screen);
        public int ScrollWheelValue => currentMouseState.ScrollWheelValue;

        public Rectangle CurrentMouseRectangle => new Rectangle((int)CurrentScreenPosition.X, (int)CurrentScreenPosition.Y, 1, 1);
        public Rectangle PreviousMouseRectangle => new Rectangle((int)PreviousScreenPosition.X, (int)PreviousScreenPosition.Y, 1, 1);
    }
}
