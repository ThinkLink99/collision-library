using Collision.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Collision.UI
{
    public class Text : Component, Graphics.IDrawable
    {
        bool visible = true;

        [Flags]
        public enum TextAlignment { Center, Left, Right }
        [Flags]
        public enum VerticalAlignment { Center, Top, Bottom }

        Rectangle bounds;

        private TextAlignment textAlignment = TextAlignment.Center;
        private VerticalAlignment verticalAlignment = VerticalAlignment.Center;
        private SpriteFont font;
        private int drawOrder = 0;
        private string text;
        private Graphics.Color textColor;

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public Text(TextAlignment textAlignment, VerticalAlignment verticalAlignment, SpriteFont font, string text, Graphics.Color textColor, Rectangle bounds)
        {
            this.bounds = bounds;
            this.textAlignment = textAlignment;
            this.verticalAlignment = verticalAlignment;
            this.font = font;
            this.text = text;
            this.textColor = textColor;
        }

        public SpriteFont Font => font;
        public Graphics.Color Color => textColor;

        public Vector2 Position 
        { 
            get => bounds.Center.ToVector2();
            set => bounds.Location = value.ToPoint();
        }
        public Vector2 Origin
        {
            get
            {

                Vector2 origin = (TextSize * 0.5f);
                if (Position.X - origin.X > 0) origin.X = Position.X - origin.X;
                if (Position.Y - origin.Y > 0) origin.Y = Position.Y - origin.Y;

                if (textAlignment.HasFlag(TextAlignment.Left))
                    origin.X += bounds.Width / 2 - TextSize.X / 2;

                if (textAlignment.HasFlag(TextAlignment.Right))
                    origin.X -= bounds.Width / 2 - TextSize.X / 2;

                if (verticalAlignment.HasFlag(VerticalAlignment.Top))
                    origin.Y += bounds.Height / 2 - TextSize.Y / 2;

                if (verticalAlignment.HasFlag(VerticalAlignment.Bottom))
                    origin.Y -= bounds.Height / 2 - TextSize.Y / 2;

                return origin;
            }
        }

        public Vector2 TextSize
        {
            get
            {
                return font.MeasureString(text);
            }
        }
        public string Value
        {
            get => text;
            set => text = value;
        }

        public int DrawOrder => drawOrder;

        public bool Visible => visible;

        public void SetVisible (bool visible = true)
        {
            this.visible = visible;
        }

        public void Draw(CSpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, Value, Origin, Color);
        }
    }
}
