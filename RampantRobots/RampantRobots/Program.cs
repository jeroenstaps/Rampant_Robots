using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Factory and run the game
            Factory factory = new Factory(5, 10, 7, 20, true);
            factory.Run();
            Console.WriteLine("Press enter to close the game.");
            Console.ReadLine();
        }
    }
}
