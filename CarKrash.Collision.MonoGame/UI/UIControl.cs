using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Collision.Graphics;
using System.Diagnostics;
using System.Linq;

namespace Collision.UI
{
    public abstract class UIControl : GameObject
    {
        private bool visible = true;

        const int DEFAULT_WIDTH = 64;
        const int DEFAULT_HEIGHT = 64;

        protected bool hovering = true;
        protected bool entered = false;
        protected bool mouseHeld = false;

        protected Vector2 position;
        protected Vector2 scale;
        protected float rotation;
        protected Vector2 size;

        public event Action onClick;
        public event Action mouseEnter;
        public event Action mouseHover;
        public event Action mouseExit;
        public event Action mouseDown;
        public event Action mouseUp;

        /// <summary>
        /// A base level image to be drawn on screen
        /// </summary>
        public virtual Microsoft.Xna.Framework.Color Color { get => Microsoft.Xna.Framework.Color.White; }
        public bool IsVisible => visible;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(
                    ((Microsoft.Xna.Framework.Vector2)position).ToPoint(), 
                    ((Microsoft.Xna.Framework.Vector2)size).ToPoint() * ((Microsoft.Xna.Framework.Vector2)scale).ToPoint());
            }
        }

        protected UIControl()
        {

        }
        protected UIControl(Vector2 position, Vector2 scale, float rotation, Vector2 size)
        {
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
            this.size = size;
        }

        public virtual void Update(GameTime gametime, Screen screen)
        {
            if (!IsVisible) return;

            Mouse mouse = Mouse.Instance;

            if (mouse.MouseEntered(Rectangle, screen)) 
            {
                entered = true;
                mouseEnter?.Invoke(); 
            }
            else if (mouse.IsHovering(Rectangle, screen))
            {
                hovering = true;
                mouseHover?.Invoke();

                if (mouse.IsLeftMouseClicked()) { onClick?.Invoke(); }
                if (mouse.IsLeftMouseDown()) { mouseHeld = true; mouseDown?.Invoke(); }
                if (mouse.IsLeftMouseUp()) { mouseHeld = false; mouseUp?.Invoke(); }

            }
            else if (mouse.MouseExited(Rectangle, screen))
            {
                entered = false;
                mouseExit?.Invoke();
            }
            else hovering = false;
        }

        public virtual void SetVisible (bool visible = true)
        {
            this.visible = visible;

            //foreach (Component component in Components)
            //{
            //    component.SetVisible();
            //}
        }

        public void LogUIControl ()
        {
            //string debug = "";
            //debug += $"{GetType()}\n";
            //debug += $"States Similar: ".PadRight(20) + (mouse.CurrentMouseState == mouse.PreviousMouseState) + "\n";
            //debug += $"Mouse Position: ".PadRight(20) + mouseRect + "\n";
            //debug += $"Previous Mouse Position: ".PadRight(20) + previousMouseRect + "\n";
            //debug += $"Transform Rectangle: ".PadRight(20) + Rectangle + "\n";
            //debug += $"LeftMouseClicked: ".PadRight(20) + mouse.IsLeftMouseClicked() + "\n";
            //debug += $"MouseEntered: ".PadRight(20) + mouse.MouseEntered(Rectangle, screen) + "\n";
            //debug += $"MouseHovering: ".PadRight(20) + mouse.IsHovering(Rectangle, screen);

            //// TODO: Write console write-outs for UIcontrol data, Mouse data, keyboard data

            //Console.WriteLine("Size: " + size.ToPoint().ToString());
            //Console.WriteLine("MouseEntered: " + mouse.MouseEntered(Rectangle, screen));
            //Console.WriteLine("IsHovering: " + mouse.IsHovering(Rectangle, screen));
            //Console.WriteLine("MouseExited: " + mouse.MouseExited(Rectangle, screen));
            //Console.WriteLine("IsLeftMouseClicked: " + mouse.IsLeftMouseClicked());
            //Console.WriteLine("IsLeftMouseDown: " + mouse.IsLeftMouseDown());
            //Console.WriteLine("IsLeftMouseUp: " + mouse.IsLeftMouseUp());
        }
    }
}