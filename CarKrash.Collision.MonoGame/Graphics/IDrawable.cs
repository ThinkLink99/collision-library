using System;
using System.Collections.Generic;
using System.Text;

namespace CarKrash.Collision.Graphics
{
    public interface IDrawable
    {
        //
        // Summary:
        //     The draw order of this CarKrash.Collision.Graphics.IDrawable relative to other Microsoft.Xna.Framework.IDrawable
        //     instances.
        int DrawOrder { get; }
        //
        // Summary:
        //     Indicates if CarKrash.Collision.Graphics.CSpriteBatch.Draw(CarKrash.Collision.Graphics.CSpriteBatch)
        //     will be called.
        bool Visible { get; }

        //
        // Summary:
        //     Raised when CarKrash.Collision.Graphics.IDrawable.DrawOrder changed.
        event EventHandler<EventArgs> DrawOrderChanged;
        //
        // Summary:
        //     Raised when CarKrash.Collision.Graphics.IDrawable.Visible changed.
        event EventHandler<EventArgs> VisibleChanged;

        //
        // Summary:
        //     Called when this CarKrash.Collision.Graphics.IDrawable should draw itself.
        //
        // Parameters:
        //   gameTime:
        //     The elapsed time since the last call to CarKrash.Collision.Graphics.IDrawable.Draw(Microsoft.Xna.Framework.GameTime).
        void Draw(CSpriteBatch spriteBatch);
    }
}
