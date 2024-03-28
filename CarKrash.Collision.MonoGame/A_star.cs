//using Microsoft.Xna.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Collision
//{
//    public sealed class A_star
//    {
//        struct Node
//        {
//            // G Cost: the distance away from the starting node
//            // H Cost: the distance away from the ending node
//            // F Cost: G + H

//            float gCost;
//            float hCost;
//            Vector2 pos;

//            public float FCost { get => gCost + hCost; }
//            public Vector2 Position { get => pos; }

//            // calculate the normalized distance from the end pos to the current pos
//            void CalculateHCost (Vector2 endPos, List<Vector2> obstacles)
//            {
//            }

//            public Node(Vector2 pos)
//            {
//                this.gCost = 0;
//                this.hCost = 0;
//                this.pos = pos;
//            }
//        }

//        Vector2 worldSize = Vector2.Zero;
//        List<Vector2> obstacles;

//        Grid<Node> openNodes;
//        Grid<Node> closedNodes;

//        public A_star (float worldWidth, float worldHeight, List<Vector2> obstacles)
//        {
//            this.obstacles = obstacles;
//            this.worldSize = new Vector2(worldWidth, worldHeight);

//            Reset();
//        }
//        public A_star(Vector2 worldSize, List<Vector2> obstacles)
//        {
//            this.obstacles = obstacles;
//            this.worldSize = worldSize;

//            Reset();
//        }

//        private void Reset ()
//        {
//            openNodes = new List<Node>();
//            closedNodes = new List<Node>();

//            for (float y = 0; y < worldSize.Y; y++)
//            {
//                for (float x = 0; x < worldSize.X; x++)
//                {
//                    var v = new Vector2(x, y);
//                    if (!obstacles.Contains(v))
//                        openNodes.Add(new Node(v));
//                }
//            }
//        }

//        private void FindPath (Vector2 startingPos, Vector2 endingPos)
//        {
//            //var node = openNodes.Where(n => n.Position == startingPos).FirstOrDefault();
//        }
//    }
//}
