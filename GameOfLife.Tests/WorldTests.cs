using GameOfLife.Core;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GameOfLife.Tests
{
    public class WorldTests
    {
        [Fact]
        public void IsWorldInit()
        {
            var world = new World(1, 1);
            Assert.NotNull(world);
        }

        [Fact]
        public void WorldGridIsNotEmpty()
        {
            var world = new World(1, 1);
            Assert.True(!world.Grid.Any(v => v == null));
        }

        [Fact]
        public void WorldHasCells()
        {
            var world = new World(1, 1);
            Assert.True(world.Grid.Count > 0);
        }

        [Fact]
        public void WorldCellsHasCoordX()
        {
            var x = 1;
            var world = new World(1, 1);
            Assert.True(world.Grid[0].Position.X == x);
        }

        [Fact]
        public void WorldCellsHasCoordXIncrement()
        {
            var x = 2;
            var world = new World(2, 1);
            Assert.True(world.Grid[1].Position.X == x);
        }

        [Fact]
        public void LastWorldCellsHasMaxCoordXValue()
        {
            var x = 2;
            var world = new World(2, 1);
            Assert.True(world.Grid.LastOrDefault().Position.X == x);
        }

        [Fact]
        public void WorldCellsHasCoordY()
        {
            var y = 1;
            var world = new World(1, 1);
            Assert.True(world.Grid[0].Position.Y == y);
        }

        [Fact]
        public void WorldCellsHasCoordYIncrement()
        {
            var y = 2;
            var world = new World(2, 2);
            Assert.True(world.Grid[1].Position.Y == y);
        }

        [Fact]
        public void LastWorldCellsHasMaxCoordYValue()
        {
            var y = 2;
            var world = new World(2, 2);
            Assert.True(world.Grid.LastOrDefault().Position.Y == y);
        }

        [Fact]
        public void LastWorldCellsHasValidCoords()
        {
            var x = 1;
            var y = 2;
            var world = new World(2, 2);
            Assert.NotNull(world.Grid.FirstOrDefault(c => c.Position.X == x && c.Position.Y == y));
        }

        [Fact]
        public void LastWorldCellsHasOtherValidCoords()
        {
            var x = 2;
            var y = 1;
            var world = new World(2, 2);
            Assert.NotNull(world.Grid.FirstOrDefault(c => c.Position.X == x && c.Position.Y == y));
        }

        [Fact]
        public void LastWorldCellsHasYetAnotherValidCoords()
        {
            var x = 10;
            var y = 7;
            var world = new World(10, 7);
            Assert.NotNull(world.Grid.FirstOrDefault(c => c.Position.X == x && c.Position.Y == y));
        }

        [Fact]
        public void LastWorldCellsHasOneMoreValidCoords()
        {
            var x = 8;
            var y = 6;
            var world = new World(10, 7);
            Assert.NotNull(world.Grid.FirstOrDefault(c => c.Position.X == x && c.Position.Y == y));
        }

        [Fact]
        public void AllCellsAreDead()
        {
            var world = new World(2, 2);
            Assert.True(!world.Grid.Any(c => c.Alive == true));
        }

        [Fact]
        public void WorldHasAliveCell()
        {
            var x = 1;
            var y = 1;
            var activatedCells = new List<Location> { new Location(x, y) };
            var world = new World(1, 1, activatedCells);
            Assert.True(world.Grid.FirstOrDefault(c => c.Position.X == x && c.Position.Y == y).Alive);
        }

        [Fact]
        public void WorldHasOnlyOneCellAlive()
        {
            var x = 1;
            var y = 1;
            var activatedCells = new List<Location> { new Location(x, y) };
            var world = new World(1, 1, activatedCells);
            Assert.True(world.Grid.Count(c => c.Alive) == 1);
        }

        [Fact]
        public void WorldHasAllCellsAlive()
        {
            var activatedCells = new List<Location> {
                new Location(1, 1),
                new Location(1, 2),
                new Location(2, 1),
                new Location(2, 2),
            };
            var world = new World(2, 2, activatedCells);
            Assert.True(!world.Grid.Any(c => c.Alive == false));
        }
    }
}
