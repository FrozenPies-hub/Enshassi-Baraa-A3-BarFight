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

        public void Update()
        {
            DrawEnemy();
        }

        void DrawEnemy()
        {
            attacked += Time.DeltaTime;

            mousePosition = Input.GetMousePosition();

            Draw.FillColor = Color.Red;

            bool collides = false;
            if (mousePosition.X < position.X + size.X && mousePosition.X > position.X && mousePosition.Y < position.Y + size.Y && mousePosition.Y > position.Y)
            {
                collides = true;
            }

            if (Input.IsMouseButtonPressed(MouseInput.Left) && collides == true)
            {
                attacked = 0;
            }

            if (attacked < hurt && attacked > 0)
            {
                Draw.Rectangle(position + new Vector2(25, 25), size - new Vector2(25, 25)); // attacking stance
            }
            else
            {
                Draw.Rectangle(position, size); // defualt stance
            }

        }
    }
}