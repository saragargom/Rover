using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers
{

    // TODO: TDD
    // TODO: Include The maximum value for any coordinate is 50.
    public class Planet : IPlanet
    {
        #region Properties
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Name { get; private set; }
        public List<IRover> rovers { get; private set; }

        IRover[,] Land;
        #endregion

        #region Constructor
        public Planet(string name)
        {
            this.Name = name;
        }
        #endregion


        #region Public Methods
        public void SetMap(int rightX, int rightY)
        {
            this.Width = rightX;
            this.Height = rightY;
            this.Land = new Rover[rightX + 1, rightY + 1];
        }

        public bool AddRover(IRover rover)
        {
            if (!AreCoordinatesValid(rover.XPosition, rover.YPosition))
            {
                return false;
            }

            this.Land[rover.XPosition, rover.YPosition] = rover;
            return true;
        }

        public bool MoveRover(IRover rover)
        {
            bool result = true;

            int oldXPosition = rover.XPosition;
            int oldYPosition = rover.YPosition;

            int newXPosition = oldXPosition;
            int newYPosition = oldYPosition;

            switch (rover.CurrentDirection)
            {
                case Common.Direction.E:
                    ++newXPosition;
                    break;
                case Common.Direction.N:
                    ++newYPosition;
                    break;
                case Common.Direction.W:
                    --newXPosition;
                    break;
                case Common.Direction.S:
                    --newYPosition;
                    break;
            }

            if (!AreCoordinatesValid(newXPosition, newYPosition))
            {
                Console.WriteLine("Cannot Move. New coordinates are not valid. Skipping this movement.");
                result = false;
            }

            rover.XPosition = newXPosition;
            rover.YPosition = newYPosition;
            this.Land[oldXPosition, oldYPosition] = null;
            this.Land[newXPosition, newYPosition] = rover;
            
            return result;
        }
        #endregion

        #region Private Methods
        private bool AreCoordinatesValid(int xCoordinate, int yCoordinate)
        {
            if (xCoordinate < 0 || yCoordinate < 0)
            {
                Console.WriteLine("Invalid coordinates: None of the coordinates can be negative.");
                return false;
            }

            if (xCoordinate > this.Width || yCoordinate > this.Height)
            {
                Console.WriteLine("Invalid Coordinates: Out of boundary");
                return false;
            }

            if (this.Land[xCoordinate, yCoordinate] != null)
            {
                Console.WriteLine("There is already a rover at these coordinates");
                return false;
            }

            return true;
        }

        
        #endregion
    }
}
