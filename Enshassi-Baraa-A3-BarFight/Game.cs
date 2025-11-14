using Raylib_cs;
using System;
using System.Numerics;
using System.Text;

namespace MohawkGame2D
{
    public class Game
    {
        HP opponenthp = new HP(new Vector2(690, 10), 20, false);
        HP playerhp = new HP(new Vector2(690, 570), 20, false);
        Player player = new Player();
        Ending ending = new Ending();

        float attackWait = 0;
        float attack = 5;

        Opponent opponent = new Opponent();

        bool isLose;
        bool isWin;

        Texture2D backgroundTexture;

        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("Win a Bar Fight!");
            ending.endingScreen = 0;
        }

        public void Update()
        {
            Window.ClearBackground(Color.White);

            if (opponenthp.currentHP == 0)
            {
                ending.endingScreen = 1;
            }
            if (playerhp.currentHP == 0)
            {
                ending.endingScreen = 2;
            }

            if (ending.endingScreen > 0)
            {
                ending.Update();
                return;
            }

            backgroundTexture = Graphics.LoadTexture("texture/Bar-Fight-Background.jpg");

            opponenthp.Update();
            opponent.Update();
            playerhp.Update();
            player.Update();

            if (opponent.isHit == true && opponent.isBlocking == false)
            {
                opponent.isHit = false;
                opponenthp.currentHP -= 1;
            }

            if (opponent.isAttacking == true && player.isBlocking == false)
            {
                playerhp.currentHP -= 1;
                opponent.isAttacking = false;
            }
        }
    }
}