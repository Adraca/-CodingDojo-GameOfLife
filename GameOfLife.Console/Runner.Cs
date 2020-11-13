using GameOfLife.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;

namespace GameOfLife.Console
{
    public class Runner
    {
        private World World { get; set; }
        private int sizeX { get; set; }
        private int sizeY { get; set; }

        public Runner(int seconds)
        {
            sizeX = 10;
            sizeY = 10;
            var activatedCells = new List<Location> {
                new Location(1, 1),
                new Location(1, 2),
                new Location(4, 5),
                new Location(4, 4),
                new Location(4, 6),
            };

            World = new World(sizeX, sizeY, activatedCells);
            var timer = new Timer(seconds * 1000);
            timer.Elapsed += Run;
            timer.Enabled = true;
            DisplayWorld();
        }

        private void Run(Object source, ElapsedEventArgs e)
        {
            World.PassTurn();
            DisplayWorld();
        }

        private void DisplayWorld()
        {
            foreach (int x in Enumerable.Range(1, sizeX))
            {
                foreach (int y in Enumerable.Range(1, sizeY))
                {
                    var cell = World.Grid.FirstOrDefault(c => c.Position.X == x && c.Position.Y == y);
                    if (cell.Alive)
                    {
                        System.Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.Write(" * ");
                        System.Console.ForegroundColor = ConsoleColor.White;
                    }
                    else System.Console.Write(" * ");
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine(World.Turn);
            System.Console.SetCursorPosition(0, 1);
        }
    }
}
