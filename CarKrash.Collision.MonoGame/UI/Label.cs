using Collision.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Collision.UI
{
    public class Label : UIControl
    {
        public Text Text => FindComponent<Text>();

        public Label(string text, SpriteFont font, Graphics.Color textColor)
            : base(Vector2.Zero, Vector2.One, 0f, font.MeasureString(text))
        {
            AddComponent(new Text(Text.TextAlignment.Center, Text.VerticalAlignment.Center, font, text, textColor, new Rectangle(0, 0, (int)size.X, (int)size.Y)));
        }
        public Label(string text, SpriteFont font, Graphics.Color textColor, Sprite background)
            : base(Vector2.Zero, Vector2.One, 0f, new Vector2(background.Width, background.Height))
        {
            AddComponent(Sprite.Copy(background));
            AddComponent(new Text(Text.TextAlignment.Center, Text.VerticalAlignment.Center, font, text, textColor, new Rectangle(0, 0, (int)size.X, (int)size.Y)));
        }
        public Label(string text, SpriteFont font, Graphics.Color textColor, Sprite background, Vector2 position, Vector2 size)
            : base(position, Vector2.One, 0f, size)
        {
            AddComponent(Sprite.Copy(background));
            FindComponent<Sprite>().Position = position;
            FindComponent<Sprite>().Size = size;
            AddComponent(new Text(Text.TextAlignment.Center, Text.VerticalAlignment.Center, font, text, textColor, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y)));
        }
        public Label(string text, SpriteFont font, Graphics.Color textColor, Rectangle bounds, Text.TextAlignment textAlignment = Text.TextAlignment.Center, Text.VerticalAlignment verticalAlignment = Text.VerticalAlignment.Center) 
            : base()
        {
            AddComponent(new Text(textAlignment, verticalAlignment, font, text, textColor, bounds));
        }

        public override void SetVisible(bool visible = true)
        {
            Text.SetVisible(visible);

            base.SetVisible(visible);
        }
    }
}