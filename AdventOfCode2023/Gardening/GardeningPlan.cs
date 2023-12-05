namespace AdventOfCode2023.Gardening;

internal class GardeningPlan
{
    public long Seed { get; private set; }
    public long Soil { get; private set; }
    public long Fertilizer { get; private set; }
    public long Water { get; private set; }
    public long Light { get; private set; }
    public long Temperature { get; private set; }
    public long Humidity { get; private set; }
    public long Location { get; internal set; }

    public GardeningPlan(long seed, GardenAlmanac gardenAlmanac)
    {
        Seed = seed;
        Soil = Map(Seed, gardenAlmanac.SeedsToSoilMapRanges);
        Fertilizer = Map(Soil, gardenAlmanac.SoilToFertilizerMapRanges);
        Water = Map(Fertilizer, gardenAlmanac.FertilizerToWaterMapRanges);
        Light = Map(Water, gardenAlmanac.WaterToLightMapRanges);
        Temperature = Map(Light, gardenAlmanac.LightToTemperatureMapRanges);
        Humidity = Map(Temperature, gardenAlmanac.TemperatureToHumidityMapRanges);
        Location = Map(Humidity, gardenAlmanac.HumidityToLocationMapRanges);
    }

    private long Map(long source, List<MapRange> map)
    {
        long destination = source;
        MapRange mapToApply = map.FirstOrDefault(m => m.AppliesTo(source));
        if (mapToApply != null)
        {
            destination = mapToApply.ApplyTo(source);
        }
        return destination;
    }
}