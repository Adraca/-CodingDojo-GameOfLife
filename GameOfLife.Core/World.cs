using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Core
{
    public class World
    {
        public List<Cell> Grid { get; private set; }
        public int Turn { get; private set; }
        
        public World(int sizeX, int sizeY, List<Location> locations = null)
        {
            Grid = new List<Cell>(sizeX * sizeY);
            Turn = 1;
            foreach (int x in Enumerable.Range(1, sizeX))
                foreach (int y in Enumerable.Range(1, sizeY))
                    Grid.Add(new Cell(x, y));

            if (locations != null)
                foreach(var loc in locations)
                    Grid.FirstOrDefault(c => c.Position.X == loc.X && c.Position.Y == loc.Y).Revive();
        }

        public void PassTurn()
        {
            var newGrid = Clone(Grid);
            newGrid.ForEach(c => {
                if (CheckIsAlive(c)) c.Revive();
                else c.Kill();
            });
            Grid = newGrid;
            Turn++;
        }

        private bool CheckIsAlive(Cell cell)
        {
            var liveNeighbours = FindNeighbours(cell.Position);
            if (liveNeighbours == 2 && cell.Alive) return true;
            if (liveNeighbours == 3) return true;
            return false; 
        }

        private int FindNeighbours(Location location)
        {
            return Grid.Where(c => !(c.Position.X == location.X && c.Position.Y == location.Y) &&
                ((c.Position.X == location.X - 1 || c.Position.X == location.X + 1) && c.Position.Y == location.Y ||
                (c.Position.Y == location.Y - 1 || c.Position.Y == location.Y + 1) && c.Position.X == location.X) ||
                (c.Position.X == location.X - 1 && c.Position.Y == location.Y - 1) ||
                (c.Position.X == location.X + 1 && c.Position.Y == location.Y + 1) ||
                (c.Position.X == location.X - 1 && c.Position.Y == location.Y + 1) ||
                (c.Position.X == location.X + 1 && c.Position.Y == location.Y - 1))
                .Count(c => c.Alive);
        }

        private List<T> Clone<T>(List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
