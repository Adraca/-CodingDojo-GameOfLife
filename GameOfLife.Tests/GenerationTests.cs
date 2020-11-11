using GameOfLife.Core;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GameOfLife.Tests
{
    public class GenerationTests
    {
        [Fact]
        public void WorldHasDefaultGeneration()
        {
            var world = new World(1, 1);
            Assert.True(world.Turn == 1);
        }

        [Fact]
        public void WorldCanPassGeneration()
        {
            var world = new World(1, 1);
            world.PassTurn();
            Assert.True(world.Turn == 2);
        }

        [Fact]
        public void UniCellDieAfterOneTurn()
        {
            var activatedCells = new List<Location> { new Location(1, 1) };
            var world = new World(4, 4, activatedCells);
            world.PassTurn();
            Assert.True(world.Grid.Count(c => c.Alive) == 0);
        }
    }
}
