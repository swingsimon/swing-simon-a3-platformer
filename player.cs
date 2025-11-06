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
        Vector2 velocity;
        Vector2 gravity = new Vector2(0, 1500);
        Vector2 size = new Vector2(30, 30);

        float speed = 200.0f;


        public void Setup()
        {
            velocity = new Vector2(0, 0);
            position = new Vector2(450, 0);
            walkLeft = Graphics.LoadTexture("Textures/Skele-Left-Walk.png");
            walkRight = Graphics.LoadTexture("Textures/SKele-Right-Walk.png");
            size = new Vector2(walkLeft.Width, walkLeft.Height);
        }

        public void Update(platform[] platforms)
        {
            leftEdge = position.X;
            rightEdge = position.X + size.X;
            topEdge = position.Y;
            bottomEdge = position.Y + size.Y;

            ProcessInputs();
            ProcessPhysics();
            ProcessCollisions(platforms);
            DrawPlayer();

        }

        void ProcessInputs()
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                velocity.Y -= 500.0f;
            }

            bool walking = false;
            if (Input.IsKeyboardKeyDown(KeyboardInput.Right))
            {
                walking = true;
                velocity.X = speed;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.Left))
            {
                walking = true;
                velocity.X = -speed;
            }
            if (!walking)
            {
                velocity.X = 0;
            }

        }
        void ProcessPhysics(platform[] platforms)
        {
            velocity += gravity + Time.DeltaTime;
            position += velocity + Time.DeltaTime;
        }
        void ProcessCollisions(platform[] platforms)
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space)) return;

            platform platform = platforms[i];

            bool collided = false;
            if (rightEdge > platform.leftEdge && leftEdge < platform.rightEdge && bottomEdge > platform.topEdge && topEdge < platform.bottomEdge)
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
        void DrawPlayer()
        {
            Graphics.Rotation = 0.0f;
            Graphics.Scale = 1.0f;

        }
    }
}