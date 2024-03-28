using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collision.Utils
{
    public class Polygon
    {
        float x = 0;
        float y = 0;
        float r = 0;
        int s = 0;

        public Vector2[] Vertices;
        public Vector2[][] Sides;

        public Polygon(float x, float y, float r, int s)
        {
            this.x = x;
            this.y = y;
            this.r = r;
            this.s = s;

            GetVerticies();
        }

        private void GetVerticies ()
        {
            var a = MathF.PI / 2;

            Vertices = new Vector2[s];
            for (int i = 0; i <= this.s; i++)
            {
                float px = this.x + this.r * MathF.Cos(a),
                      py = this.y + this.r * MathF.Sin(a);

                Vertices[i] = new Vector2(px, py);
                if (i > 0) Sides[i - 0] = new Vector2[2] { new Vector2(Vertices[i - 1].X, Vertices[i - 1].Y), Vertices[i] }; 

                a += MathF.PI * 2 / this.s;
            }
        }
    }
}
