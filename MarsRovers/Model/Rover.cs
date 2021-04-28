using System;
using static MarsRovers.Common;

namespace MarsRovers
{
    // Include All instruction strings will be less than 100 characters in length
    public class Rover : IRover
    {
        #region Properties        
        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public Direction CurrentDirection { get; set; }

        public string Instruction { get; set; }

        private Planet Map { get; set; }

        #endregion

        #region Constructors

        public Rover(int x, int y, Direction orientation)
        {
            this.XPosition = x;
            this.YPosition = y;
            this.CurrentDirection = orientation;
        }
        #endregion

        #region Public Methods

               
        public void TurnLeft()
        {
            switch (CurrentDirection)
            {
                case Direction.N:
                    this.CurrentDirection = Direction.W;
                    break;
                case Direction.W:
                    this.CurrentDirection = Direction.S;
                    break;
                case Direction.S:
                    this.CurrentDirection = Direction.E;
                    break;
                case Direction.E:
                    this.CurrentDirection = Direction.N;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (this.CurrentDirection)
            {
                case Direction.N:
                    this.CurrentDirection = Direction.E;
                    break;
                case Direction.E:
                    this.CurrentDirection = Direction.S;
                    break;
                case Direction.S:
                    this.CurrentDirection = Direction.W;
                    break;
                case Direction.W:
                    this.CurrentDirection = Direction.N;
                    break;
            }
        }

        public bool Forward()
        {         
            bool result = true;

            switch (this.CurrentDirection)
            {
                case Direction.N:
                    if (this.YPosition + 1 > this.Map.Height)
                    {
                        result = false;
                    }
                    else
                    {
                        this.YPosition++;
                    }
                    break;
                case Direction.W:
                    if (this.XPosition - 1 < 0)
                    {
                        result = false;
                    }
                    else
                    {
                        this.XPosition--;
                    }
                    break;
                case Direction.S:
                    if (this.YPosition - 1 < 0)
                    {
                        result = false;
                    }
                    else
                    {
                        this.YPosition--;
                    }
                    break;
                case Direction.E:
                    if (this.XPosition + 1 > Map.Width)
                    {
                        result = false;
                    }
                    else
                    {
                        this.XPosition++;
                    }
                    break;
            }

            return result;
        }

        #endregion
    }
}
