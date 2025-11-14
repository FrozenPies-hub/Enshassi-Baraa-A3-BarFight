using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Player
    {
        Vector2 position = new Vector2(300, 500);
        Vector2 size = new Vector2(75, 75);

        float attackDuration = 1;
        float attacking = 1;

        float blockDuration = 2;
        float blocking = 1;

        public bool isBlocking = false;
        public bool isAttacking = false;

        Texture2D playerDefault = Graphics.LoadTexture("texture/player-default.jpg");
        Texture2D playerAttack = Graphics.LoadTexture("texture/player-attack.jpg");
        Texture2D playerBlock = Graphics.LoadTexture("texture/player-block.jpg");


        public void Update()
        {
            DrawPlayer();
        }

        void DrawPlayer()
        {
            attacking += Time.DeltaTime;
            blocking += Time.DeltaTime;
            Draw.FillColor = Color.Blue;



            if (Input.IsMouseButtonPressed(MouseInput.Left) && attacking >= 1)
            {
                attacking = 0;
            }
            if (Input.IsMouseButtonPressed(MouseInput.Right) && blocking >= 1)
            {
                blocking = 0;
            }
            if (blocking < blockDuration && blocking > 0)
            {
                isBlocking = true;
                Graphics.Draw(playerBlock, position); // block stance
            }
            else if (attacking < attackDuration && attacking > 0)
            {
                isBlocking = false;
                Graphics.Draw(playerAttack, position); // attacking stance
            }
            else
            {
                isBlocking = false;
                Graphics.Draw(playerDefault, position); // defualt stance
            }
        }
    }
}
