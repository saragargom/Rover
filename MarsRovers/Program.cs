using System;
using System.Collections.Generic;
using System.IO;

namespace MarsRovers
{
    class Program
    {
        // TODO: dependency injection

        static void Main(string[] args)
        {
            // The first line of input is the upper-right coordinates of the rectangular world, the lower-left coordinates are assumed to be 0, 0.
            Console.WriteLine("Hello to Martian Robot sequence!");
            Console.WriteLine("Please, the file path with then instructions");

            string filepath = Console.ReadLine();

            IPlanet mars = CreatePlanet("Mars");           

            List<IRover> rovers = ExtractRoverDataFromInput(filepath, mars);

            if (rovers == null)
            {
                Console.WriteLine("Could not create any rover with provided instructions");
            }

            foreach (IRover rover in rovers)
            {
                Console.WriteLine("----Processing Rover------");
                if (!mars.AddRover(rover))
                {
                    Console.WriteLine("Could not add rover to plateau.");
                }
                else
                {
                    RoverController.ExploreArea(mars, rover);
                }
            }

            Console.Read();
            return;
        }



        private static List<IRover> ExtractRoverDataFromInput(string inputFile, IPlanet mars)
        {
            try
            {
                List<IRover> roverDataCollection = new List<IRover>();

                string[] lines = File.ReadAllLines(inputFile);
                RoverController.SetMapGrid(mars, lines[0]);

                for (int counter = 1; counter < lines.Length - 1; counter = counter + 2)
                {
                    Rover rover = RoverController.GetRover(lines[counter], lines[counter + 1]);
                    if (rover != null)
                    {
                        roverDataCollection.Add(rover);
                    }
                    else
                    {
                        Console.WriteLine(string.Format("A rover could not be created. Invalid Raw material: {0} {1}", lines[counter], lines[counter + 1]));
                    }
                }

                return roverDataCollection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while processing the input. Please make sure the input file is in correct format." + ex.Message);
                return null;
            }
        }

        static Planet CreatePlanet(string name)
        {
            return new Planet(name);
        }       
    }
}
