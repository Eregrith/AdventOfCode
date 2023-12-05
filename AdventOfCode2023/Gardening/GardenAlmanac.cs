namespace AdventOfCode2023.Gardening
{
    internal class GardenAlmanac
    {
        public List<long> Seeds { get; set; }
        public List<MapRange> SeedsToSoilMapRanges { get; private set; }
        public List<MapRange> SoilToFertilizerMapRanges { get; private set; }
        public List<MapRange> FertilizerToWaterMapRanges { get; private set; }
        public List<MapRange> WaterToLightMapRanges { get; private set; }
        public List<MapRange> LightToTemperatureMapRanges { get; private set; }
        public List<MapRange> TemperatureToHumidityMapRanges { get; private set; }
        public List<MapRange> HumidityToLocationMapRanges { get; private set; }

        private List<GardeningPlan>? _gardeningPlanLazy;
        public List<GardeningPlan> GardeningPlans => _gardeningPlanLazy ??= Seeds.Select(s => new GardeningPlan(s, this)).ToList();

        private List<AdvancedGardeningPlan>? _advancedGardeningPlanLazy;
        public List<AdvancedGardeningPlan> AdvancedGardeningPlans => _advancedGardeningPlanLazy ??= GenerateAdvancedGardeningPlans();

        private List<AdvancedGardeningPlan>? GenerateAdvancedGardeningPlans()
        {
            List<AdvancedGardeningPlan> advancedPlans = new();
            for (int i = 0; i < Seeds.Count; i += 2)
            {
                long seedRangeStart = Seeds[i];
                long seedRangeEnd = seedRangeStart + Seeds[i + 1] - 1;
                AdvancedGardeningPlan advancedPlan = new(seedRangeStart, seedRangeEnd, this);
                advancedPlans.Add(advancedPlan);
            }
            return advancedPlans;
        }

        public static GardenAlmanac FromInput(List<List<string>> input)
        {
            var almanac = new GardenAlmanac();

            almanac.Seeds = input[0][0].Substring(7).Split(' ').Select(long.Parse).ToList();
            almanac.SeedsToSoilMapRanges = input[1].Skip(1).Select(MapRange.FromLine).ToList();
            almanac.SoilToFertilizerMapRanges = input[2].Skip(1).Select(MapRange.FromLine).ToList();
            almanac.FertilizerToWaterMapRanges = input[3].Skip(1).Select(MapRange.FromLine).ToList();
            almanac.WaterToLightMapRanges = input[4].Skip(1).Select(MapRange.FromLine).ToList();
            almanac.LightToTemperatureMapRanges = input[5].Skip(1).Select(MapRange.FromLine).ToList();
            almanac.TemperatureToHumidityMapRanges = input[6].Skip(1).Select(MapRange.FromLine).ToList();
            almanac.HumidityToLocationMapRanges = input[7].Skip(1).Select(MapRange.FromLine).ToList();

            return almanac;
        }
    }
}
