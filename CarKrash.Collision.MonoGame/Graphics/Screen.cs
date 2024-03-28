using Collision.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Collision
{
    public class Screen : IDisposable
    {
        private readonly static int MinDim = 64;
        private readonly static int MaxDim = 4096;

        private bool isSet = false;
        private bool isDisposed;
        private Game game;
        private RenderTarget2D target;

        public int Width
        {
            get => target.Width;
        }
        public int Height
        {
            get => target.Height;
        }

        public Screen (Game game, int width, int height)
        {
            width = MonoGameUtil.Clamp(width, MinDim, MaxDim);
            height = MonoGameUtil.Clamp(height, MinDim, MaxDim);

            this.game = game ?? throw new ArgumentNullException("game");
            target = new RenderTarget2D(game.GraphicsDevice, width, height);
        }
        public void Dispose()
        {
            if (isDisposed) return;
            target?.Dispose();
            isDisposed = true;
        }

        public void Set()
        {
            if (isSet) throw new Exception("Render Target is already set.");
            game.GraphicsDevice.SetRenderTarget(target);
            isSet = true;
        }
        public void Unset()
        {
            if (!isSet) throw new Exception("Render Target is not set.");
            game.GraphicsDevice.SetRenderTarget(null);
            isSet = false;
        }

        public void Present(CSpriteBatch batch, bool textureFiltering = true)
        {
            if (batch is null) throw new ArgumentNullException("batch");
#if DEBUG
            game.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.HotPink);
#else
            game.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
#endif
            Rectangle destinationRectangle = CalculateDestinationRectangle();

            batch.Begin(null, textureFiltering);
            batch.Draw(target, null, destinationRectangle, Microsoft.Xna.Framework.Color.White);
            batch.End();
        }

        internal Rectangle CalculateDestinationRectangle ()
        {
            Rectangle backBufferBounds = game.GraphicsDevice.PresentationParameters.Bounds;
            float backBufferAspectRatio = (float)backBufferBounds.Width / backBufferBounds.Height;
            float screenAspectRatio = (float)Width / Height;

            float rx = 0f;
            float ry = 0f;
            float rw = backBufferBounds.Width;
            float rh = backBufferBounds.Height;

            if (backBufferAspectRatio > screenAspectRatio)
            {
                rw = rh * screenAspectRatio;
                rx = (backBufferBounds.Width - rw) / 2f;
            }
            else if (backBufferAspectRatio < screenAspectRatio)
            {
                rh = rw / screenAspectRatio;
                ry = (backBufferBounds.Height - rh) / 2f;
            }

            Rectangle result = new Rectangle((int)rx, (int)ry, (int)rw, (int)rh);
            return result;
        }
    }
}
