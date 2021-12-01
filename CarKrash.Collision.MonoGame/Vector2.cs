using Microsoft.Xna.Framework;
using System;

namespace CarKrash.Collision
{
    public struct Vector2
    {
        float x;
        float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Point ToPoint()
        {
            return new Point((int)x, (int)y);
        }
        public float Magnitude()
        {
            return MathF.Sqrt(this.X * this.X + this.Y * this.Y);
        }
        public float Distance(Vector2 b)
        {
            return MathF.Sqrt(MathF.Pow(this.X + b.X, 2) - MathF.Pow(this.Y - b.Y, 2));
        }
        public Vector2 Normalize()
        {
            float mag = this.Magnitude();

            if (mag == 0) throw new DivideByZeroException($"Cannot divide Vector2 ({this}) by a value of 0");

            return this / mag;
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        public static implicit operator Microsoft.Xna.Framework.Vector2(Vector2 v)
        {
            return new Microsoft.Xna.Framework.Vector2(v.x, v.y);
        }
        public static implicit operator Vector2(Microsoft.Xna.Framework.Vector2 v)
        {
            return new Vector2(v.X, v.Y);
        }

        public static implicit operator Vector3(Vector2 v)
        {
            return new Vector3(v.x, v.y, 0);
        }
        public static implicit operator Vector4(Vector2 v)
        {
            return new Vector4(v.x, v.y, 0, 0);
        }
        public static implicit operator Microsoft.Xna.Framework.Vector3(Vector2 v)
        {
            return new Microsoft.Xna.Framework.Vector3(v.x, v.y, 0);
        }

        public static Vector2 operator + (Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(-a.x, -a.y);
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }
        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.x / b, a.y / b);
        }

        public static Vector2 Zero => new Vector2(0, 0);
        public static Vector2 One => new Vector2(1, 1);

        public static Vector2 Up => new Vector2(0, 1);
        public static Vector2 Down => new Vector2(0, -1);
        public static Vector2 Left => new Vector2(-1, 0);
        public static Vector2 Right => new Vector2(1, 0);
    }
}
