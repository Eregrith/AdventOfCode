using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2023.Gardening;

namespace AdventOfCode2023.Days
{
    internal class DayFive
    {
        internal static void PartOne()
        {
            Console.WriteLine("Day five - Part One");
            List<List<string>> input = PuzzleInputHelper.GetInputLinesBatched("DayFive.txt", String.Empty);
            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            long minLocation = almanac.GardeningPlans.Min(g => g.Location);

            Console.WriteLine($"Lowest location number is {minLocation}");
            Console.WriteLine("Day five - End of part One");
        }

        internal static void PartTwo()
        {
            Console.WriteLine("Day five - Part Two");
            List<List<string>> input = PuzzleInputHelper.GetInputLinesBatched("DayFive.txt", String.Empty);
            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            long minLocation = almanac.AdvancedGardeningPlans.Min(a => a.LocationRanges.Min(g => g.Start));

            Console.WriteLine($"Lowest location number is {minLocation}");
            Console.WriteLine("Day five - End of part Two");
        }
    }
}
