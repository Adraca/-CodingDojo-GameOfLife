using System;

namespace GameOfLife.Core
{
    public class Cell : ICloneable
    {
        public bool Alive { get; private set; }
        public Location Position { get; private set; }

        public Cell(int x, int y)
        {
            Position = new Location(x, y);
        }

        public void Revive()
        {
            Alive = true;
        }

        public void Kill()
        {
            Alive = false;
        }

        public object Clone()
        {
            var value = new Cell(Position.X, Position.Y);
            value.Alive = Alive;
            return value;
        }
    }
}
