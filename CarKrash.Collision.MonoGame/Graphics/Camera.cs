using Microsoft.Xna.Framework;
using System;

namespace Collision
{
    public class Camera
    {
        public readonly static float MinZ = 1;
        public readonly static float MaxZ = 2048;

        public readonly static int MinZoom = 1;
        public readonly static int MaxZoom = 20;

        protected Vector2 position;
        protected float baseZ;
        protected float z;

        protected int screenWidth = 0;
        protected int screenHeight = 0;

        protected float aspectRatio;
        protected float fieldOfView;

        private int zoom = 1;

        private Matrix view;
        private Matrix proj;

        public Camera (Screen screen)
        {
            if (screen is null) { throw new ArgumentNullException("screen"); }

            position = Vector2.Zero;

            aspectRatio = (float)screen.Width / screen.Height;
            fieldOfView = MathHelper.PiOver2;

            baseZ = GetZFromHeight(screen.Height);
            z = baseZ;

            screenWidth = screen.Width;
            screenHeight = screen.Height;

            UpdateMatrices();
        }

        public void UpdateMatrices ()
        {
            view = Matrix.CreateLookAt(new Vector3(position, z),
                                       new Vector3(position, 0),
                                           Vector3.Down);
            proj = Matrix.CreatePerspectiveFieldOfView(fieldOfView,
                                                       aspectRatio,
                                                       MinZ,
                                                       MaxZ);
        }
        public float GetZFromHeight (float height)
        {
            float z = (0.5f * height) / MathF.Tan(0.5f * fieldOfView);
            return z;
        }
        public float GetHeightFromZ (float z)
        {
            return z * MathF.Tan(0.5f * fieldOfView) * 2f;
        }
        public void MoveZ (float amt)
        {
            z += amt;
            z = MonoGameUtil.Clamp(z, MinZ, MaxZ);
        }

        public float Z => z;
        public Vector2 Position => position;
        public Matrix ViewMatrix => view;
        public Matrix ProjectionMatrix => proj;

        public void ResetZ ()
        {
            z = baseZ;
        }
        public void Move (Vector2 amount)
        {
            position += amount;
        }
        public void MoveTo (Vector2 position)
        {
            this.position = position;
        }

        public void IncrementZoom ()
        {
            zoom++;
            zoom = MonoGameUtil.Clamp(zoom, MinZoom, MaxZoom);

            z = baseZ / zoom;
        }
        public void DecrementZoom()
        {
            zoom--;
            zoom = MonoGameUtil.Clamp(zoom, MinZoom, MaxZoom);

            z = baseZ / zoom;
        }
        public void SetZoom (int amount)
        {
            zoom = amount;
            zoom = MonoGameUtil.Clamp(zoom, MinZoom, MaxZoom);

            z = baseZ / zoom;
        }

        public void GetExtents (out float width, out float height)
        {
            height = (float)GetHeightFromZ(Z);
            width = height * aspectRatio;
        }
        public void GetExtents (out float left, out float right, out float bottom, out float top)
        {
            GetExtents(out float width, out float height);
            left = position.X - width * 0.5f;
            right = left + width;
            bottom = position.Y - height * 0.5f;
            top = bottom + height;
        }
        public void GetExtents (out Vector2 min, out Vector2 max)
        {
            GetExtents(out float left, out float right, out float bottom, out float top);
            min = new Vector2((float)left, (float)top);
            max = new Vector2((float)right, (float)bottom);
        }
    }

    public class FollowingCamera : Camera
    {
        protected Matrix transformMatrix = Matrix.Identity;
        public Matrix Transform => transformMatrix;

        public FollowingCamera(Screen screen) : base(screen)
        {
        }
    }
    public class FreeCamera : Camera
    {
        public FreeCamera(Screen screen) : base(screen)
        {

        }
    }
}
