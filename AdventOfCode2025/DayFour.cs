using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025
{

    internal class DayFour(IPuzzleInputHelper inputHelper)
    {
        public void PartOne()
        {
            char[][] paperRolls = inputHelper.GetInputMatrix("DayFour.txt");
            int accessibleRolls = 0;

            for (int y = 0; y < paperRolls.Count(); y++)
            {
                for (int x = 0; x < paperRolls[y].Count(); x++)
                {
                    if (paperRolls[y][x] == '@')
                    {
                        int surroundingRolls = CountSurroundingRolls(paperRolls, x, y);
                        if (surroundingRolls < 4)
                        {
                            accessibleRolls++;
                        }
                    }
                }
            }

            Console.WriteLine($"Part One: Accessible rolls {accessibleRolls}");
        }

        private int IsRollAtPosition(char[][] paperRolls, int x, int y)
        {
            if (x < 0 || y < 0
                || y >= paperRolls.Count()
                || x >= paperRolls[y].Count())
                return 0;

            return paperRolls[y][x] == '@' ? 1 : 0;
        }

        private int CountSurroundingRolls(char[][] paperRolls, int x, int y)
        {
            int rolls = 0;
            rolls += IsRollAtPosition(paperRolls, x - 1, y - 1);
            rolls += IsRollAtPosition(paperRolls, x - 1, y);
            rolls += IsRollAtPosition(paperRolls, x - 1, y + 1);

            rolls += IsRollAtPosition(paperRolls, x, y - 1);
            rolls += IsRollAtPosition(paperRolls, x, y + 1);

            rolls += IsRollAtPosition(paperRolls, x + 1, y - 1);
            rolls += IsRollAtPosition(paperRolls, x + 1, y);
            rolls += IsRollAtPosition(paperRolls, x + 1, y + 1);

            return rolls;
        }

        public void PartTwo()
        {
            char[][] paperRolls = inputHelper.GetInputMatrix("DayFour.txt");
            int removedRolls = 0;
            List<(int x, int y)> rollsToRemove;

            do
            {
                rollsToRemove = new List<(int x, int y)>();
                for (int y = 0; y < paperRolls.Count(); y++)
                {
                    for (int x = 0; x < paperRolls[y].Count(); x++)
                    {
                        if (paperRolls[y][x] == '@')
                        {
                            int surroundingRolls = CountSurroundingRolls(paperRolls, x, y);
                            if (surroundingRolls < 4)
                            {
                                rollsToRemove.Add((x, y));
                            }
                        }   
                    }
                }
                foreach (var roll in rollsToRemove)
                {
                    paperRolls[roll.y][roll.x] = '.';
                    removedRolls++;
                }
            }
            while (rollsToRemove.Count != 0);

            Console.WriteLine($"Part One: Removed rolls {removedRolls}");
        }
    }
}
