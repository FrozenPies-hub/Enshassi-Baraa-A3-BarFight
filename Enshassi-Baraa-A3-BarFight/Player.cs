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

        float blockDuration = 1;
        float blocking = 1;

        public bool isBlocking;
        public bool isAttacking;

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
                Draw.Rectangle(position + new Vector2(25, -25), size - new Vector2(25, 25)); // block stance
            }
            else if (attacking < attackDuration && attacking > 0)
            {
                Draw.Rectangle(position - new Vector2(25, 25), size - new Vector2(25, 25)); // attacking stance
            }
            else
            {
                Draw.Rectangle(position, size); // defualt stance
            }
        }
    }
}