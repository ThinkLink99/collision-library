using Collision.Graphics;
using Collision.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Collision
{
    public abstract class Scene
    {
        private List<GameObject> gameObjects;
        private List<Canvas> canvases;

        protected CGame game;
        protected Screen screen;
        protected Mouse mouse;
        protected Camera mainCamera;

        private bool disableMainCamera = false;
        private bool useTextureFiltering = true;

        private int screenWidth = 800,
                    screenHeight = 480;

        protected Scene(CGame game, int screenWidth, int screenHeight, bool useTextureFiltering = true)
        {
            this.game = game;

            Content = game.Content;
            Graphics = game.GraphicsDeviceManager;
            SpriteBatch = new CSpriteBatch(game);
            screen = new Screen(game, screenWidth, screenHeight);
            canvases = new List<Canvas>();
            this.useTextureFiltering = useTextureFiltering;

            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        protected ContentManager Content { get; } = null;
        protected Scene PreviousScene { get; } = null;
        protected GraphicsDeviceManager Graphics { get; } = null;
        protected CSpriteBatch SpriteBatch { get; } = null;

        protected List<Canvas> Canvases { get => canvases; }

        protected int ScreenWidth { get => screenWidth; set => screenWidth = value; }
        protected int ScreenHeight { get => screenHeight; set => screenHeight = value; }

        public void GetGameObjects ()
        {
            gameObjects = new List<GameObject>();
            Util.GetMembersOfType(this, typeof(GameObject))
                .ForEach(g => gameObjects.Add((GameObject)g));
            Util.GetListsOfType(this, typeof(GameObject))
                .ForEach(g => { if (!gameObjects.Contains(g)) gameObjects.Add((GameObject)g); });
        }

        public void DisableMainCamera (bool disable = true)
        {
            disableMainCamera = disable;
        }
        public void EarlyStart ()
        {
            mainCamera = new Camera(screen);
            Mouse.Instance.SetScreen(screen);
        }
        public void LateStart ()
        {
            GetGameObjects();
        }
        public void EarlyUpdate (GameTime gameTime)
        {
            GetGameObjects();

            Mouse.Instance.Update();
            Keyboard.Instance.Update();

            var ui = gameObjects.Where(g => g is UIControl).Cast<UIControl>().ToList();
            foreach (var u in ui)
                u.Update(gameTime, screen);
            foreach (Canvas canvas in Canvases) canvas.Update(gameTime, screen);
        }
        public void EarlyDraw()
        {
            screen.Set();
            game.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

            foreach (Canvas canvas in Canvases) canvas.Start(useTextureFiltering);
            SpriteBatch.Begin(camera: disableMainCamera ? null : mainCamera);

            foreach (var g in gameObjects.ToList())
            {
                g.Draw(SpriteBatch);
            }
            foreach (Canvas canvas in Canvases) canvas.Draw();
        }
        public void LateDraw()
        {
            foreach (Canvas canvas in Canvases) canvas.End();
            SpriteBatch.End();
            screen.Unset();

            screen.Present(SpriteBatch, false);
        }

        public abstract void Start();
        public abstract void Update(GameTime gameTime);
        public abstract void LateUpdate(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
