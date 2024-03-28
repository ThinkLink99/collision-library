using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Collision.Graphics
{
    public class Spritesheet
    {
        protected int spriteWidth = 0,
                      spriteHeight = 0,
                      numRows = 0,
                      numCols = 0;

        protected string filename;
        protected Dictionary<string, Sprite> textures;

        public Sprite this[int index]
        {
            get
            {
                if (textures.Count < index) throw new System.OverflowException($"index of {index} is greater than textures count of {textures.Count}");
                return Sprite.Copy(textures[filename + "-" + index]);
            }
            set
            {
                if (textures.Count < index) throw new System.OverflowException($"index of {index} is greater than textures count of {textures.Count}");
                textures[filename + "-" + index] = Sprite.Copy(value);
            }
        }
        public Sprite this[string index]
        {
            get
            {
                if (!textures.ContainsKey(index)) throw new System.OverflowException($"textures does not contain key \"{index}\"");
                return Sprite.Copy(textures[index]);
            }
            set
            {
                if (!textures.ContainsKey(index)) throw new System.OverflowException($"textures does not contain key \"{index}\"");
                textures[index] = Sprite.Copy(value);
            }
        }

        public Spritesheet(GraphicsDevice graphics, Texture2D spritesheetTexture, int spriteWidth, int spriteHeight)
        {
            this.spriteHeight = spriteHeight;
            this.spriteWidth = spriteWidth;

            numRows = spritesheetTexture.Height / spriteHeight;
            numCols = spritesheetTexture.Width / spriteWidth;

            CreateTextures(graphics, spritesheetTexture);

            spritesheetTexture.Dispose();
        }

        protected void CreateTextures (GraphicsDevice graphics, Texture2D spritesheetTexture)
        {
            filename = spritesheetTexture.Name;
            textures = new Dictionary<string, Sprite>();
            int i = 0;
            for (int y = 0; y < numRows; y++)
            {
                for (int x = 0; x < numCols; x++)
                {
                    int cellX = x * spriteWidth,
                        cellY = y * spriteHeight;
                    Rectangle sourceRect = new Rectangle(cellX, cellY, spriteWidth, spriteHeight);
                    Texture2D cellTexture = new Texture2D(graphics, sourceRect.Width, sourceRect.Height);
                    Microsoft.Xna.Framework.Color[] data = new Microsoft.Xna.Framework.Color[sourceRect.Width * sourceRect.Height];
                    spritesheetTexture.GetData(0, sourceRect, data, 0, data.Length);
                    cellTexture.SetData(data);

                    textures.Add($"{spritesheetTexture.Name}-{i}", new Sprite(cellTexture));
                    i++;
                }
            }

        }
        
        /// <summary>
        /// Returns reference to sprite for maintaining changes to spritesheet after initial creation
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Sprite GetSprite (int index)
        {
            if (index < 0 || index >= textures.Count) throw new System.ArgumentOutOfRangeException("index");
            return textures[filename + "-" + index];
        }

        public string Filename => filename;
        public Dictionary<string, Sprite> Textures => textures;

        public int Rows => numRows;
        public int Columns => numCols;

        public int CellWidth => spriteWidth;
        public int CellHeight => spriteHeight;
    }
}
