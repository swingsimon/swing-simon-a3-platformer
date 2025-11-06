using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Goal
    {
        Texture2D endSquare;
        public Vector2 position;
        public Vector2 size;

        public float leftEdge = 0.0f;
        public float rightEdge = 0.0f;
        public float topEdge = 0.0f;
        public float bottomEdge = 0.0f;

        public bool reached = false;
        public void Setup()
        {
            endSquare = Graphics.LoadTexture("Textures/endSquare.png");
            size = new Vector2(endSquare.Width, endSquare.Height);
        }

        public void Update(Player player)
        {
            leftEdge = position.X;
            rightEdge = position.X + size.X;
            topEdge = position.Y;
            bottomEdge = position.Y + size.Y;

        
            if (rightEdge > player.leftEdge && leftEdge < player.rightEdge && topEdge < player.bottomEdge && bottomEdge > player.topEdge)
            {
                reached = true;
            }

            Graphics.Scale = 1.0f;
            Graphics.Rotation = 0.0f;
            Graphics.Draw(endSquare, position);

        }
    }
}
