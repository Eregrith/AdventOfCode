using AdventOfCode.Elves.DataHelpers;
using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class DayEleven
    {
        public static void PartOne()
        {
            char[][] seats = PuzzleInputHelper.GetInputMatrix("DayEleven.txt");

            string displayRect = MatrixHelper<char>.GetDisplayRectangle(seats, new System.Drawing.Rectangle(0, 0, 20, 20));
            Console.WriteLine(displayRect);

            OneRound(seats);

            Console.WriteLine();

            displayRect = MatrixHelper<char>.GetDisplayRectangle(seats, new System.Drawing.Rectangle(0, 0, 20, 20));
            Console.WriteLine(displayRect);
        }

        private int SeatAtXYIsOccupied(int x, int y, char[][] seats)
        {
            if (x < 0 || y < 0 || y > seats.Length || x > seats[0].Length)
                return 0;
            return seats[y][x] == '#' ? 1 : 0;
        }

        private int SeatAtXYIsEmptys(int x, int y, char[][] seats)
        {
            if (x < 0 || y < 0 || y > seats.Length || x > seats[0].Length)
                return 0;
            return seats[y][x] == 'L' ? 1 : 0;
        }

        private int CountAdjacentOccupiedSeats(int x, int y, char[][] seats)
        {
            int occupied = 0;
            occupied += SeatAtXYIsOccupied(x + 1, y + 1, seats);
            occupied += SeatAtXYIsOccupied(x + 1, y, seats);
            occupied += SeatAtXYIsOccupied(x + 1, y - 1, seats);
            occupied += SeatAtXYIsOccupied(x, y - 1, seats);
            occupied += SeatAtXYIsOccupied(x - 1, y - 1, seats);
            occupied += SeatAtXYIsOccupied(x - 1, y, seats);
            occupied += SeatAtXYIsOccupied(x - 1, y + 1, seats);
            return occupied;
        }

        private static void OneRound(char[][] seats)
        {
            char[][] newSeats = new char[seats.Length][];

            for (int y = 0; y < seats.Length; y++)
            {
                for (int x = 0; x < seats[y].Length; x++)
                {
                     if (seats[y][x] == '.')
                          newSeats[y][x] = '.'
                     else if (SeatAtXYIsOccupied(x, y, seats) == 0)
                          newSeats[y][x] = CountAdjacentOccupiedSeats(x, y, seats) == 0 ? '#' : seats[y][x];
                     else
                          newSeats[y][x] = CountAdjacentOccupiedSeats(x, y, seats) >= 4 ? 'L' : seats[y][x];
                }
            }
        }
    }
}
