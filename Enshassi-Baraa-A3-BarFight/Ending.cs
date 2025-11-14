using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MohawkGame2D
{
    public class Ending
    {
        public int endingScreen;

        public void Update()
        {
            if (endingScreen == 1)
            {
                Win();
            }
            if (endingScreen == 2)
            {
                Lose();
            }
            if (endingScreen == 0)
            {
                Title();
            }
        }

        void Win()
        {
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(800, 600));
            Text.Size = 40;
            Text.Color = Color.Yellow;
            Text.Draw("You Won!", new Vector2(300, 50));
        }

        void Lose()
        {
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(800, 600));
            Text.Size = 40;
            Text.Color = Color.Red;
            Text.Draw("You Lost!", new Vector2(300, 50));
        }

        void Title()
        {
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(800, 600));
            Text.Size = 40;
            Text.Color = Color.White;
            Text.Draw("Bar Fight", new Vector2(300, 50));
            Text.Size = 30;
            Text.Draw("Controls:", new Vector2(150, 130));
            Text.Size = 20;
            Text.Draw("Attack: Left Click", new Vector2(150, 170));
            Text.Draw("Block: Right Click", new Vector2(150, 190));
            Text.Draw("Start: Enter", new Vector2(150, 210));
        }
    }
}