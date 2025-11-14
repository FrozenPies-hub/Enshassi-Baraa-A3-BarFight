using MohawkGame2D;
using System;
using System.Numerics;
using Raylib_cs;

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

        Texture2D enemyBlock = Graphics.LoadTexture("texture/enemy-block.jpg");
        Texture2D enemyDefault = Graphics.LoadTexture("texture/enemy-default.jpg");
        Texture2D enemyHurt = Graphics.LoadTexture("texture/enemy-hurt.jpg");
        Texture2D enemyAttack = Graphics.LoadTexture("texture/enemy-attack.jpg");

        int blockChance;

        public bool isBlocking = false;
        public bool isHit = false;
        public bool isAttacking = false;

        public bool damageDealt = false;
        public bool damageTaken = false;

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
                attacked = 0;
            }

            if (blockChance == 5 && attacked < hurt && attacked > 0)
            {
                isBlocking = true;
                Graphics.Draw(enemyBlock, position); // blocking stance
            }
            else if (attack >= attackWait)
            {
                isBlocking = false;
                isAttacking = true;
                Graphics.Draw(enemyAttack, position); // attacking stance
                attackLengthTime += Time.DeltaTime;
                if (attackLengthTime >= attackLength)
                {
                    damageDealt = false;
                    isAttacking = false;
                    attackLengthTime = 0;
                    attack = 0;

                }
            }
            else if (blockChance < 5 && attacked < hurt && attacked > 0)
            {
                isBlocking = false;
                if (damageTaken == false)
                {
                    isHit = true;
                    damageTaken = true;
                }

                Graphics.Draw(enemyHurt, position); // took damage stance
            }
            else
            {
                isBlocking = false;
                damageTaken = false;
                Graphics.Draw(enemyDefault, position); // defualt stance
            }

        }
    }
}