using AdventOfCode2023.Gardening;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests.Gardening
{
    internal class GardenAlmanacTests
    {
        [Test]
        public void FromInput_Should_Return_Parsed_Almanac_Containing_Seeds()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.Should().NotBeNull();
            almanac.Seeds.Should().HaveCount(4);
            almanac.Seeds.Should().Contain(79);
            almanac.Seeds.Should().Contain(14);
            almanac.Seeds.Should().Contain(55);
            almanac.Seeds.Should().Contain(13);
        }

        [Test]
        public void FromInput_Should_Return_Parsed_Almanac_Containing_Seed_To_Soil_Map()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.SeedsToSoilMapRanges.Should().HaveCount(2);
            almanac.SeedsToSoilMapRanges[0].SourceStart.Should().Be(50);
            almanac.SeedsToSoilMapRanges[0].DestinationStart.Should().Be(98);
            almanac.SeedsToSoilMapRanges[0].RangeSize.Should().Be(2);
            almanac.SeedsToSoilMapRanges[1].SourceStart.Should().Be(52);
            almanac.SeedsToSoilMapRanges[1].DestinationStart.Should().Be(50);
            almanac.SeedsToSoilMapRanges[1].RangeSize.Should().Be(48);
        }

        [Test]
        public void FromInput_Should_Return_Parsed_Almanac_Containing_GardeningPlans_For_All_Seeds()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.GardeningPlans.Should().HaveCount(4);
            almanac.GardeningPlans[0].Seed.Should().Be(79);
            almanac.GardeningPlans[1].Seed.Should().Be(14);
            almanac.GardeningPlans[2].Seed.Should().Be(55);
            almanac.GardeningPlans[3].Seed.Should().Be(13);
        }

        [Test]
        public void GardeningPlans_Should_Map_Soils_To_Seeds()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.GardeningPlans.Should().HaveCount(4);
            almanac.GardeningPlans[0].Soil.Should().Be(77);
            almanac.GardeningPlans[1].Soil.Should().Be(14);
            almanac.GardeningPlans[2].Soil.Should().Be(53);
            almanac.GardeningPlans[3].Soil.Should().Be(13);
        }

        [Test]
        public void GardeningPlans_Should_Map_Fertilizers_To_Soils()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.GardeningPlans.Should().HaveCount(4);
            almanac.GardeningPlans[0].Fertilizer.Should().Be(77);
            almanac.GardeningPlans[1].Fertilizer.Should().Be(29);
            almanac.GardeningPlans[2].Fertilizer.Should().Be(14);
            almanac.GardeningPlans[3].Fertilizer.Should().Be(28);
        }

        private static List<List<string>> GetTestAlmanacInput()
        {
            return new List<List<string>>
            {
                new() { "seeds: 79 14 55 13" },
                new() { "seed-to-soil map:", "50 98 2", "52 50 48" },
                new() { "soil-to-fertilizer map:", "0 15 37", "37 52 2", "39 0 15" }
            };
        }
    }
}
