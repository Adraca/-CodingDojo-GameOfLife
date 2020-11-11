using GameOfLife.Core;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellTests
    {
        [Fact]
        public void IsCellInit()
        {
            var cell = new Cell(1, 1);
            Assert.NotNull(cell);
        }

        [Fact]
        public void IsCellDead()
        {
            var cell = new Cell(1, 1);
            Assert.False(cell.Alive);
        }

        [Fact]
        public void IsCellAlive()
        {
            var cell = new Cell(1, 1);
            cell.Revive();
            Assert.True(cell.Alive);
        }

        [Fact]
        public void AliveCellCanBeKilled()
        {
            var cell = new Cell(1, 1);
            cell.Revive();
            cell.Kill();
            Assert.False(cell.Alive);
        }

        [Fact]
        public void CellHasXCoord()
        {
            var x = 1;
            var cell = new Cell(x, 1);
            Assert.True(cell.Position.X == x);
        }

        [Fact]
        public void CellHasYCoord()
        {
            var y = 1;
            var cell = new Cell(1, y);
            Assert.True(cell.Position.Y == y);
        }
    }
}
