using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2023.BoatRaces;
using AdventOfCode2023.Gardening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days
{
    internal class DaySix
    {
        internal static void PartOne()
        {
            Console.WriteLine("Day six - Part One");

            ChargeBoat boat1 = new ChargeBoat(51, 222);
            ChargeBoat boat2 = new ChargeBoat(92, 2031);
            ChargeBoat boat3 = new ChargeBoat(68, 1126);
            ChargeBoat boat4 = new ChargeBoat(90, 1225);

            long product = boat1.CountWaysToBeatRecord()
                * boat2.CountWaysToBeatRecord()
                * boat3.CountWaysToBeatRecord()
                * boat4.CountWaysToBeatRecord();
            Console.WriteLine($"Product of ways is {product}");
            Console.WriteLine("Day six - End of part One");
        }

        internal static void PartTwo()
        {
            Console.WriteLine("Day six - Part Two");

            ChargeBoat boat = new ChargeBoat(51926890, 222203111261225);

            long product = boat.CountWaysToBeatRecord();
            Console.WriteLine($"Product of ways is {product}");

            Console.WriteLine("Day six - End of part Two");
        }
    }
}
