using Collision.Graphics;

namespace Collision
{
    /// <summary>
    /// Handles drawing of typical screen components, such as animators, UIControls, etc.
    /// </summary>
    public abstract class CGame : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_WIDTH_DEFAULT = 1920;
        const int WINDOW_HEIGHT_DEFAULT = 1080;

        private bool isFullscreen = false;
        private bool isBorderless = false;
        private int windowWidth = WINDOW_WIDTH_DEFAULT;
        private int windowHeight = WINDOW_HEIGHT_DEFAULT;

        protected Color screenClearColor = Color.CornflowerBlue;

        private Microsoft.Xna.Framework.GraphicsDeviceManager graphics;
        protected Scene currentScene;
        protected Scene nextScene;

        protected CGame (bool isFullscreen, bool isBorderless, int windowWidth, int windowHeight)
        {
            this.isFullscreen = isFullscreen;
            this.isBorderless = isBorderless;
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;

            graphics = new Microsoft.Xna.Framework.GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = this.windowWidth;
            graphics.PreferredBackBufferHeight = this.windowHeight;


            graphics.IsFullScreen = this.isFullscreen;
            graphics.SynchronizeWithVerticalRetrace = true;

            IsFixedTimeStep = true;
            IsMouseVisible = true;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = this.windowWidth;
            graphics.PreferredBackBufferHeight = this.windowHeight;
            graphics.SynchronizeWithVerticalRetrace = true;
            graphics.IsFullScreen = this.isFullscreen;
            graphics.ApplyChanges();

            Utils.Logger.Initialize(System.ConsoleColor.Cyan);
            Utils.Logger.Log(Utils.LogType.info2, "Logger Initialized");

            base.Initialize();
        }
        protected override void LoadContent()
        {
            currentScene.EarlyStart();
            currentScene.Start();
            currentScene.LateStart();


            base.LoadContent();
        }
        protected override bool BeginDraw()
        {
            graphics.GraphicsDevice.Clear(screenClearColor);

            currentScene.EarlyDraw();

            return base.BeginDraw();
        }
        protected override void BeginRun()
        {
            base.BeginRun();
        }
        protected override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            currentScene.Draw(gameTime);

            base.Draw(gameTime);
        }
        protected override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (nextScene != null)
            {
                currentScene = nextScene;
                
                currentScene.EarlyStart();
                currentScene.Start();
                currentScene.LateStart();

                nextScene = null;
            }

            currentScene.EarlyUpdate(gameTime);
            currentScene.Update(gameTime);
            currentScene.LateUpdate(gameTime);

            base.Update(gameTime);
        }
        protected override void EndDraw()
        {
            currentScene.LateDraw();

            Utils.Logger.WriteLogs();

            base.EndDraw();
        }
        protected override void EndRun()
        {
            base.EndRun();
        }

        /// <summary>
        /// Takes scene and sets it as the new currentScene
        /// </summary>
        /// <param name="scene"></param>
        /// <returns>True; if <paramref name="scene"/> is not the same as currentScene or nextScene</returns>
        public bool ChangeScene(Scene scene)
        {
            if (scene == currentScene || scene == nextScene) { return false; }
            nextScene = scene;
            nextScene.GetGameObjects();
            return true;
        }

        public Scene CurrentScene { get => currentScene; }
        public Microsoft.Xna.Framework.GraphicsDeviceManager GraphicsDeviceManager { get => graphics; set => graphics = value; }
    }

    public class GameManager
    {
        private static readonly System.Lazy<GameManager> Lazy = new System.Lazy<GameManager>(() => new GameManager());
        public static GameManager Instance
        {
            get => Lazy.Value;
        }
    }
}
