using System;
using System.Collections.Generic;
using System.Text;

namespace Collision.Graphics
{
    public interface IDrawable
    {
        //
        // Summary:
        //     The draw order of this Collision.Graphics.IDrawable relative to other Microsoft.Xna.Framework.IDrawable
        //     instances.
        int DrawOrder { get; }
        //
        // Summary:
        //     Indicates if Collision.Graphics.CSpriteBatch.Draw(Collision.Graphics.CSpriteBatch)
        //     will be called.
        bool Visible { get; }

        //
        // Summary:
        //     Raised when Collision.Graphics.IDrawable.DrawOrder changed.
        event EventHandler<EventArgs> DrawOrderChanged;
        //
        // Summary:
        //     Raised when Collision.Graphics.IDrawable.Visible changed.
        event EventHandler<EventArgs> VisibleChanged;

        //
        // Summary:
        //     Called when this Collision.Graphics.IDrawable should draw itself.
        //
        // Parameters:
        //   gameTime:
        //     The elapsed time since the last call to Collision.Graphics.IDrawable.Draw(Microsoft.Xna.Framework.GameTime).
        void Draw(CSpriteBatch spriteBatch);
    }
}
