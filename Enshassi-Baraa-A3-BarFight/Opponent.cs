using MohawkGame2D;
using System;
using System.Numerics;

public class Opponent
{
    Vector2 position = new Vector2(300, 50);
    Vector2 size = new Vector2(75, 75);

    public void Update()
    {
        Hitbox();
    }

    void Hitbox()
    {
        Draw.LineColor = Color.Red;
        Draw.LineSize = 2;
        Draw.FillColor = Color.Clear;
        Draw.Rectangle(position, size);
    }
}
