using Microsoft.Xna.Framework;
using System;

namespace Collision
{
    public struct Vector3
    {
        float x;
        float y;
        float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3(Vector2 v, float z)
        {
            this.x = v.X;
            this.y = v.Y;
            this.z = z;
        }

        public float Magnitude()
        {
            return MathF.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
        }
        public float Distance(Vector3 b)
        {
            return MathF.Sqrt(MathF.Pow(this.X + b.X, 2) + MathF.Pow(this.Y - b.Y, 2) + MathF.Pow(this.Z - b.Z, 2));
        }
        public Vector3 Normalize()
        {
            float mag = this.Magnitude();

            if (mag == 0) throw new DivideByZeroException($"Cannot divide Vector3 ({this}) by a value of 0");

            return this / mag;
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }

        public static implicit operator Microsoft.Xna.Framework.Vector3(Vector3 v)
        {
            return new Microsoft.Xna.Framework.Vector3(v.x, v.y, v.z);
        }
        public static implicit operator Vector3(Microsoft.Xna.Framework.Vector3 v)
        {
            return new Vector3(v.X, v.Y, v.Z);
        }

        public static implicit operator Vector2(Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }
        public static implicit operator Vector4(Vector3 v)
        {
            return new Vector4(v.x, v.y, v.z, 0);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a.x, -a.y, -a.z);
        }
        public static Vector3 operator *(Vector3 a, float b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }
        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        public static Vector3 operator /(Vector3 a, float b)
        {
            return new Vector3(a.x / b, a.y / b, a.z / b);
        }

        public static Vector3 Zero => new Vector3(0, 0, 0);
        public static Vector3 One => new Vector3(1, 1, 1);

        public static Vector3 Up => new Vector3(0, 1, 0);
        public static Vector3 Down => new Vector3(0, -1, 0);
        public static Vector3 Left => new Vector3(-1, 0, 0);
        public static Vector3 Right => new Vector3(1, 0, 0);
    }
}
