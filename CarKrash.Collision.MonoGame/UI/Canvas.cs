using Collision.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Collision.UI
{
    public sealed class Canvas
    {
        private bool started = false;
        private bool visible = true;
        private readonly List<UIControl> uiElements;
        private readonly CSpriteBatch spriteBatch;

        public Canvas(Game game)
        {
            this.uiElements = new List<UIControl>();
            this.spriteBatch = new CSpriteBatch(game);
        }
        public Canvas(List<UIControl> uiElements, Game game)
        {
            this.uiElements = uiElements;
            this.spriteBatch = new CSpriteBatch(game);
        }

        public bool Visible
        {
            get => visible;
            set => visible = value;
        }

        public void AddUIElement (UIControl uiElement)
        {
            uiElements.Add(uiElement);
        }
        public void AddUIElementRange(IEnumerable<UIControl> uiElements)
        {
            this.uiElements.AddRange(uiElements);
        }
        public void RemoveUIElement(UIControl uiElement)
        {
            uiElements.Remove(uiElement);
        }
        public void RemoveUIElementRange(int index, int count)
        {
            this.uiElements.RemoveRange(index, count);
        }

        public void Start (bool isTexturingFilteringEnabled = false)
        {
            //started = true;
            spriteBatch.Begin(null, isTexturingFilteringEnabled);
        }
        public void Draw()
        {
            //if (!started) throw new Exception("Canvas has not been started!");

            if (!visible) return; // if the canvas isn't visible then we won't waste time null checking. Just end the function.
            if (uiElements == null) return; // if uiElements is null, we don't want to waste time running a for each loop, just exit.

            foreach (UIControl uiElement in uiElements)
            {
                uiElement.Draw(spriteBatch);
            }
        }
        public void Update (GameTime gameTime, Screen screen)
        {
            //if (!started) throw new Exception("Canvas has not been started!");
            if (!visible) return; // if the canvas isn't visible then we won't waste time null checking. Just end the function.
            if (uiElements == null) return; // if uiElements is null, we don't want to waste time running a for each loop, just exit.

            foreach (UIControl uiElement in uiElements)
            {
                uiElement.Update(gameTime, screen);
            }
        }
        public void End()
        {
            //started = false;
            spriteBatch.End();
        }
    }
}
