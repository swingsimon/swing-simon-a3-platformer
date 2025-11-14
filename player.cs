using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Player
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
        bool isGrounded = false;



        public void Setup()
        {
            velocity = new Vector2(0, 0);
            position = new Vector2(0, 450);
            walkLeft = Graphics.LoadTexture("Textures/Skele-Left-Walk.png");
            walkRight = Graphics.LoadTexture("Textures/SKele-Right-Walk.png");
            size = new Vector2(walkLeft.Width, walkLeft.Height);
        }

        public void Update(Platform[] platforms)
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
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space) && isGrounded)
            {
                velocity.Y = -500.0f;
                isGrounded = false;
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
        void ProcessPhysics()
        {
            velocity += gravity * Time.DeltaTime;
            position += velocity * Time.DeltaTime;
        }
        void ProcessCollisions(Platform[] platforms)
        {
            isGrounded = false;
            for (int i = 0; i < platforms.Length; i++)
            {
                Platform platform = platforms[i];
                if (platform == null) continue;

                // Check for overlap
                bool horizontalOverlap = rightEdge > platform.leftEdge && leftEdge < platform.rightEdge;
                bool verticalOverlap = bottomEdge > platform.topEdge && topEdge < platform.bottomEdge;

                // Only resolve if overlapping and falling downward
                if (horizontalOverlap && verticalOverlap && velocity.Y > 0)
                {
                    // Land on top of the platform
                    position.Y = platform.topEdge - size.Y;
                    velocity.Y = 0;
                    isGrounded = true;

                    // Update edge values after position change
                    leftEdge = position.X;
                    rightEdge = position.X + size.X;
                    topEdge = position.Y;
                    bottomEdge = position.Y + size.Y;
                }
            }
        }

        void DrawPlayer()
        {
            Graphics.Rotation = 0.0f;
            Graphics.Scale = 1.0f;
            Graphics.Draw(walkRight, position);

        }
    }
}