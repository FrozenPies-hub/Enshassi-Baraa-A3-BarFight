using MohawkGame2D;
using System;
using System.Drawing;
using System.Numerics;

public class HP
{
	Vector2 position = new Vector2(200, 300);
	Vector2 size = new Vector2(100, 20);
	Vector2 hitBoxPos = new Vector2(0, 0);
	Vector2 hitBoxSize = new Vector2(100, 100);

	int currentHP = 20;
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

        OpponentHP();
		input();
		
	}

	public void OpponentHP () 
	{
		Draw.FillColor = MohawkGame2D.Color.Gray;
		Draw.LineSize = 1;
		Draw.LineColor = MohawkGame2D.Color.Black;
		Draw.Rectangle(position, size);

        Draw.FillColor = MohawkGame2D.Color.Red;
        Draw.LineSize = 0;
        Draw.Rectangle(position.X, position.Y, fakeHP, size.Y);
    }

	void input()
	{
		
		if (mousePosition && isHP0 == false)
		{
			currentHP -= 1;

			if (currentHP <= 0)
			{
				isHP0 = true;
			}
		}
	}

	void SuccessfulHit()
	{
		Vector2 mousePosition = Input.GetMousePosition();

		float opponentTop = position.Y < hitBoxPos.Y + hitBoxSize.Y;
		float opponentBottom = position.Y + size.Y > hitBoxPos.Y;
		float opponentLeft = position.X < hitBoxPos.X + hitBoxSize.X;
		float opponentRight = position.X + size.X > hitBoxPos.X;

		if (opponentTop && opponentBottom && opponentLeft && opponentRight)
		{

		}
	}
}
