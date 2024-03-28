using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Collision.Graphics
{
    public class CSpriteBatch : IDisposable
    {
        const SpriteEffects SPRITE_EFFECT = SpriteEffects.None;

        private bool isDisposed = false;
        protected Game game;
        protected BasicEffect effect;
        protected SpriteBatch spriteBatch;
        public SpriteBatch SpriteBatch => spriteBatch;

        public CSpriteBatch(Game game)
        {
            this.game = game;
            spriteBatch = new SpriteBatch(game.GraphicsDevice);

            effect = new BasicEffect(game.GraphicsDevice);
            effect.FogEnabled = false;
            effect.TextureEnabled = true;
            effect.LightingEnabled = false;
            effect.VertexColorEnabled = true;
            effect.World = Matrix.Identity;
            effect.Projection = Matrix.Identity;
            effect.View = Matrix.Identity;
        }

        public virtual void Begin(Camera camera, bool isTextureFilteringEnabled = false)
        {
            SamplerState samplerState = (!isTextureFilteringEnabled) ? SamplerState.PointClamp : SamplerState.LinearClamp;

            if (camera is null)
            {
                Viewport vp = game.GraphicsDevice.Viewport;
                effect.Projection = Matrix.CreateOrthographicOffCenter(vp.Width, 0, vp.Height,0, 0, 1);
                effect.View = Matrix.Identity;
            }
            else
            {
                camera.UpdateMatrices();

                effect.View = camera.ViewMatrix;
                effect.Projection = camera.ProjectionMatrix;
            }

            spriteBatch.Begin(blendState: BlendState.AlphaBlend,
                              samplerState: samplerState,
                              rasterizerState: RasterizerState.CullNone,
                              effect: effect,
                              sortMode: SpriteSortMode.Deferred);
        }

        public virtual void Draw(Texture2D texture, Rectangle? sourceRectangle, Rectangle destinationRectangle, Microsoft.Xna.Framework.Color color)
        {
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
        public void Draw (Sprite sprite, Vector2 position, Vector2 size, Color color, bool centered = true)
        {
                           
        }

        
        public void Draw(Animator animator, bool centered = true)
        {
            spriteBatch.Draw(animator.CurrentAnimation.AnimationCells[animator.CurrentAnimation.CurrentFrame],
                             new Rectangle((int)animator.Position.X,
                                           (int)animator.Position.Y,
                                           animator.CurrentAnimation.FrameWidth * (int)animator.Scale.X,
                                           animator.CurrentAnimation.FrameHeight * (int)animator.Scale.Y),

                             new Rectangle(0, 0,
                                           animator.CurrentAnimation.FrameWidth,
                                           animator.CurrentAnimation.FrameHeight),
                             Microsoft.Xna.Framework.Color.White,
                             0f,
                            (centered ? Vector2.Zero : new Vector2(animator.CurrentAnimation.FrameWidth / 2, animator.CurrentAnimation.FrameHeight / 2)),

                             SPRITE_EFFECT,
                             0);
        }
        public void Draw (Texture2D texture, Vector2 position, Microsoft.Xna.Framework.Color color)
        {
            spriteBatch.Draw(texture, position, color);
        }
        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Microsoft.Xna.Framework.Color color)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, color);
        }

        public void DrawString (SpriteFont font, string text, Vector2 position, Microsoft.Xna.Framework.Color color)
        {
            SpriteBatch.DrawString(font, text, position, color);
        }
        public virtual void End()
        {
            spriteBatch.End();
        }

        public void Dispose()
        {
            if (isDisposed) return;

            spriteBatch?.Dispose();

            isDisposed = true;
        }
    }
}
