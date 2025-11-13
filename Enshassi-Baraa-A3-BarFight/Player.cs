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

        public void Update()
        {
            DrawPlayer();
        }

        void DrawPlayer()
        {
            attacking += Time.DeltaTime;
            Draw.FillColor = Color.Blue;
            if (Input.IsMouseButtonPressed(MouseInput.Left))
            {
                attacking = 0;
            }
            if (attacking < attackDuration && attacking > 0)
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