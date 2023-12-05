using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Gardening
{
    internal class GardenAlmanac
    {
        public List<int> Seeds { get; set; }
        public List<GardeningPlan> GardeningPlans { get; set; }
        public List<MapRange> SeedsToSoilMapRanges { get; set; }
        public List<MapRange> SoilToFertilizerMapRanges { get; set; }

        public static GardenAlmanac FromInput(List<List<string>> input)
        {
            var almanac = new GardenAlmanac();

            almanac.Seeds = input[0][0].Substring(7).Split(' ').Select(int.Parse).ToList();
            almanac.SeedsToSoilMapRanges = input[1].Skip(1).Select(MapRange.FromLine).ToList();
            almanac.SoilToFertilizerMapRanges = input[2].Skip(1).Select(MapRange.FromLine).ToList();
            almanac.GardeningPlans = almanac.Seeds.Select(s => new GardeningPlan(s, almanac)).ToList();

            return almanac;
        }
    }
}
