using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CarKrash.Collision
{
    public sealed class ShapeBatch : IDisposable
    {
        public const float MinLineThickness = 1f;
        public const float MaxLineThickness = 10f;

        private Game game;
        private BasicEffect effect;

        private VertexPositionColor[] vertices;
        private int[] indices;

        private int shapeCount;
        private int vertexCount;
        private int indexCount;

        private bool isStarted;
        private bool disposedValue;

        public ShapeBatch(Game game)
        {
            this.game = game;

            effect = new BasicEffect(game.GraphicsDevice);
            effect.TextureEnabled = false;
            effect.FogEnabled = false;
            effect.LightingEnabled = false;
            effect.VertexColorEnabled = true;
            effect.World = Matrix.Identity;

            Viewport vp = game.GraphicsDevice.Viewport;
            effect.Projection = Matrix.CreateOrthographicOffCenter(0, vp.Width, vp.Height, 0, 0, 1);
            effect.View = Matrix.Identity;

            const int MaxVertexCount = 1024;
            const int MaxIndexCount = MaxVertexCount * 3;

            this.vertices = new VertexPositionColor[MaxVertexCount];
            this.indices = new int[MaxIndexCount];

            this.shapeCount = 0;
            this.vertexCount = 0;
            this.indexCount = 0;

            this.isStarted = false;
        }

        public void Begin(Camera camera)
        {
            if (isStarted) throw new Exception("Batch is already started.");
            isStarted = true;

            if (camera is null)
            {
                Viewport vp = game.GraphicsDevice.Viewport;
                effect.Projection = Matrix.CreateOrthographicOffCenter(0, vp.Width, vp.Height, 0, 0, 1);
                effect.View = Matrix.Identity;
            }
            else
            {
                camera.UpdateMatrices();

                effect.View = camera.ViewMatrix;
                effect.Projection = camera.ProjectionMatrix;
            }
        }
        public void End()
        {
            Flush();
            isStarted = false;
        }
        public void Flush ()
        {
            if (shapeCount == 0) return;

            EnsureStarted();

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                game.GraphicsDevice.DrawUserIndexedPrimitives(
                    PrimitiveType.TriangleList,
                    vertices,
                    0,
                    vertexCount,
                    indices,
                    0,
                    indexCount / 3);
            }

            shapeCount = 0;
            vertexCount = 0;
            indexCount = 0;
        }

        public void EnsureStarted ()
        {
            if (!isStarted) throw new Exception("Batch not started.");
        }
        public void EnsureSpace (int shapeVertexCount, int shapeIndexCount)
        {
            if (shapeVertexCount > vertices.Length) throw new Exception($"Maximum shape vertex is : {vertices.Length}");
            if (shapeIndexCount > indices.Length) throw new Exception($"Maximum shape index is : {indices.Length}");

            if (this.vertexCount + shapeVertexCount > vertices.Length || this.indexCount + shapeIndexCount > indices.Length)
                Flush();
        }

        public void DrawRectangle (float x, float y, float width, float height, Color color)
        {
            EnsureStarted();

            const int shapeVertexCount = 4;
            const int shapeIndexCount = 16;

            EnsureSpace(shapeVertexCount, shapeIndexCount);

            float left = x;
            float right = x + width;
            float top = y;
            float bottom = y + height;

            Vector2 a = new Vector2(left, top);
            Vector2 b = new Vector2(right, top);
            Vector2 c = new Vector2(right, bottom);
            Vector2 d = new Vector2(left, bottom);

            indices[indexCount++] = 0 + vertexCount;
            indices[indexCount++] = 1 + vertexCount;
            indices[indexCount++] = 2 + vertexCount;

            indices[indexCount++] = 0 + vertexCount;
            indices[indexCount++] = 2 + vertexCount;
            indices[indexCount++] = 3 + vertexCount;

            vertices[vertexCount++] = new VertexPositionColor(a, color);
            vertices[vertexCount++] = new VertexPositionColor(b, color);
            vertices[vertexCount++] = new VertexPositionColor(c, color);
            vertices[vertexCount++] = new VertexPositionColor(d, color);

            shapeCount++;
        }
        public void DrawLine (Vector2 a, Vector2 b, float thickness, Color color)
        {

            this.EnsureStarted();

            const int shapeVertexCount = 4;
            const int shapeIndexCount = 6;

            EnsureSpace(shapeVertexCount, shapeIndexCount);

            thickness = MonoGameUtil.Clamp(thickness, MinLineThickness, MaxLineThickness);
            float halfThickness = thickness / 2;

            Vector2 e1 = b - a;
            e1.Normalize();
            e1 *= halfThickness;
            Vector2 e2 = -e1;

            Vector2 n1 = new Vector2(-e1.Y, e1.X);
            Vector2 n2 = -n1;

            Vector2 q1 = a + n1 + e2;
            Vector2 q2 = b + n1 + e1;
            Vector2 q3 = b + n2 + e1;
            Vector2 q4 = a + n2 + e2;

            indices[indexCount++] = 0 + vertexCount;
            indices[indexCount++] = 1 + vertexCount;
            indices[indexCount++] = 2 + vertexCount;

            indices[indexCount++] = 0 + vertexCount;
            indices[indexCount++] = 2 + vertexCount;
            indices[indexCount++] = 3 + vertexCount;

            vertices[vertexCount++] = new VertexPositionColor(q1, color);
            vertices[vertexCount++] = new VertexPositionColor(q2, color);
            vertices[vertexCount++] = new VertexPositionColor(q3, color);
            vertices[vertexCount++] = new VertexPositionColor(q4, color);

            shapeCount++;
        }


        public void Dispose()
        {
            if (disposedValue) return;

            effect?.Dispose();
            disposedValue = true;
        }
    }
}