using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Bingo
{
    public class BingoSystem
    {
        private readonly Queue<int> _numbersToDraw;
        private readonly List<BingoGrid> _grids;

        public BingoSystem(List<int> numbersToDraw)
        {
            _numbersToDraw = new Queue<int>(numbersToDraw);
            _grids = new List<BingoGrid>();
        }

        public bool ThereIsAWinner => _grids.Any(g => g.IsWinning);
        public bool AllHaveWon => _grids.All(g => g.IsWinning);

        internal void AddGrid(BingoGrid grid)
        {
            _grids.Add(grid);
        }

        public int DrawNextNumber()
        {
            int drawn = _numbersToDraw.Dequeue();

            Console.WriteLine($"Drawn number {drawn}");
            _grids.ForEach(g => g.NumberDrawn(drawn));

            return drawn;
        }

        public void DisplayGrid(int gridIndex)
        {
            Console.WriteLine($"Grid {gridIndex}");
            Console.WriteLine();
            var grid = _grids[gridIndex];
            grid.Display();
        }
    }
}