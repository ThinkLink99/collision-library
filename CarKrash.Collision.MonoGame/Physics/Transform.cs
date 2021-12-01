using Microsoft.Xna.Framework;

namespace CarKrash.Collision
{
    public class Transform : Component
    {
        protected Vector3 size;
        protected Vector3 position;
        protected float rotation;
        protected Vector3 scale;

        public Transform(Vector3 position, Vector3 size, float rotation, Vector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.size = size;
        }
        public Transform(Vector3 position, Vector3 size)
        {
            this.position = position;
            this.rotation = 0f;
            this.scale = Vector3.One;
            this.size = size;
        }

        public Vector3 Position
        {
            get => position;
            set => position = value;
        }
        public Vector3 Size
        {
            get => size;
            set => size = value;
        }
        public float Rotation
        {
            get => rotation;
            set => rotation = value;
        }
        public Vector3 Scale
        {
            get => scale;
            set => scale = value;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, 
                                     (int)position.Y, 
                                     (int)(size.X * scale.X), 
                                     (int)(size.Y * scale.X));
            }
        }

        public static Transform Empty
        {
            get
            {
                return new Transform(Vector3.Zero, Vector3.One, 0f, Vector3.Zero);
            } 
        }
    }
}