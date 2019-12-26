using AdventOfCode2019.Mazes;
using AdventOfCode2019.Mazes.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public static class DayTwenty
    {
        public static void PartOne()
        {
            string input = InputHelper.GetInputFromFile("20");
            Maze m = new Maze(input.ToDoubleCharArray(), new DayTwentyMazeFactory());

            m.ResetCells();
            m.SetDistancesFrom(m.Cells.OfType<MazeEntrance>().First());

            Console.WriteLine("Exit is at distance " + m.Cells.OfType<MazeExit>().First().DistanceFromStart);
        }
    }
}
