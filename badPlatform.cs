using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class BadPlatform
    {
        public Vector2 position;
        public Vector2 size;

        public void Setup()
        {
            // Optional setup logic
        }

        public void Update()
        {
            Draw.FillColor = Color.Red;
            Draw.Rectangle(position.X, position.Y, size.X, size.Y);
        }


    }
}
