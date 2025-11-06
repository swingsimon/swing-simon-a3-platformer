// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

        Vector2[] platformPos = new Vector2[]
        {
        new Vector2(50, 450),   // Ground platform
        new Vector2(150, 350),  // First jump
        new Vector2(250, 250),  // Second jump
        new Vector2(350, 150),  // Third jump
        new Vector2(400, 80)    // Final platform
        };

        Vector2[] platformSize = new Vector2[]
        {
        new Vector2(400, 20),   // Wide ground
        new Vector2(100, 20),   // Medium
        new Vector2(100, 20),   // Medium
        new Vector2(80, 20),    // Small
        new Vector2(60, 20)     // Small
        };

        platform[] platforms = new platform[5];
        player Skeleman;
        badPlatform deadBlock;
        goal endSquare;



        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Skeleman Escapes");
            Window.SetSize(500, 500);
            Window.TargetFPS = 60;

            //Initialize all the game objects here
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i] = new platform();
                platforms[i].position = platformPos[i];
                platforms[i].size = platformSize[i];
                platforms[i].Setup();

            }

            Skeleman = new player();
            Skeleman.Setup();


            deadBlock = new badPlatform();
            deadBlock.position = new Vector2();
            deadBlock.Setup();


            endSquare = new goal();
            endSquare.position = new Vector2();
            endSquare.Setup();

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Black);

            DrawBackground();

            if (goal.reached)
            {
                Text.Draw("You made it!", new Vector2(250, 250));
            }

            else
            {

                for (int i = 0; i < platforms.Length; i++)

                {
                    platforms[i].Update();
                }

                player.Update(platform);
                endSquare.Update(player);
                goal.Update(player);
            }
        }

    }
}
