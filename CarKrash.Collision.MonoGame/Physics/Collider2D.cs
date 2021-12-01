using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarKrash.Collision.Physics2D
{
    public abstract class Collider2D
    {
        protected bool isTrigger;
        protected Transform transform;

        internal event Action<Collider2D> internal_onCollide;

        public event Action onCollide;

        protected Collider2D(bool isTrigger, Transform transform)
        {
            this.isTrigger = isTrigger;
            this.transform = transform;
        }
        public bool IsColliding (Collider2D other)
        {
            if (this == other) { return false; }
            if (this is BoxCollider2D && other is BoxCollider2D)
            {
                return ((BoxCollider2D)this).Rectangle.Intersects(((BoxCollider2D)other).Rectangle);
            }
            return false;
        }
        public bool IsColliding(Screen screen, ref Vector2 velocity)
        {
            bool isColliding = false;
            if (this is BoxCollider2D)
            {
                if (((BoxCollider2D)this).Rectangle.Right >= screen.Width)
                {
                    velocity.X *= -0.9f;
                    isColliding = true;
                }
                if (((BoxCollider2D)this).Rectangle.Left <= 0)
                {
                    velocity.X *= -0.9f;
                    isColliding = true;
                }
                if (((BoxCollider2D)this).Rectangle.Top <= 0)
                {
                    velocity.Y *= -0.9f;
                    isColliding = true;
                }
                if (((BoxCollider2D)this).Rectangle.Bottom >= screen.Height)
                {
                    velocity.Y *= -0.9f;
                    velocity.X *= 0.8f;
                    isColliding = true;
                }
            }
            else if (this is CircleCollider2D)
            {
                var c = ((CircleCollider2D)this);
                if (c.Transform.Position.X + c.Radius >= screen.Width)
                {
                    isColliding = true;
                    velocity.X *= -0.9f;
                }
                if (c.Transform.Position.X - c.Radius <= 0)
                {
                    isColliding = true;
                    velocity.X *= -0.9f;
                }
                if (c.Transform.Position.Y - c.Radius <= 0)
                {
                    isColliding = true;
                    velocity.Y *= -0.9f;
                }
                if (c.Transform.Position.Y + c.Radius >= screen.Height)
                {
                    isColliding = true;
                    velocity.X *= 0.8f;
                    velocity.Y *= -0.9f;
                }
            }
            return isColliding;
        }
        public Transform Transform
        {
            get => transform;
            set => transform = value;
        }
        public bool IsTrigger => isTrigger;

        internal void Update (GameTime gameTime, List<BoxCollider2D> colliders)
        {
            if (colliders == null) return;

            foreach (Collider2D collider in colliders)
            {
                if (this == collider) continue;

                if (IsColliding(collider))
                    if (isTrigger)
                    {
                        onCollide?.Invoke();
                        internal_onCollide?.Invoke(this);
                    }
                // else
                // TODO: make collision detection code, ya fuckin dummy
            }
        }
        public bool Update(GameTime gameTime, ref Vector2 v, Screen screen)
        {
            if (IsColliding(screen, ref v))
            {
                if (isTrigger)
                {
                    onCollide?.Invoke();
                }
                else { return true; }
            }
            else { return false; }
            return false;
        }
        public abstract float GetArea();
    }

    public class BoxCollider2D : Collider2D
    {
        public BoxCollider2D (bool isTrigger, Transform transform)
            : base(isTrigger, transform)
        {

        }

        public Rectangle Rectangle => new Rectangle((int)transform.Position.X,
                                                    (int)transform.Position.Y,
                                                    (int)transform.Size.X,
                                                    (int)transform.Size.Y);
        public override float GetArea()
        {
            return Transform.Size.X * Transform.Size.Y;
        }
    }
    public class CircleCollider2D : Collider2D
    {
        float radius = 0f;
        public CircleCollider2D(float radius, bool isTrigger, Transform transform)
            : base(isTrigger, transform)
        {
            this.radius = radius;
        }

        public override float GetArea()
        {
            return MathHelper.TwoPi * radius;
        }
        public float Radius => radius;
    }
}
