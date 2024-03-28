using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collision.Physics2D
{
    public abstract class Collider2D
    {
        public enum ColliderType
        {
            Circle,
            Polygon
        }

        private ColliderType colliderType;
        protected bool isTrigger;
        protected Transform transform;

        protected Collider2D(bool isTrigger, Transform transform)
        {
            this.isTrigger = isTrigger;
            this.transform = transform;
        }
        protected Collider2D(ColliderType colliderType, bool isTrigger, Transform transform)
        {
            this.colliderType = colliderType;
            this.isTrigger = isTrigger;
            this.transform = transform;
        }
    }

    public class BoxCollider2D : Collider2D
    {
        public BoxCollider2D (bool isTrigger, Transform transform)
            : base(ColliderType.Polygon, isTrigger, transform)
        {

        }

        public Rectangle Rectangle => new Rectangle((int)transform.Position.X,
                                                    (int)transform.Position.Y,
                                                    (int)transform.Size.X,
                                                    (int)transform.Size.Y);
    }
    public class CircleCollider2D : Collider2D
    {
        float radius = 0f;
        public CircleCollider2D(float radius, bool isTrigger, Transform transform)
            : base(ColliderType.Circle, isTrigger, transform)
        {
            this.radius = radius;
        }
        public float Radius => radius;
    }
}
