using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class player
    {
        // Variables for collision detection
        public float leftEdge = 0.0f;
        public float rightEdge = 0.0f;
        public float topEdge = 0.0f;
        public float bottomEdge = 0.0f;


        // These are the private variables
        Texture2D walkLeft;
        Texture2D walkRight;

        Vector2 position;
        Vector2 veolcity;
        Vector2 gravity = new Vector2(0, 1500);
        Vector2 size = new Vector2(30, 30);

        float speed = 200.0f;

        //Potential walk cycle with a few pngs
        Vector2 lastposition = new Vector2();

        public void Setup()
        { 
            velocity = new Vector2(0, 0);
            position = new Vector2(0, 0);
            walkLeft = Graphics.LoadTexture("Textures/Skele-Left-Walk.png");
            walkRight = Graphics.LoadTexture("Textures/SKele-Right-Walk.png");
        }
    }
}
