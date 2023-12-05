namespace AdventOfCode2023.Gardening;

internal class GardeningPlan
{
    public int Seed { get; set; }
    public int Soil { get; set; }
    public int Fertilizer { get; set; }

    public GardeningPlan(int seed, GardenAlmanac gardenAlmanac)
    {
        Seed = seed;
        Soil = Map(Seed, gardenAlmanac.SeedsToSoilMapRanges);
        Fertilizer = Map(Soil, gardenAlmanac.SoilToFertilizerMapRanges);
    }

    private int Map(int source, List<MapRange> map)
    {
        int destination = source;
        MapRange mapToApply = map.FirstOrDefault(m => m.AppliesTo(source));
        if (mapToApply != null)
        {
            destination = mapToApply.ApplyTo(source);
        }
        return destination;
    }
}