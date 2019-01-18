using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
    class Robot
    {
        public int xCor { get; set; }
        public int yCor { get; set; }
        static Random rand = new Random();

        // Constructor
        public Robot(int xCoordinate, int yCoordinate)
        {
            xCor = xCoordinate;
            yCor = yCoordinate;
        }

        // Move Robot
        public void Move(string moves)
        {
            for(int i = 0; i < moves.Length; i++)
            {
                int rand2 = rand.Next(1, 5);
                switch (rand2)
                {
                    case 1:
                        xCor++;
                        break;
                    case 2:
                        yCor++;
                        break;
                    case 3:
                        xCor--;
                        break;
                    case 4:
                        yCor--;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
