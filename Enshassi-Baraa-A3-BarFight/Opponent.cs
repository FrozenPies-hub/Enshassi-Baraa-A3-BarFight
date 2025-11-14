using MohawkGame2D;
using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Opponent
    {
        Vector2 position = new Vector2(300, 50);
        Vector2 size = new Vector2(75, 75);

        Vector2 mousePosition;

        float attacked = 1;
        float hurt = 1;

        float attack = 0;
        float attackWait = 3;
        float attackLength = 1;
        float attackLengthTime = 0;


        int blockChance;

        public bool isBlocking;
        public bool isHit;
        public bool isAttacking;

        public void Update()
        {
            DrawEnemy();
        }

        void DrawEnemy()
        {
            attacked += Time.DeltaTime;
            attack += Time.DeltaTime;

            mousePosition = Input.GetMousePosition();

            Draw.FillColor = Color.Red;

            bool collides = false;
            if (mousePosition.X < position.X + size.X && mousePosition.X > position.X && mousePosition.Y < position.Y + size.Y && mousePosition.Y > position.Y)
            {
                collides = true;
            }



            if (Input.IsMouseButtonPressed(MouseInput.Left) && collides && attacked >= 1)
            {
                System.Random random = new System.Random();
                blockChance = random.Next(1, 6);
                Console.WriteLine(blockChance);
                attacked = 0;
            }

            if (blockChance == 5 && attacked < hurt && attacked > 0)
            {
                isBlocking = true;
                Draw.Rectangle(position - new Vector2(25, 25), size - new Vector2(25, 25)); // blocking stance
            }
            else if (blockChance < 5 && attacked < hurt && attacked > 0)
            {
                isHit = true;
                Draw.Rectangle(position + new Vector2(25, 25), size - new Vector2(25, 25)); // took damage stance
            }
            else if (attack >= attackWait)
            {
                isAttacking = true;
                Draw.Rectangle(position + new Vector2(50, 50), size); // attacking stance
                attackLengthTime = Time.DeltaTime;
                if (attackLengthTime >= attackLength)
                {
                    attackLengthTime = 0;
                    attack = 0;

                }
            }
            else
            {
                Draw.Rectangle(position, size); // defualt stance
            }

        }
    }
}