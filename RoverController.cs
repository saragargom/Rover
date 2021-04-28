
using System;
using System.Text.RegularExpressions;

namespace MarsRovers
{
    class RoverController
    {
        private const string roverInstructionsFormat = "^[LRF]*$";
        private const string roverPositionFormat = "[1-9] [1-9] [NEWS]";

        public static Rover GetRover(string roverPosition, string instructions)
        {
            if (Regex.IsMatch(roverPosition, roverPositionFormat) && Regex.IsMatch(instructions, roverInstructionsFormat))
            {
                string[] roverDetail = roverPosition.Split(' ');
                int x = 0;
                int y = 0;
                if (int.TryParse(roverDetail[0], out x) && int.TryParse(roverDetail[1], out y))
                {
                    Common.Direction dir = (Common.Direction)Enum.Parse(typeof(Common.Direction), roverDetail[2]);
                    Rover rover = new Rover(x, y, dir);
                    rover.Instruction = instructions;
                    return rover;
                }
            }

            return null;
        }

        public static void SetMapGrid(IPlanet planet, string input)
        {
            string[] mapDetail = input.Split(' ');
            int x = 0;
            int y = 0;
            if (int.TryParse(mapDetail[0], out x) && int.TryParse(mapDetail[1], out y))
            {
                planet.SetMap(x, y);
            }
        }

        public static void ExploreArea(IPlanet mars, IRover rover)
        {
            Console.WriteLine(string.Format("Initial rover location- X:{0}, Y:{1}, Direction:{2}", rover.XPosition, rover.YPosition, rover.CurrentDirection.ToString()));
            foreach (char command in rover.Instruction)
            {
                Console.WriteLine("Processing : " + command);

                if (command == (char)Common.TurnDirection.L)
                {
                    rover.TurnRight();
                }
                else if (command == (char)Common.TurnDirection.R)
                {
                    rover.TurnLeft();
                }
                else if (command == Common.ForwardCommand)
                {
                    mars.MoveRover(rover);
                }
                else
                {
                    Console.WriteLine("Invalid Command: " + command);
                }

                Console.WriteLine(string.Format("{0}, {1}, {2}", rover.XPosition, rover.YPosition, rover.CurrentDirection.ToString()));
            }

            Console.WriteLine(string.Format("Final rover location- X:{0}, Y:{1}, Direction:{2}", rover.XPosition, rover.YPosition, rover.CurrentDirection.ToString()));
        }
    }
}
