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
            Console.WriteLine("Day Eleven - Part One");
            char[][] seats = PuzzleInputHelper.GetInputMatrix("DayEleven.txt");

            string displayRect = MatrixHelper<char>.GetDisplayRectangle(seats, new System.Drawing.Rectangle(0, 0, 10, 10));
            Console.WriteLine(displayRect);

            (seats, _) = OneRound(seats);

            int changes;
            int rounds = 1;
            do
            {
                (seats, changes) = OneRound(seats);
                rounds++;
            }
            while (changes != 0);

            Console.WriteLine($"Finished after {rounds} rounds");

            Console.WriteLine();

            displayRect = MatrixHelper<char>.GetDisplayRectangle(seats, new System.Drawing.Rectangle(0, 0, 10, 10));
            Console.WriteLine(displayRect);

            int occupiedSeats = seats.Sum(arr => arr.Count(c => c == '#'));

            Console.WriteLine($"There are {occupiedSeats} occupied seats"); //2844 too high

            Console.WriteLine("Day Eleven - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day Eleven - Part Two");
            char[][] seats = PuzzleInputHelper.GetInputMatrix("DayEleven.txt");

            string displayRect = MatrixHelper<char>.GetDisplayRectangle(seats, new System.Drawing.Rectangle(0, 0, 10, 10));
            Console.WriteLine(displayRect);

            (seats, _) = OneRoundForPartTwo(seats);

            int changes;
            int rounds = 1;
            do
            {
                (seats, changes) = OneRound(seats);
                rounds++;
            }
            while (changes != 0);

            Console.WriteLine($"Finished after {rounds} rounds");

            Console.WriteLine();

            displayRect = MatrixHelper<char>.GetDisplayRectangle(seats, new System.Drawing.Rectangle(0, 0, 10, 10));
            Console.WriteLine(displayRect);

            int occupiedSeats = seats.Sum(arr => arr.Count(c => c == '#'));

            Console.WriteLine($"There are {occupiedSeats} occupied seats"); //2844 too high


            Console.WriteLine("Day Eleven - End of part Two");
        }

        private static int SeatAtXYIsOccupied(int x, int y, char[][] seats)
        {
            if (x < 0 || y < 0 || y >= seats.Length || x >= seats[0].Length)
                return 0;
            return seats[y][x] == '#' ? 1 : 0;
        }

        private static int CountAdjacentOccupiedSeats(int x, int y, char[][] seats)
        {
            int occupied = 0;
            occupied += SeatAtXYIsOccupied(x, y - 1, seats);
            occupied += SeatAtXYIsOccupied(x + 1, y - 1, seats);
            occupied += SeatAtXYIsOccupied(x + 1, y, seats);
            occupied += SeatAtXYIsOccupied(x + 1, y + 1, seats);
            occupied += SeatAtXYIsOccupied(x, y + 1, seats);
            occupied += SeatAtXYIsOccupied(x - 1, y + 1, seats);
            occupied += SeatAtXYIsOccupied(x - 1, y, seats);
            occupied += SeatAtXYIsOccupied(x - 1, y - 1, seats);
            return occupied;
        }

        private static (char[][], int) OneRound(char[][] seats)
        {
            char[][] newSeats = new char[seats.Length][];
            int changes = 0;

            for (int y = 0; y < seats.Length; y++)
            {
                newSeats[y] = new char[seats[y].Length];
                for (int x = 0; x < seats[y].Length; x++)
                {
                    newSeats[y][x] = seats[y][x];
                    int adjacencies = CountAdjacentOccupiedSeats(x, y, seats);
                    if (seats[y][x] != '.')
                    {
                        if (SeatAtXYIsOccupied(x, y, seats) == 0)
                        {
                            if (adjacencies == 0)
                            {
                                newSeats[y][x] = '#';
                                changes++;
                            }
                        }
                        else if (adjacencies >= 4)
                        {
                            newSeats[y][x] = 'L';
                            changes++;
                        }
                    }
                }
            }
            return (newSeats, changes);
        }

        private static (char[][], int) OneRoundForPartTwo(char[][] seats)
        {
            char[][] newSeats = new char[seats.Length][];
            int changes = 0;

            for (int y = 0; y < seats.Length; y++)
            {
                newSeats[y] = new char[seats[y].Length];
                for (int x = 0; x < seats[y].Length; x++)
                {
                    newSeats[y][x] = seats[y][x];
                    int adjacencies = CountAdjacentOccupiedSeats(x, y, seats);
                    if (seats[y][x] != '.')
                    {
                        if (SeatAtXYIsOccupied(x, y, seats) == 0)
                        {
                            if (adjacencies == 0)
                            {
                                newSeats[y][x] = '#';
                                changes++;
                            }
                        }
                        else if (adjacencies >= 4)
                        {
                            newSeats[y][x] = 'L';
                            changes++;
                        }
                    }
                }
            }
            return (newSeats, changes);
        }
    }
}
