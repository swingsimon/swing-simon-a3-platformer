using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class platform
    {
        public Vector2 position;
        public Vector2 size;

        public void Setup()
        {
            // Optional setup logic
        }

        public void Update()
        {
            Draw.FillColor = Color.Gray;
            Draw.Rectangle(position.X, position.Y, size.X, size.Y);
        }

        bool collided = false;
            if (rightEdge > platform.leftEdge && leftEdge<platform.rightEdge && bottomEdge> platform.topEdge && topEdge<platform.bottomEdge)
        {
            collided = true;

            var leftDistance = Math.Abs(leftEdge - platform.rightEdge);
            var rightDistance = Math.Abs(rightEdge - platform.leftEdge);
            var topDistance = Math.Abs(topEdge - platform.bottomEdge);
            var bottomDistance = Math.Abs(bottomEdge - platform.topEdge);

            if (topDistance < bottomDistance && topDistance < leftDistance && topDistance < rightDistance)
            {
                position.Y = platform.position.Y + platform.size.Y;
            }

            if (bottomDistance < topDistance && bottomDistance < leftDistance && bottomDistance < rightDistance)
            {
                position.Y = platform.position.Y - platform.size.Y;
                velocity.Y = 0;
            }
            if (leftDistance < rightDistance && leftDistance < topDistance && leftDistance < bottomDistance)
            {
                position.X = platform.position.X + platform.size.X;
            }
            if (rightDistance < topDistance && rightDistance < bottomDistance && rightDistance < leftDistance)
            {
                position.X += platform.size.X;
            }
        }
    }
}
