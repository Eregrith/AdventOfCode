namespace AdventOfCode2023.Gardening
{
    internal class AdvancedGardeningPlan
    {
        public long SeedRangeStart { get; }
        public long SeedRangeEnd { get; }
        public LongRange SeedRange { get; }
        public List<LongRange> SoilRanges { get; }
        public List<LongRange> FertilizerRanges { get; }
        public List<LongRange> WaterRanges { get; }
        public List<LongRange> LightRanges { get; }
        public List<LongRange> TemperatureRanges { get; }
        public List<LongRange> HumidityRanges { get; }
        public List<LongRange> LocationRanges { get; }

        public AdvancedGardeningPlan(long seedRangeStart, long seedRangeEnd, GardenAlmanac gardenAlmanac)
        {
            SeedRange = new LongRange(seedRangeStart, seedRangeEnd);
            SoilRanges = CutRangeAndMap(new() { SeedRange }, gardenAlmanac.SeedsToSoilMapRanges);
            FertilizerRanges = CutRangeAndMap(SoilRanges, gardenAlmanac.SoilToFertilizerMapRanges);
            WaterRanges = CutRangeAndMap(FertilizerRanges, gardenAlmanac.FertilizerToWaterMapRanges);
            LightRanges = CutRangeAndMap(WaterRanges, gardenAlmanac.WaterToLightMapRanges);
            TemperatureRanges = CutRangeAndMap(LightRanges, gardenAlmanac.LightToTemperatureMapRanges);
            HumidityRanges = CutRangeAndMap(TemperatureRanges, gardenAlmanac.TemperatureToHumidityMapRanges);
            LocationRanges = CutRangeAndMap(HumidityRanges, gardenAlmanac.HumidityToLocationMapRanges);
        }

        public List<LongRange> CutRangeAndMap(List<LongRange> ranges, List<MapRange> mapsToApply)
        {
            List<LongRange> subRanges = new();
            subRanges.AddRange(ranges);

            foreach (MapRange map in mapsToApply)
            {
                LongRange? rangeInMap = GetRangeInMap(subRanges, map);
                while (rangeInMap != null)
                {
                    subRanges.Remove(rangeInMap);
                    long insideRangeStart = Math.Max(map.SourceStart, rangeInMap.Start);
                    long insideRangeEnd = Math.Min(rangeInMap.End, map.SourceEnd);
                    LongRange before = new LongRange(rangeInMap.Start, insideRangeStart - 1);
                    if (before.Size > 0)
                        subRanges.Add(before);

                    LongRange inside = new LongRange(insideRangeStart + map.Offset, insideRangeEnd + map.Offset);
                    inside.Mapped = true;
                    subRanges.Add(inside);

                    LongRange after = new LongRange(insideRangeEnd + 1, rangeInMap.End);
                    if (after.Size > 0)
                        subRanges.Add(after);

                    rangeInMap = GetRangeInMap(subRanges, map);
                }
            }
            subRanges.ForEach(r => r.Mapped = false);
            return subRanges;
        }

        private static LongRange? GetRangeInMap(List<LongRange> subRanges, MapRange map)
        {
            return subRanges.FirstOrDefault(r => !r.Mapped && r.Intersects(map.SourceStart, map.SourceEnd));
        }
    }
}