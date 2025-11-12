// Include the namespaces (code libraries) you need below.
using Raylib_cs;
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
        HP opponenthp = new HP(new Vector2(400,300), 20, false);
        HP playerhp = new HP(new Vector2(400, 100), 20, false);
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("Win a Bar Fight!");

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Graphics.LoadTexture(Bar_Fight_Background.webp));
            opponenthp.Update();
            playerhp.Update();
        }
    }

}
