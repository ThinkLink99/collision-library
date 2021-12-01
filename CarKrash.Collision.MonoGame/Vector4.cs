using System;
using System.Collections.Generic;
using System.Text;

namespace CarKrash.Collision
{
    public struct Vector4
    {
        float x;
        float y;
        float z;
        float w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public float Magnitude()
        {
            return MathF.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W);
        }
        public float Distance(Vector4 b)
        {
            return MathF.Sqrt(MathF.Pow(this.X + b.X, 2) + MathF.Pow(this.Y - b.Y, 2) + MathF.Pow(this.Z - b.Z, 2) + MathF.Pow(this.W - b.W, 2));
        }
        public Vector4 Normalize()
        {
            float mag = this.Magnitude();

            if (mag == 0) throw new DivideByZeroException($"Cannot divide Vector4 ({this}) by a value of 0");

            return this / mag;
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }
        public float W { get => w; set => w = value; }

        public static implicit operator Microsoft.Xna.Framework.Vector4(Vector4 v)
        {
            return new Microsoft.Xna.Framework.Vector4(v.x, v.y, v.z, v.w);
        }
        public static implicit operator Vector4(Microsoft.Xna.Framework.Vector4 v)
        {
            return new Vector4(v.X, v.Y, v.Z, v.W);
        }

        public static implicit operator Vector2(Vector4 v)
        {
            return new Vector2(v.x, v.y);
        }
        public static implicit operator Vector3(Vector4 v)
        {
            return new Vector3(v.x, v.y, v.z);
        }
        public static implicit operator Microsoft.Xna.Framework.Vector3(Vector4 v)
        {
            return new Microsoft.Xna.Framework.Vector3(v.x, v.y, v.z);
        }
        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }
        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }
        public static Vector4 operator -(Vector4 a)
        {
            return new Vector4(-a.x, -a.y, -a.z, -a.w);
        }
        public static Vector4 operator *(Vector4 a, float b)
        {
            return new Vector4(a.x * b, a.y * b, a.z * b, a.w * b);
        }
        public static Vector4 operator *(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }
        public static Vector4 operator /(Vector4 a, float b)
        {
            return new Vector4(a.x / b, a.y / b, a.z / b, a.w / b);
        }

        public static Vector4 Zero => new Vector4(0, 0, 0, 0);
        public static Vector4 One => new Vector4(1, 1, 1, 1);

        public static Vector4 Up => new Vector4(0, 1, 0, 0);
        public static Vector4 Down => new Vector4(0, -1, 0, 0);
        public static Vector4 Left => new Vector4(-1, 0, 0, 0);
        public static Vector4 Right => new Vector4(1, 0, 0, 0);
    }
}
