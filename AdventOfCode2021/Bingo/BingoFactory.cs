using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Bingo
{
    public static class BingoFactory
    {
        public static BingoSystem Parse(List<List<string>> lines)
        {
            List<int> numbersToDraw = lines[0][0].Split(',').Select(l => int.Parse(l)).ToList();
            BingoSystem bingo = new BingoSystem(numbersToDraw);

            foreach (List<string> grids in lines.Skip(1))
            {
                int width = grids[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Count();
                int height = grids.Count();
                BingoGrid grid = new BingoGrid(width, height);
                for (int y = 0; y < height; y++)
                {
                    var nums = grids[y].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int x = 0; x < width; x++)
                    {
                        grid.Set(y, x, int.Parse(nums[x]));
                    }
                }
                bingo.AddGrid(grid);
            }

            return bingo;
        }
    }
}
