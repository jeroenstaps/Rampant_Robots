using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
    class Mechanic
    {
        public int xCor { get; set; }
        public int yCor { get; set; }
        public int moves { get; set; }

        // Constructor
        public Mechanic(int xCoordinate, int yCoordinate)
        {
            xCor = xCoordinate;
            yCor = yCoordinate;
        }

        // Move Mechanic
        public void Move(string moves)
        {
            for(int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'a':
                        yCor--;
                        break;
                    case 'w':
                        xCor--;
                        break;
                    case 'd':
                        yCor++;
                        break;
                    case 's':
                        xCor++;
                        break;
                    default:
                        Console.WriteLine("You should only use 'wasd' to control the Mechanic.");
                        break;
                }
            }
        }
    }
}
