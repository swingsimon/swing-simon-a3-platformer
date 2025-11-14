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
        new Vector2(0, 450),    // Ground platform
        new Vector2(150, 350),   // First jump
        new Vector2(350, 250),   // Second jump
        new Vector2(450, 150),   // Third jump
        new Vector2(350, 80),    // Fourth jump
        new Vector2(150, 80)     // Fifth Jump
        };

        Vector2[] platformSize = new Vector2[]
        {
        new Vector2(500, 20),    // Wide ground
        new Vector2(200, 20),    // Medium
        new Vector2(100, 20),    // Medium
        new Vector2(80, 20),     // Small
        new Vector2(60, 20),     // Small
        new Vector2(120, 20)     // Medium
        };

        Platform[] platforms = new Platform[6];

        Player Skeleman;
        BadPlatform deadBlock;
        Goal endSquare;


        bool gameStarted = false;



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
                platforms[i] = new Platform();
                platforms[i].position = platformPos[i];
                platforms[i].size = platformSize[i];
                platforms[i].Setup();

            }

            Skeleman = new Player();
            Skeleman.Setup();


            deadBlock = new BadPlatform();
            deadBlock.position = new Vector2();
            deadBlock.Setup();


            endSquare = new Goal();
            endSquare.position = new Vector2();
            endSquare.Setup();

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        /// 



        public void Update()
        {
            Window.ClearBackground(Color.Black);

            if (!gameStarted)
            {
                DrawTitleScreen();
            }
            else
            {

                if (endSquare.reached)
                {
                    Text.Size = 32;
                    Text.Color = Color.White;
                    Text.Draw("Congratulations!!", new Vector2(150, 200));
                    Text.Size = 32;
                    Text.Color = Color.White;
                    Text.Draw("You made it!", new Vector2(155, 250));
                }

                else
                {

                    for (int i = 0; i < platforms.Length; i++)

                    {
                        platforms[i].Update();
                    }

                    Skeleman.Update(platforms);
                    endSquare.Update(Skeleman);
                }
            }

        }
        void DrawTitleScreen()
        {
            Text.Size = 32;
            Text.Color = Color.White;
            Text.Draw("Skeleman Escapes", new Vector2(120, 100));

            Text.Size = 20;
            Text.Color = Color.White;
            Text.Draw("Press ENTER to Start", new Vector2(150, 180));
            Text.Draw("Use LEFT and RIGHT arrows to move", new Vector2(80, 240));
            Text.Draw("Press SPACE to jump", new Vector2(150, 270));
            Text.Draw("Reach the BIG E to win!", new Vector2(125, 300));

            if (Input.IsKeyboardKeyPressed(KeyboardInput.Enter))
            {
                gameStarted = true;
            }
        }
    }
}
