using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        void Win()
        {
            Draw.FillColor = Color.Green;
            Draw.Rectangle(0, 0, 800, 600);
        }

        void Lose()
        {
            Draw.FillColor = Color.Red;
            Draw.Rectangle(0, 0, 800, 600);
        }
    }
}