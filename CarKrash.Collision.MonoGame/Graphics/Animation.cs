using Microsoft.Xna.Framework.Graphics;

namespace CarKrash.Collision.Graphics
{
    public class Animation
    {
        protected int frameWidth = 0;
        protected int frameHeight = 0;
        protected int currentFrame = 0;
        protected float frameSpeed = 0;
        protected int frameCount = 0;
        protected bool isLooping = false;
        protected bool isSingleSpriteSheet = false;
        protected Texture2D spritesheet = null;
        protected Texture2D[] animationCells;

        public Animation(int frameCount,
                        Texture2D spritesheet,
                        bool isSingleFrame = false)
        {
            this.frameCount = frameCount;
            isLooping = true;
            frameSpeed = 0.2f;

            frameHeight = spritesheet.Height;
            if (isSingleFrame)
            {
                this.animationCells = new Texture2D[] { spritesheet };
                frameWidth = spritesheet.Width;
            }
            else
            {
                this.spritesheet = spritesheet;
                frameWidth = spritesheet.Width / frameCount;
            }
            isSingleSpriteSheet = isSingleFrame;
        }
        public Animation(int frameCount,
                        params Texture2D[] spritesheet)
        {
            this.frameCount = frameCount;
            this.animationCells = spritesheet;
            isLooping = true;
            frameSpeed = 0.2f;

            frameHeight = spritesheet[0].Height;
            frameWidth = spritesheet[0].Width;
            isSingleSpriteSheet = false;
        }

        public Texture2D Spritesheet => spritesheet;
        public Texture2D[] AnimationCells => animationCells;

        public int CurrentFrame { get => currentFrame; set => currentFrame = value; }
        public int FrameCount { get => frameCount; }
        public int FrameHeight { get => frameHeight; }
        public int FrameWidth { get => frameWidth; }
        public float FrameSpeed { get => frameSpeed; }

        public bool IsSingleSpritesheet => animationCells != null ? false : true;
    }
}
