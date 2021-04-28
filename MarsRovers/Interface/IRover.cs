using static MarsRovers.Common;

namespace MarsRovers
{
    public interface IRover
    {
        #region Properties
        int XPosition { get; set; }
        int YPosition { get; set; }
        
        Direction CurrentDirection { get; set; }

        string Instruction { get; set; }

        #endregion

        #region Methods

        void TurnLeft();
        void TurnRight();
        bool Forward();
        #endregion
    }
}
