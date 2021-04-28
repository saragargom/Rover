using System.Collections.Generic;

namespace MarsRovers
{
    public interface IPlanet
    {
        string Name { get; }

        int Width { get; }
        int Height { get; }

        List<IRover> rovers { get; }

        void SetMap(int rightX, int rightY);

        bool AddRover(IRover rover);

        bool MoveRover(IRover rover);
    }
}
