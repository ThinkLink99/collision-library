using System;

namespace CarKrash.Collision
{
    public static partial class MonoGameUtil
    {
        public static float Clamp(float d, float min, float max)
        {
            if (min > max) throw new ArgumentOutOfRangeException("The value of \"min\" is greater than the value of \"max\"");

            if (d < min) d = min;
            if (d > max) d = max;

            return d;
        }
        public static double Clamp (double d, double min, double max)
        {
            if (min > max) throw new ArgumentOutOfRangeException("The value of \"min\" is greater than the value of \"max\"");

            if (d < min) d = min;
            if (d > max) d = max;

            return d;
        }
        public static int Clamp(int d, int min, int max)
        {
            if (min > max) throw new ArgumentOutOfRangeException("The value of \"min\" is greater than the value of \"max\"");

            if (d < min) d = min;
            if (d > max) d = max;

            return d;
        }

        public static int Get1DArrayIndex (int x, int y, int width)
        {
            return x + y * width;
        }
    }
}
