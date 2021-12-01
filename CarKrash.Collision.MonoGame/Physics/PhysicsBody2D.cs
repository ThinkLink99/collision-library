using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarKrash.Collision.Physics2D
{
    public static class Physics
    {
        public static Microsoft.Xna.Framework.Vector2 gravity = new Vector2(0, 0.1f);
    }

    public class PhysicsBody2D : Component
    {
        bool useGravity = true;

        private float friction = 0.9f;

        private Collider2D collider;
        private Microsoft.Xna.Framework.Vector2 velocity = Microsoft.Xna.Framework.Vector2.Zero;
        private Microsoft.Xna.Framework.Vector2 acceleration = Microsoft.Xna.Framework.Vector2.Zero;
        private Microsoft.Xna.Framework.Vector2 lastPosition = Microsoft.Xna.Framework.Vector2.Zero;
        private Microsoft.Xna.Framework.Vector2 position = Microsoft.Xna.Framework.Vector2.Zero;

        public PhysicsBody2D(Microsoft.Xna.Framework.Vector2 position, Collider2D collider)
        {
            this.position = position;
            this.collider = collider;
        }

        public Microsoft.Xna.Framework.Vector2 Position
        {
            get => position;
            set
            {
                if (collider != null)
                    collider.Transform.Position = value.ToVector3();
                position = value;
            }
        }

        public virtual float Mass => collider != null ? collider.GetArea() : 1f;
        public float Friction
        {
            get => friction;
            set
            {
                friction = value;
                if (friction > 1f)
                    friction = 1f;
                if (friction < 0f)
                    friction = 0f;
            }
        }

        public void AddForce(Vector2 force)
        {
            acceleration += force / Mass;
        }
        public Vector2 Update (GameTime gameTime, Screen screen)
        {
            if (useGravity) AddForce(Physics.gravity * Mass);

            Console.WriteLine("V: " + velocity + " A:" + acceleration);
            velocity += acceleration;

            if (collider.Update(gameTime, ref velocity, screen))
                position = lastPosition;

            lastPosition = position;
            Position += velocity;

            acceleration = Vector2.Zero;

            return Position;
        }
    }
}
