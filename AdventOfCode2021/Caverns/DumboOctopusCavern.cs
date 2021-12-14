using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Caverns
{
    internal class DumboOctopusCavern
    {
        private DumboOctopus[][] Octopuses { get; set; }

        public DumboOctopusCavern(List<string> lines)
        {
            Octopuses = new DumboOctopus[lines.Count][];
            for (int y = 0; y < lines.Count; y++)
            {
                Octopuses[y] = new DumboOctopus[lines[y].Length];
                for (int x = 0; x < lines[y].Length; x++)
                {
                    Octopuses[y][x] = new DumboOctopus(int.Parse(lines[y][x] + ""));
                }
            }
        }

        internal void Display()
        {
            for (int y = 0; y < Octopuses.Length; y++)
            {
                for (int x = 0; x < Octopuses[y].Length; x++)
                {
                    var col = Console.ForegroundColor;
                    if (Octopuses[y][x].HasFlashed)
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Octopuses[y][x].Energy > 9 ? 0 : Octopuses[y][x].Energy);
                    Console.ForegroundColor = col;
                }
                Console.WriteLine();
            }
        }

        internal int CountTotalFlashes()
        {
            int total = 0;
            for (int y = 0; y < Octopuses.Length; y++)
            {
                for (int x = 0; x < Octopuses[y].Length; x++)
                {
                    total += Octopuses[y][x].Flashes;
                }
            }
            return total;
        }

        internal bool DidAllOctopusFlashedThisStep()
        {
            for (int y = 0; y < Octopuses.Length; y++)
            {
                for (int x = 0; x < Octopuses[y].Length; x++)
                {
                    if (!Octopuses[y][x].HasFlashed)
                        return false;
                }
            }
            return true;
        }

        internal void Step()
        {
            for (int y = 0; y < Octopuses.Length; y++)
            {
                for (int x = 0; x < Octopuses[y].Length; x++)
                {
                    if (Octopuses[y][x].HasFlashed)
                    {
                        Octopuses[y][x].ResetFlash();
                        Octopuses[y][x].ResetEnergy();
                    }
                }
            }
            for (int y = 0; y < Octopuses.Length; y++)
            {
                for (int x = 0; x < Octopuses[y].Length; x++)
                {
                    Octopuses[y][x].EnergyUp();
                }
            }
            for (int y = 0; y < Octopuses.Length; y++)
            {
                for (int x = 0; x < Octopuses[y].Length; x++)
                {
                    if (Octopuses[y][x].Energy > 9 && !Octopuses[y][x].HasFlashed)
                    {
                        Octopuses[y][x].Flash();
                        EnergyUpAdjacentOctopuses(x, y);
                    }
                }
            }
        }

        private void EnergyUpAdjacentOctopuses(int x, int y)
        {
            EnergyUpIfExists(x + 1, y + 1);
            EnergyUpIfExists(x + 1, y);
            EnergyUpIfExists(x + 1, y - 1);
            EnergyUpIfExists(x, y + 1);

            EnergyUpIfExists(x, y - 1);
            EnergyUpIfExists(x - 1, y + 1);
            EnergyUpIfExists(x - 1, y);
            EnergyUpIfExists(x - 1, y - 1);
        }

        private void EnergyUpIfExists(int x, int y)
        {
            if (x >= 0 && y >= 0
                && y < Octopuses.Length
                && x < Octopuses[y].Length)
            {
                Octopuses[y][x].EnergyUp();
                if (!Octopuses[y][x].HasFlashed
                    && Octopuses[y][x].Energy > 9)
                {
                    Octopuses[y][x].Flash();
                    EnergyUpAdjacentOctopuses(x, y);
                }
            }
        }
    }
}
