using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarKrash.Collision.UI
{
    public class PopupTooltip : UIControl
    {
        //protected Text text;
        //public PopupTooltip(SpriteFont font, 
        //                    string text,
        //                    Color textColor,
        //                    Transform transform, 
        //                    Text.TextAlignment textAlignment = Text.TextAlignment.Center,
        //                    Text.VerticalAlignment verticalAlignment = Text.VerticalAlignment.Center) 
        //    : base(null, transform)
        //{
        //    this.text = new Text(textAlignment,
        //                         verticalAlignment,
        //                         font,
        //                         text,
        //                         textColor);
        //}
        //public PopupTooltip(Texture2D sprite, 
        //                    Transform transform, 
        //                    SpriteFont font, 
        //                    string text, 
        //                    Color textColor,
        //                    Text.TextAlignment textAlignment = Text.TextAlignment.Center,
        //                    Text.VerticalAlignment verticalAlignment = Text.VerticalAlignment.Center)
        //    : base(sprite, transform)
        //{
        //    this.text = new Text(textAlignment,
        //                         verticalAlignment,
        //                         font,
        //                         text,
        //                         textColor);
        //}

        //public bool Displayed { get; set; } = false;
        //public int Padding { get; set; } = 16;

        //public void ChangeText (string text)
        //{
        //    this.text.Value = text;
        //}

        //public override void Update(GameTime gametime)
        //{
        //    MouseState mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
        //    Vector2 stringSize = text.TextSize;
        //    Transform.Position = new Vector3(mouseState.X + Padding, mouseState.Y + Padding, 0);
        //    Transform.Size = new Vector3((int)stringSize.X, (int)stringSize.Y, 0);
        //}
        //public override void Draw(SpriteBatch spriteBatch)
        //{
        //    if (Displayed)
        //    {
        //        base.Draw(spriteBatch);
        //    }
        //}
    }
}
