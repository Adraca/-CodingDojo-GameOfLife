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
            Grid.ForEach(c => {
                if (CheckIsAlive(c)) c.Revive();
                else c.Kill();
            });
            Turn++;
        }

        private bool CheckIsAlive(Cell cell)
        {
            var liveNeighbours = FindNeighbours(cell.Position);
            if (liveNeighbours < 2 || liveNeighbours > 3) return false;
            if (liveNeighbours == 2 && !cell.Alive) return false;
            return true;
        }

        private int FindNeighbours(Location location)
        {
            return Grid.Where(c => c.Position.X == location.X && (c.Position.Y == location.Y -1 || c.Position.Y == location.Y + 1) ||
                c.Position.Y == location.Y && (c.Position.X == location.X - 1 || c.Position.X == location.X + 1)).Count(c => c.Alive);
        }
    }
}
