using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
    class Factory
    {
        public int width { get; set; }
        public int height { get; set; }
        public int robots { get; set; }
        public int turns { get; set; }
        public bool robotsMove { get; set; }
        public Random Rand = new Random();

        Mechanic Hans = new Mechanic(1, 1);
        List<Robot> AllRobots = new List<Robot>();
        Random rand = new Random();

        // Constructor
        public Factory(int width, int height, int robots, int turns, bool robotsMove)
        {
            this.width = width;
            this.height = height;
            this.robots = robots;
            this.turns = turns;
            this.robotsMove = robotsMove;

            CreateRobots();
        }

        // Create list of robots 
        public void CreateRobots()
        {
            for(int i = 0; i < robots; i++)
            {
                int x = rand.Next(1, width+1);
                int y = rand.Next(1, height+1);
                while (SpotIsTaken(x, y))
                {
                    x = rand.Next(1, width+1);
                    y = rand.Next(1, height+1);
                }
                Robot robot = new Robot(x, y);
                AllRobots.Add(robot);
            }
        }

        // Check if a spot is taken in the factory
        public bool SpotIsTaken(int x,int y)
        {
            foreach(var robot in AllRobots)
            {
                if (robot.xCor == x & robot.yCor == y)
                    return true;
            }
            if (Hans.xCor == x & Hans.yCor == y)
                return true;
            return false;
        }

        // Visualize the game
        public void ShowGame()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Turns:" + turns.ToString());
            sb.Append(Environment.NewLine);

            for(int i = 1; i <= width; i++)
            {
                for(int j = 1; j <= height; j++)
                {
                    if (Hans.xCor == i & Hans.yCor == j)
                        sb.Append("M");
                    else if (AllRobots.Any(robot => robot.xCor == i & robot.yCor == j))
                        sb.Append("R");
                    else
                        sb.Append(".");
                }
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb.ToString());
        }

        // Move the mechanic and the robots
        public void Move(string moves)
        {
            Hans.Move(moves);
            if (Hans.xCor < 1)
                Hans.xCor = 1;
            else if (Hans.yCor < 1)
                Hans.yCor = 1;
            else if (Hans.xCor > width)
                Hans.xCor = width;
            else if (Hans.yCor > height)
                Hans.yCor = height;

            if(robotsMove)
                foreach(Robot robot in AllRobots)
                {
                    robot.Move(moves);
                    while(robot.xCor<1 | robot.xCor > width | robot.yCor < 1 | robot.yCor > height)
                    {
                        robot.Move(moves);
                    }
                }

            for (int i = 0; i < AllRobots.Count; i++)
            {
                if (AllRobots[i].xCor == Hans.xCor & AllRobots[i].yCor == Hans.yCor)
                    OilRobot();
            }
        }

        // Oil the robot if the mechanic and a robot are at the same spot 
        public void OilRobot()
        {
            for(int i = AllRobots.Count-1; i >= 0; i--)
            {
                if (Hans.xCor == AllRobots[i].xCor & Hans.yCor == AllRobots[i].yCor)
                    AllRobots.RemoveAt(i);
                    robots--;
            }
        }

        // Check if the player won the game 
        public void WinOrLoose()
        {
            if (AllRobots.Count == 0)
                Console.WriteLine("Nice job!! You beat the game!");
            else
                Console.WriteLine("Too bad, you have lost :(");
        }

        // Run the game
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Oil all the robots to win by using the 'wasd' keys. Good luck!");
            while(turns>0 & AllRobots.Count > 0)
            {
                ShowGame();
                Console.WriteLine("Enter moves with 'wasd':");
                string moves = Console.ReadLine();
                Move(moves);
                turns--;
            }
            ShowGame();
            WinOrLoose();
        }
    }
}
