using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CarKrash.Collision.Graphics
{
    public class Animator
    {
        protected Dictionary<string, Animation> animations;

        bool isPaused;
        private Animation currentAnimation;
        private float timer;

        private Vector2 position;
        private Vector2 size;
        private float rotation;
        private Vector2 scale;

        public Animation CurrentAnimation => currentAnimation;
        public Dictionary<string, Animation> Animations => animations;

        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Size { get => size; set => size = value; }
        public float Rotation { get => rotation; set => rotation = value; }
        public Vector2 Scale { get => scale; set => scale = value; }

        public Animator(Dictionary<string, Animation> animations)
        {
            this.animations = animations;
            Play(animations.ElementAt(0).Key);

            Position = Vector2.Zero;
            Size = new Vector2(currentAnimation.FrameWidth, currentAnimation.FrameHeight);
            Rotation = 0f;
            Scale = Vector2.One;
        }
        public void Play (string animationKey)
        {
            var animation = animations[animationKey];

            if (currentAnimation == animation) { return; }
            currentAnimation = animation;
            currentAnimation.CurrentFrame = 0;
            timer = 0;
        }
        public void Pause()
        {
            isPaused = true;
            timer = 0f;
        }
        public void Resume()
        {
            isPaused = false;
            timer = 0f;
        }
        public void Stop()
        {
            timer = 0f;
            currentAnimation.CurrentFrame = 0;
        }

        public void Update (GameTime gameTime)
        {
            if (isPaused) { return; }

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > currentAnimation.FrameSpeed)
            {
                timer = 0f;
                currentAnimation.CurrentFrame++;
                if (currentAnimation.CurrentFrame >= currentAnimation.FrameCount)
                {
                    currentAnimation.CurrentFrame = 0;
                }
            }
        }
    }
}
