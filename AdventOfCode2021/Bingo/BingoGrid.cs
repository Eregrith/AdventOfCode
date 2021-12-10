using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Bingo
{
    internal class BingoGrid
    {
        private readonly int _width;
        private readonly int _height;
        private readonly List<BingoGridCell> _grid;
        private bool _isWinning;
        public int Score { get; private set; }
        private BingoGridCell CellAt(int y, int x) => _grid[y * _width + x];
        internal void Set(int y, int x, int v) => CellAt(y, x).Value = v;

        public BingoGrid(int w, int h)
        {
            _width = w;
            _height = h;
            _isWinning = false;
            _grid = Enumerable.Range(0, h * w).Select(i => new BingoGridCell(i / w, i % w)).ToList();
        }

        public bool IsWinning => _isWinning;


        internal void NumberDrawn(int drawn)
        {
            if (_isWinning) return;
            BingoGridCell cellDrawn = _grid.FirstOrDefault(c => c.Value == drawn);
            if (cellDrawn != null)
            {
                cellDrawn.Marked = true;
                if (LineIsFullyMarked(cellDrawn.Y)
                    || ColumnIsFullyMarked(cellDrawn.X))
                {
                    _isWinning = true;
                    CalculateScore(drawn);
                    Console.WriteLine($"This grid is winning ! It has a score of {Score}");
                    Display();
                }
            }
        }

        internal void Display()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    int val = CellAt(y, x).Value;
                    bool marked = CellAt(y, x).Marked;
                    bool addSpace = val < 10;
                    Console.Write($"{(addSpace ? " " : "")}{(marked ? "[" : " ")}{val}{(marked ? "]" : " ")} ");
                }
                Console.WriteLine();
            }
        }

        private void CalculateScore(int drawn)
        {
            Score = _grid.Where(g => !g.Marked).Sum(g => g.Value) * drawn;
        }

        private bool ColumnIsFullyMarked(int x)
        {
            for (int y = 0; y < _height; y++)
            {
                if (!CellAt(y, x).Marked)
                    return false;
            }
            return true;
        }

        private bool LineIsFullyMarked(int y)
        {
            for (int x = 0; x < _height; x++)
            {
                if (!CellAt(y, x).Marked)
                    return false;
            }
            return true;
        }

    }
}