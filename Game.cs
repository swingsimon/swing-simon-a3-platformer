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

        // Vector 2 = Reapeat as needed for platform positions
        Vector2[] platformPos = [new Vector2(),  ]

        // vector2 = repeast for platform placements
        Vector2[] platformSize = [new Vector2(), ]

        // platform array for number of platforms (tbd)
        platform[] platforms = new platform[]

        player Skeleman;
        badPlatform deadBlock;
        goal endSqaure;



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
            endGoal.position = new Vector2();
            endGoal.Setup();

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {

        }
    }

}
