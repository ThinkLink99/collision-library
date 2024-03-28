using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Collision.Graphics;
using System;

namespace Collision.UI
{
    public class Button : UIControl
    {
        Graphics.Color origColor = Graphics.Color.White;

        public Button(Sprite texture)
            : base()
        {
            AddComponent(texture);
        }
        public Button(Sprite texture, Graphics.Color color)
            : base()
        {
            AddComponent(texture);
            origColor = color;
        }
        // TODO: Write constructor taking in a size for button
        public Button(string text, SpriteFont font)
            : base(size: font.MeasureString(text), position: Vector2.Zero, scale: Vector2.One, rotation: 0f)
        {
            AddComponent(new Text(Text.TextAlignment.Center, Text.VerticalAlignment.Center, font, text, Graphics.Color.Black, new Rectangle(0, 0, (int)size.X, (int)size.Y)));
        }
        public Button(string text, Sprite background, SpriteFont font)
            : base(size: new Vector2(background.Width, background.Height), position: Vector2.Zero, scale: Vector2.One, rotation: 0f)
        {
            AddComponent(Sprite.Copy(background));
            FindComponent<Sprite>().Position = position;
            FindComponent<Sprite>().Size = size;
            AddComponent(new Text(Text.TextAlignment.Center, Text.VerticalAlignment.Center, font, text, Graphics.Color.Black, new Rectangle(0, 0, (int)size.X, (int)size.Y)));
        }
        public Button(string text, SpriteFont font, Graphics.Color textColor, Sprite background, Vector2 position, Graphics.Color color, Text.TextAlignment textAlignment = Text.TextAlignment.Center, Text.VerticalAlignment verticalAlignment = Text.VerticalAlignment.Center)
            : base(size: new Vector2(background.Width, background.Height), position: Vector2.Zero, scale: Vector2.One, rotation: 0f)
        {
            AddComponent(Sprite.Copy(background));
            AddComponent(new Text(textAlignment,
                                 verticalAlignment,
                                 font,
                                 text,
                                 textColor,
                                 new Rectangle((int)position.X, (int)position.Y, background.Width, background.Height)));

            this.origColor = color;
        }
        public Button(string text, SpriteFont font, Graphics.Color textColor, Sprite background, Vector2 position, Vector2 size, Graphics.Color color, Text.TextAlignment textAlignment = Text.TextAlignment.Center, Text.VerticalAlignment verticalAlignment = Text.VerticalAlignment.Center)
            : base()
        {
            base.size = size;
            scale = Vector2.One;
            rotation = 0f;

            AddComponent(Sprite.Copy(background));
            FindComponent<Sprite>().Position = position;
            FindComponent<Sprite>().Size = size;
            AddComponent(new Text(textAlignment,
                                 verticalAlignment,
                                 font,
                                 text,
                                 textColor,
                                 new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y)));

            this.origColor = color;
        }

        public override void Update(GameTime gametime, Screen screen)
        {
            base.Update(gametime, screen);

            if (entered || hovering)
            {
                //if (hovering) Utils.Logger.Log(Utils.LogType.warning, "Mouse is hovering over control");
                FindComponent<Sprite>().Color = new Graphics.Color(Microsoft.Xna.Framework.Color.Lerp(origColor, Microsoft.Xna.Framework.Color.Black, .25f).ToVector3());
            }
            else
            {
                FindComponent<Sprite>().Color = origColor;
            }
        }
        public override void SetVisible(bool visible = true)
        {
            Text.SetVisible(visible);
            base.SetVisible(visible);
        }

        public Text Text => FindComponent<Text>();
    }
}