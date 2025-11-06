using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Platform
    {
        public Vector2 position;
        public Vector2 size;

        public float leftEdge => position.X;
        public float rightEdge => position.X + size.X;
        public float topEdge => position.Y;
        public float bottomEdge => position.Y + size.Y;

        public void Setup() { }

        public void Update()
        {
            Draw.FillColor = Color.Gray;
            Draw.Rectangle(position.X, position.Y, size.X, size.Y);
        }
    }

}
