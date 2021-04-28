namespace MarsRovers
{
    public class Common
    {
        public const int MaxCoordinate = 50;
        public const int MaxInstrunctionLenght = 100;

        public const char ForwardCommand = 'M';

        public enum Direction
        {
            N,
            S,
            E,
            W
        }

        public enum TurnDirection
        {
            L = 'L',
            R = 'R'
        };
    }
}
