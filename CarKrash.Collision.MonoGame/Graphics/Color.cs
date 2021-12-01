namespace CarKrash.Collision.Graphics
{
    public struct Color
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public Color(float r, float g, float b, float a)
        {
            if (r > 255 || r < 0) throw new System.ArgumentOutOfRangeException("r", "Value of r is not between 0 and 255");
            if (g > 255 || g < 0) throw new System.ArgumentOutOfRangeException("g", "Value of g is not between 0 and 255");
            if (b > 255 || b < 0) throw new System.ArgumentOutOfRangeException("b", "Value of b is not between 0 and 255");
            if (a > 255 || a < 0) throw new System.ArgumentOutOfRangeException("a", "Value of a is not between 0 and 255");

            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
        public Color(float r, float g, float b)
        {
            if (r > 255 || r < 0) throw new System.ArgumentOutOfRangeException("r", "Value of r is not between 0 and 255");
            if (g > 255 || g < 0) throw new System.ArgumentOutOfRangeException("g", "Value of g is not between 0 and 255");
            if (b > 255 || b < 0) throw new System.ArgumentOutOfRangeException("b", "Value of b is not between 0 and 255");

            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 255;
        }
        public Color(Vector3 vector3)
        {
            if (vector3.X > 255 || vector3.X < 0) throw new System.ArgumentOutOfRangeException("r", "Value of r is not between 0 and 255");
            if (vector3.Y > 255 || vector3.Y < 0) throw new System.ArgumentOutOfRangeException("g", "Value of g is not between 0 and 255");
            if (vector3.Z > 255 || vector3.Z < 0) throw new System.ArgumentOutOfRangeException("b", "Value of b is not between 0 and 255");

            this.r = vector3.X;
            this.g = vector3.Y;
            this.b = vector3.Z;
            this.a = 255;
        }

        public static implicit operator Microsoft.Xna.Framework.Color(Color c)
        {
            return new Microsoft.Xna.Framework.Color(c.r, c.g, c.b, c.a);
        }

        public static Color White => new Color(255, 255, 255);
        public static Color Black => new Color(0, 0, 0);
        public static Color Red => new Color(255, 0, 0);
        public static Color Green => new Color(0, 255, 0);
        public static Color Blue => new Color(0, 0, 255);
        public static Color Purple => new Color(255, 0, 255);
        public static Color Yellow => new Color(255, 255, 0);
        public static Color LightBlue => new Color(0, 255, 255);
        public static Color CornflowerBlue => new Color(100, 149, 237);
    }
}
