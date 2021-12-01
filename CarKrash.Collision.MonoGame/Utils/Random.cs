namespace CarKrash.Collision
{
    public static class Random
    {
        static System.Random rand = new System.Random();
        public static int Next (int minValue, int maxValue)
        {
            return rand.Next(minValue, maxValue);
        }
        public static double NextDouble()
        {
            return rand.NextDouble();
        }
    }
}
