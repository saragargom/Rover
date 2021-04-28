using MarsRovers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MarsRovers.Common;

namespace MarsRoversTest
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void CreateRover_OK()
        {
            Rover myRover = new Rover(25, 30, Direction.N);

            Assert.IsTrue(myRover.XPosition == 25);
            Assert.IsTrue(myRover.YPosition == 30);
            Assert.IsTrue(myRover.CurrentDirection == Direction.N);
        }

        public void TurnLeft_NorthToWest()
        {
            Rover myRover = new Rover(25, 30, Direction.N);
            myRover.TurnLeft();
            myRover.CurrentDirection = Direction.W;
        }

        public void TurnRight_NorthToEast()
        {
            Rover myRover = new Rover(25, 30, Direction.N);
            myRover.TurnLeft();
            myRover.CurrentDirection = Direction.E;
        }

        // TODO: others test methods
    }
}
