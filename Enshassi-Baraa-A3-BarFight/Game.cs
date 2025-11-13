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

        float attackWait = 0;
        float attack = 5;

        Opponent opponent = new Opponent();

        Texture2D backgroundTexture;

        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("Win a Bar Fight!");

        }

        public void Update()
        {
            Window.ClearBackground(Color.White);

            backgroundTexture = Graphics.LoadTexture("texture/Bar-Fight-Background.jpg");

            opponenthp.Update();
            opponent.Update();
            playerhp.Update();
            player.Update();

            Attack();
        }

        void Attack()
        {
            attackWait += Time.DeltaTime;

            if (attackWait >= attack)
            {
                attackWait = 0;
                System.Random random = new System.Random();
                int attackChance = random.Next(1, 3);

                if (attackChance == 1)
                {
                    playerhp.currentHP -= 1;
                }
            }
        }
    }
}