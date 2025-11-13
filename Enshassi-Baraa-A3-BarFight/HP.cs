using MohawkGame2D;
using System;
using System.Drawing;
using System.Numerics;

namespace MohawkGame2D
{
    public class HP
    {
        Vector2 position;
        Vector2 size = new Vector2(100, 20);
        Vector2 hitBoxPos = new Vector2(0, 0);
        Vector2 hitBoxSize = new Vector2(100, 100);
        Vector2 mousePosition = Input.GetMousePosition();

        public int currentHP = 20;
        int fakeHP;

        bool isHP0 = false;

        public HP(Vector2 position, int currentHP, bool isHP0)
        {
            this.position = position;
            this.currentHP = currentHP;
            this.isHP0 = isHP0;
        }

        public void Update()
        {
            fakeHP = currentHP * 5;

            CharacterHP();
        }

        public void CharacterHP()
        {
            Draw.FillColor = MohawkGame2D.Color.Gray;
            Draw.LineSize = 1;
            Draw.LineColor = MohawkGame2D.Color.Black;
            Draw.Rectangle(position, size);

            Draw.FillColor = MohawkGame2D.Color.Green;
            Draw.LineSize = 0;
            Draw.Rectangle(position.X, position.Y, fakeHP, size.Y);
        }
    }
}