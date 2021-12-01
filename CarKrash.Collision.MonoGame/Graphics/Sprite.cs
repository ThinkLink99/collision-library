using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CarKrash.Collision.Graphics
{
    public class Sprite : Component, IDrawable
    {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 size;
        private float rotation;
        private Vector2 scale;
        private Color color;
        private int topSlice = 0,
                    bottomSlice = 0,
                    leftSlice = 0,
                    rightSlice = 0,
                    drawOrder = 0;

        private bool useSlicing = false;
        protected bool isVisible;

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public Sprite(Texture2D texture)
        {
            isVisible = true;
            this.texture = texture;

            this.position = Vector2.Zero;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = Color.White;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, Vector2 position)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = Color.White;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, Vector2 position, Vector2 size)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = Color.White;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, Vector2 position, Vector2 size, Vector2 scale)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = 0f;
            this.color = Color.White;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, Vector2 position, Vector2 size, Vector2 scale, float rotation)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = rotation;
            this.color = Color.White;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, Color color)
        {
            isVisible = true;
            this.texture = texture;

            this.position = Vector2.Zero;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = color;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, Color color, Vector2 position)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = color;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, Color color, Vector2 position, Vector2 size)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = color;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, Color color, Vector2 position, Vector2 size, Vector2 scale)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = 0f;
            this.color = color;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, Color color, Vector2 position, Vector2 size, Vector2 scale, float rotation)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = rotation;
            this.color = color;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, int drawOrder)
        {
            isVisible = true;
            this.texture = texture;
            this.drawOrder = drawOrder;

            this.position = Vector2.Zero;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, int drawOrder, Vector2 position)
        {
            isVisible = true;
            this.texture = texture;
            this.drawOrder = drawOrder;

            this.position = position;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, int drawOrder, Vector2 position, Vector2 size)
        {
            isVisible = true;
            this.texture = texture;
            this.drawOrder = drawOrder;

            this.position = position;
            this.size = size;
            this.scale = Vector2.One;
            this.rotation = 0f;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, int drawOrder, Vector2 position, Vector2 size, Vector2 scale)
        {
            isVisible = true;
            this.texture = texture;
            this.drawOrder = drawOrder;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = 0f;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, int drawOrder, Vector2 position, Vector2 size, Vector2 scale, float rotation)
        {
            isVisible = true;
            this.texture = texture;
            this.drawOrder = drawOrder;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = rotation;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, int drawOrder, Color color)
        {
            isVisible = true;
            this.texture = texture;
            this.drawOrder = drawOrder;
            this.color = color;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, int drawOrder, Color color, Vector2 position)
        {
            isVisible = true;
            this.texture = texture;
            this.drawOrder = drawOrder;
            this.color = color;

            this.position = position;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, int drawOrder, Color color, Vector2 position, Vector2 size)
        {
            isVisible = true;
            this.texture = texture;
            this.drawOrder = drawOrder;
            this.color = color;

            this.position = position;
            this.size = size;
            this.scale = Vector2.One;
            this.rotation = 0f;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, int drawOrder, Color color, Vector2 position, Vector2 size, Vector2 scale)
        {
            isVisible = true;
            this.texture = texture;
            this.drawOrder = drawOrder;
            this.color = color;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = 0f;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, int drawOrder, Color color, Vector2 position, Vector2 size, Vector2 scale, float rotation)
        {
            isVisible = true;
            this.texture = texture;
            this.drawOrder = drawOrder;
            this.color = color;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = rotation;

            leftSlice = 0;
            rightSlice = texture.Width;
            topSlice = 0;
            bottomSlice = texture.Height;

            useSlicing = false;

            SetSlices(0, texture.Width, 0, texture.Height);
        }
        public Sprite(Texture2D texture, int leftSlice, int rightSlice, int topSlice, int bottomSlice)
        {
            isVisible = true;
            this.texture = texture;

            this.position = Vector2.Zero;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = Color.White;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = Color.White;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position, Vector2 size)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = Color.White;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position, Vector2 size, Vector2 scale)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = 0f;
            this.color = Color.White;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position, Vector2 size, Vector2 scale, float rotation)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = rotation;
            this.color = Color.White;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, Color color, int leftSlice, int rightSlice, int topSlice, int bottomSlice)
        {
            isVisible = true;
            this.texture = texture;

            this.position = Vector2.Zero;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = color;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, Color color, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = color;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, Color color, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position, Vector2 size)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = color;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, Color color, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position, Vector2 size, Vector2 scale)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = 0f;
            this.color = color;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, Color color, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position, Vector2 size, Vector2 scale, float rotation)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = rotation;
            this.color = color;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int drawOrder, int leftSlice, int rightSlice, int topSlice, int bottomSlice)
        {
            isVisible = true;
            this.texture = texture;
            this.drawOrder = drawOrder;
            this.position = Vector2.Zero;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.color = Color.White;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int drawOrder, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.drawOrder = drawOrder;
            this.color = Color.White;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int drawOrder, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position, Vector2 size)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.drawOrder = drawOrder;
            this.color = Color.White;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int drawOrder, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position, Vector2 size, Vector2 scale)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = 0f;
            this.drawOrder = drawOrder;
            this.color = Color.White;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int drawOrder, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position, Vector2 size, Vector2 scale, float rotation)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = rotation;
            this.drawOrder = drawOrder;
            this.color = Color.White;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int drawOrder, Color color, int leftSlice, int rightSlice, int topSlice, int bottomSlice)
        {
            isVisible = true;
            this.texture = texture;
            this.drawOrder = drawOrder;
            this.color = color;
            this.position = Vector2.Zero;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int drawOrder, Color color, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = new Vector2(texture.Width, texture.Height);
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.drawOrder = drawOrder;
            this.color = color;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int drawOrder, Color color, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position, Vector2 size)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = Vector2.One;
            this.rotation = 0f;
            this.drawOrder = drawOrder;
            this.color = color;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int drawOrder, Color color, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position, Vector2 size, Vector2 scale)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = 0f;
            this.drawOrder = drawOrder;
            this.color = color;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int drawOrder, Color color, int leftSlice, int rightSlice, int topSlice, int bottomSlice, bool useSlicing, Vector2 position, Vector2 size, Vector2 scale, float rotation)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = rotation;
            this.drawOrder = drawOrder;
            this.color = color;

            this.useSlicing = useSlicing;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }
        public Sprite(Texture2D texture, int drawOrder, Color color, int leftSlice, int rightSlice, int topSlice, int bottomSlice, Vector2 position, Vector2 size, Vector2 scale, float rotation)
        {
            isVisible = true;
            this.texture = texture;

            this.position = position;
            this.size = size;
            this.scale = scale;
            this.rotation = rotation;
            this.drawOrder = drawOrder;
            this.color = color;

            useSlicing = true;

            SetSlices(leftSlice, rightSlice, topSlice, bottomSlice);
        }

        public void SetVisible(bool isVisible)
        {
            this.isVisible = isVisible;
            VisibleChanged?.Invoke(this, new EventArgs());
        }
        public void SetDrawOrder (int drawOrder)
        {
            this.drawOrder = drawOrder;
            DrawOrderChanged?.Invoke(this, new EventArgs());
        }

        public void SetSlices (int leftSlice, int rightSlice, int topSlice, int bottomSlice)
        {
            this.leftSlice = leftSlice;
            this.rightSlice = rightSlice;
            this.topSlice = topSlice;
            this.bottomSlice = bottomSlice;
        }

        public bool GetSplicedColorData (out Microsoft.Xna.Framework.Color[] topLeft, out Microsoft.Xna.Framework.Color[] topMiddle, out Microsoft.Xna.Framework.Color[] topRight,
                                         out Microsoft.Xna.Framework.Color[] midLeft, out Microsoft.Xna.Framework.Color[] midMiddle, out Microsoft.Xna.Framework.Color[] midRight,
                                         out Microsoft.Xna.Framework.Color[] botLeft, out Microsoft.Xna.Framework.Color[] botMiddle, out Microsoft.Xna.Framework.Color[] botRight)
        {
            try
            {
                // create new Color arrays for each slice
                topLeft = new Microsoft.Xna.Framework.Color[TopLeftSlice.Width * TopLeftSlice.Height];
                topMiddle = new Microsoft.Xna.Framework.Color[TopMiddleSlice.Width * TopMiddleSlice.Height];
                topRight = new Microsoft.Xna.Framework.Color[TopRightSlice.Width * TopRightSlice.Height];

                midLeft = new Microsoft.Xna.Framework.Color[MiddleLeftSlice.Width * MiddleLeftSlice.Height];
                midMiddle = new Microsoft.Xna.Framework.Color[MiddleMiddleSlice.Width * MiddleMiddleSlice.Height];
                midRight = new Microsoft.Xna.Framework.Color[MiddleRightSlice.Width * MiddleRightSlice.Height];

                botLeft = new Microsoft.Xna.Framework.Color[BottomLeftSlice.Width * BottomLeftSlice.Height];
                botMiddle = new Microsoft.Xna.Framework.Color[BottomMiddleSlice.Width * BottomMiddleSlice.Height];
                botRight = new Microsoft.Xna.Framework.Color[BottomRightSlice.Width * BottomRightSlice.Height];

                // fill array with data from slice section
                texture.GetData(0, TopLeftSlice, topLeft, 0, topLeft.Length);
                texture.GetData(0, TopMiddleSlice, topMiddle, 0, topMiddle.Length);
                texture.GetData(0, TopRightSlice, topRight, 0, topRight.Length);

                texture.GetData(0, MiddleLeftSlice, midLeft, 0, midLeft.Length);
                texture.GetData(0, MiddleMiddleSlice, midMiddle, 0, midMiddle.Length);
                texture.GetData(0, MiddleRightSlice, midRight, 0, midRight.Length);

                texture.GetData(0, BottomLeftSlice, botLeft, 0, botLeft.Length);
                texture.GetData(0, BottomMiddleSlice, botMiddle, 0, botMiddle.Length);
                texture.GetData(0, BottomRightSlice, botRight, 0, botRight.Length);

                return true;
            }
            catch (Exception ex)
            {
                topLeft = new Microsoft.Xna.Framework.Color[0];
                topMiddle = new Microsoft.Xna.Framework.Color[0];
                topRight = new Microsoft.Xna.Framework.Color[0];
                midLeft = new Microsoft.Xna.Framework.Color[0];
                midMiddle = new Microsoft.Xna.Framework.Color[0];
                midRight = new Microsoft.Xna.Framework.Color[0];
                botLeft = new Microsoft.Xna.Framework.Color[0];
                botMiddle = new Microsoft.Xna.Framework.Color[0];
                botRight = new Microsoft.Xna.Framework.Color[0];

                Console.WriteLine($"Error Message: {ex.Message}");
                return false;
            }
        }

        public void DrawSliceBounds(ShapeBatch batcher)
        {
            batcher.DrawRectangle (0, topSlice, Width, 1, Microsoft.Xna.Framework.Color.LimeGreen);
            batcher.DrawRectangle (leftSlice, 0, 1, Height, Microsoft.Xna.Framework.Color.LimeGreen);
            batcher.DrawRectangle (Width - rightSlice, 0, 1, Height, Microsoft.Xna.Framework.Color.LimeGreen);
            batcher.DrawRectangle (0, Height - bottomSlice, Width, 1, Microsoft.Xna.Framework.Color.LimeGreen);
        }
        public void Draw(CSpriteBatch spriteBatch)
        {
            if (Visible)
            {
                if (UseSlicing)
                {
                    if (GetSplicedColorData(out Microsoft.Xna.Framework.Color[] topLeft, out Microsoft.Xna.Framework.Color[] topMiddle, out Microsoft.Xna.Framework.Color[] topRight,
                                                   out Microsoft.Xna.Framework.Color[] midLeft, out Microsoft.Xna.Framework.Color[] midMiddle, out Microsoft.Xna.Framework.Color[] midRight,
                                                   out Microsoft.Xna.Framework.Color[] botLeft, out Microsoft.Xna.Framework.Color[] botMiddle, out Microsoft.Xna.Framework.Color[] botRight))
                    {
                        // create new image with size "size"
                        var tex = new Texture2D(spriteBatch.SpriteBatch.GraphicsDevice, (int)size.X, (int)size.Y);

                        int width = (int)size.X,
                            height = (int)size.Y;

                        Microsoft.Xna.Framework.Color[] colorData = new Microsoft.Xna.Framework.Color[(int)size.X * (int)size.Y];

                        // loop through sprite texture
                        int drawmiddlex = width / TopMiddleSlice.Width - 1;
                        int drawmiddley = height / MiddleLeftSlice.Height - 1;

                        for (int i = 0; i < drawmiddlex; i++)
                        {
                            DrawSlice(ref colorData, topMiddle,
                                  (i * TopMiddleSlice.Width) + TopMiddleSlice.Left,
                                  TopMiddleSlice.Top,
                                  TopMiddleSlice.Height, TopMiddleSlice.Width, tex.Width);
                        }

                        for (int i = 0; i < drawmiddley; i++)
                        {
                            DrawSlice(ref colorData, midLeft,
                                  MiddleLeftSlice.Left,
                                  (i * MiddleLeftSlice.Height) + MiddleLeftSlice.Top,
                                  MiddleLeftSlice.Height, MiddleLeftSlice.Width, tex.Width);
                        }

                        for (int i = 0; i < drawmiddlex; i++)
                            for (int j = 0; j < drawmiddley; j++)
                            {
                                DrawSlice(ref colorData, midMiddle,
                                      (i * MiddleMiddleSlice.Width) + MiddleMiddleSlice.Left,
                                      (j * MiddleMiddleSlice.Height) + MiddleMiddleSlice.Top,
                                      MiddleMiddleSlice.Height, MiddleMiddleSlice.Width, tex.Width);
                            }

                        for (int i = 0; i < drawmiddley; i++)
                        {
                            DrawSlice(ref colorData, midRight,
                                  width - MiddleRightSlice.Width,
                                  (i * MiddleLeftSlice.Height) + MiddleRightSlice.Top,
                                  MiddleRightSlice.Height, MiddleRightSlice.Width, tex.Width);
                        }

                        for (int i = 0; i < drawmiddlex; i++)
                        {
                            DrawSlice(ref colorData, botMiddle,
                                  (i * BottomMiddleSlice.Width) + BottomMiddleSlice.Left,
                                  height - BottomMiddleSlice.Height,
                                  BottomMiddleSlice.Height, BottomMiddleSlice.Width, tex.Width);
                        }

                        DrawSlice(ref colorData, topLeft, TopLeftSlice, tex.Width);

                        DrawSlice(ref colorData, topRight, TopRightSlice, tex.Width);

                        DrawSlice(ref colorData, botLeft, BottomLeftSlice, tex.Width);

                        DrawSlice(ref colorData, botRight, BottomRightSlice, tex.Width);

                        tex.SetData(colorData);

                        spriteBatch.Draw(tex, null, new Rectangle(position.ToPoint(), (size * scale).ToPoint()), color);
                    }
                }
                else
                {
                    spriteBatch.Draw(this.texture, null, new Rectangle(position.ToPoint(), (size * scale).ToPoint()), color);
                }
            }
        }
        private void DrawSlice(ref Microsoft.Xna.Framework.Color[] colorData, Microsoft.Xna.Framework.Color[] slice, int startX, int startY, int sliceHeight, int sliceWidth, int textureWidth)
        {
            for (int y = startY; y < startY + sliceHeight; y++)
                for (int x = startX; x < startX + sliceWidth; x++)
                {
                    int cdIndex = MonoGameUtil.Get1DArrayIndex(x, y, textureWidth);
                    int sIndex = MonoGameUtil.Get1DArrayIndex(x - startX, y - startY, sliceWidth);
                    colorData[cdIndex] = slice[sIndex];
                }
        }
        private void DrawSlice(ref Microsoft.Xna.Framework.Color[] colorData, Microsoft.Xna.Framework.Color[] slice, Rectangle sliceRect, int textureWidth)
        {
            for (int y = sliceRect.Top; y < sliceRect.Top + sliceRect.Height; y++)
                for (int x = sliceRect.Left; x < sliceRect.Left + sliceRect.Width; x++)
                {
                    int cdIndex = MonoGameUtil.Get1DArrayIndex(x, y, textureWidth);
                    int sIndex = MonoGameUtil.Get1DArrayIndex(x - sliceRect.Left, y - sliceRect.Top, sliceRect.Width);
                    colorData[cdIndex] = slice[sIndex];
                }
        }


        public Texture2D Texture => texture;
        public Color Color { get => color; set => color = value; }
        public int DrawOrder => drawOrder;
        public bool Visible => isVisible;

        public int Width => texture.Width;
        public int Height => texture.Height;

        public bool UseSlicing { get => useSlicing; set => useSlicing = value; }

        public int LeftSlice => leftSlice;
        public int RightSlice => rightSlice;
        public int TopSlice => topSlice;
        public int BottomSlice => bottomSlice;

        public Rectangle TopLeftSlice => new Rectangle(0, 0, leftSlice, topSlice);
        public Rectangle TopMiddleSlice => new Rectangle(leftSlice, 0, Width - (leftSlice + rightSlice), topSlice);
        public Rectangle TopRightSlice => new Rectangle(Width - rightSlice, 0, rightSlice, topSlice);

        public Rectangle MiddleLeftSlice => new Rectangle(0, topSlice, leftSlice, Height - (topSlice + bottomSlice));
        public Rectangle MiddleMiddleSlice => new Rectangle(leftSlice, topSlice, TopMiddleSlice.Width, MiddleLeftSlice.Height);
        public Rectangle MiddleRightSlice => new Rectangle(Width - rightSlice, topSlice, rightSlice, MiddleLeftSlice.Height);

        public Rectangle BottomLeftSlice => new Rectangle(0, (Height) - bottomSlice, leftSlice, bottomSlice);
        public Rectangle BottomMiddleSlice => new Rectangle(leftSlice, (Height) - bottomSlice, TopMiddleSlice.Width, bottomSlice);
        public Rectangle BottomRightSlice => new Rectangle(Width - rightSlice, (Height) - bottomSlice, rightSlice, bottomSlice);

        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Size { get => size; set => size = value; }
        public float Rotation { get => rotation; set => rotation = value; }
        public Vector2 Scale { get => scale; set => scale = value; }

        public static Sprite Copy (Sprite copy)
        {
            return new Sprite(copy.texture, copy.drawOrder, copy.color, copy.leftSlice, copy.rightSlice, copy.topSlice, copy.bottomSlice, copy.useSlicing, copy.position, copy.size, copy.scale, copy.rotation);
        }
    }
}
