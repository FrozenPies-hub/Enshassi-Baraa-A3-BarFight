using Raylib_cs;
using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        HP opponenthp = new HP(new Vector2(690, 10), 20, false);
        HP playerhp = new HP(new Vector2(690, 570), 20, false);
        Player player = new Player();
        Ending ending = new Ending();


        Opponent opponent = new Opponent();

        Texture2D backgroundTexture = Graphics.LoadTexture("texture/Bar-Fight-Background.jpg");

        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("Win a Bar Fight!");
            ending.endingScreen = 0;
        }

        public void Update()
        {
            Window.ClearBackground(Color.White);


            if (Input.IsKeyboardKeyPressed(KeyboardInput.Enter))
            {
                ending.endingScreen = 4;
            }

            if (opponenthp.currentHP == 0)
            {
                ending.endingScreen = 1;
            }
            if (playerhp.currentHP == 0)
            {
                ending.endingScreen = 2;
            }

            if (ending.endingScreen < 4)
            {
                ending.Update();
                return;
            }

            Graphics.Draw(backgroundTexture, 30, 80);

            opponenthp.Update();
            opponent.Update();
            playerhp.Update();
            player.Update();

            if (opponent.isHit == true && opponent.isBlocking == false)
            {
                opponenthp.currentHP -= 1;
                opponent.isHit = false;
            }

            if (opponent.isAttacking == true && player.isBlocking == false)
            {
                if (opponent.damageDealt == false)
                {
                    playerhp.currentHP -= 1;
                    opponent.damageDealt = true;
                }
            }
        }
    }
}
