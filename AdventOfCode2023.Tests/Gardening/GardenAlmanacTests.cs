using AdventOfCode2023.Gardening;
using FluentAssertions;

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
            almanac.SeedsToSoilMapRanges[0].SourceStart.Should().Be(98);
            almanac.SeedsToSoilMapRanges[0].DestinationStart.Should().Be(50);
            almanac.SeedsToSoilMapRanges[0].RangeSize.Should().Be(2);
            almanac.SeedsToSoilMapRanges[1].SourceStart.Should().Be(50);
            almanac.SeedsToSoilMapRanges[1].DestinationStart.Should().Be(52);
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
            almanac.GardeningPlans[0].Soil.Should().Be(81);
            almanac.GardeningPlans[1].Soil.Should().Be(14);
            almanac.GardeningPlans[2].Soil.Should().Be(57);
            almanac.GardeningPlans[3].Soil.Should().Be(13);
        }

        [Test]
        public void GardeningPlans_Should_Map_Fertilizers_To_Soils()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.GardeningPlans.Should().HaveCount(4);
            almanac.GardeningPlans[0].Fertilizer.Should().Be(81);
            almanac.GardeningPlans[1].Fertilizer.Should().Be(53);
            almanac.GardeningPlans[2].Fertilizer.Should().Be(57);
            almanac.GardeningPlans[3].Fertilizer.Should().Be(52);
        }

        [Test]
        public void GardeningPlans_Should_Map_Water_To_Fertilizers()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.GardeningPlans.Should().HaveCount(4);
            almanac.GardeningPlans[0].Water.Should().Be(81);
            almanac.GardeningPlans[1].Water.Should().Be(49);
            almanac.GardeningPlans[2].Water.Should().Be(53);
            almanac.GardeningPlans[3].Water.Should().Be(41);
        }

        [Test]
        public void GardeningPlans_Should_Map_Light_To_Water()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.GardeningPlans.Should().HaveCount(4);
            almanac.GardeningPlans[0].Light.Should().Be(74);
            almanac.GardeningPlans[1].Light.Should().Be(42);
            almanac.GardeningPlans[2].Light.Should().Be(46);
            almanac.GardeningPlans[3].Light.Should().Be(34);
        }

        [Test]
        public void GardeningPlans_Should_Map_Temperature_To_Light()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.GardeningPlans.Should().HaveCount(4);
            almanac.GardeningPlans[0].Temperature.Should().Be(78);
            almanac.GardeningPlans[1].Temperature.Should().Be(42);
            almanac.GardeningPlans[2].Temperature.Should().Be(82);
            almanac.GardeningPlans[3].Temperature.Should().Be(34);
        }

        [Test]
        public void GardeningPlans_Should_Map_Humidity_To_Temperature()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.GardeningPlans.Should().HaveCount(4);
            almanac.GardeningPlans[0].Humidity.Should().Be(78);
            almanac.GardeningPlans[1].Humidity.Should().Be(43);
            almanac.GardeningPlans[2].Humidity.Should().Be(82);
            almanac.GardeningPlans[3].Humidity.Should().Be(35);
        }

        [Test]
        public void GardeningPlans_Should_Map_Location_To_Humidity()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.GardeningPlans.Should().HaveCount(4);
            almanac.GardeningPlans[0].Location.Should().Be(82);
            almanac.GardeningPlans[1].Location.Should().Be(43);
            almanac.GardeningPlans[2].Location.Should().Be(86);
            almanac.GardeningPlans[3].Location.Should().Be(35);
        }

        [Test]
        public void AdvancedGardeningPlans_Should_Contain_One_SeedRange_Each()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.AdvancedGardeningPlans.Should().HaveCount(2);
            almanac.AdvancedGardeningPlans[0].SeedRange.Start.Should().Be(79);
            almanac.AdvancedGardeningPlans[0].SeedRange.End.Should().Be(92);
            almanac.AdvancedGardeningPlans[1].SeedRange.Start.Should().Be(55);
            almanac.AdvancedGardeningPlans[1].SeedRange.End.Should().Be(67);
        }

        [Test]
        public void AdvancedGardeningPlans_Should_Map_SeedRange_Into_SoilRanges()
        {
            List<List<string>> input = GetTestAlmanacInput();
            input[0] = new() { "seeds: 0 50" };
            input[1] = new() { "seed-to-soil map:", "10 0 50" };

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.AdvancedGardeningPlans.Should().HaveCount(1);
            almanac.AdvancedGardeningPlans[0].SoilRanges.Should().HaveCount(1);
            almanac.AdvancedGardeningPlans[0].SoilRanges[0].Start.Should().Be(10);
            almanac.AdvancedGardeningPlans[0].SoilRanges[0].End.Should().Be(59);
        }

        [Test]
        public void AdvancedGardeningPlans_Should_Split_To_Two_SubRanges_When_There_Is_A_Mapped_Portion_At_The_End()
        {
            List<List<string>> input = GetTestAlmanacInput();
            input[0] = new() { "seeds: 0 50" };
            input[1] = new() { "seed-to-soil map:", "35 25 25" };

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.AdvancedGardeningPlans.Should().HaveCount(1);
            almanac.AdvancedGardeningPlans[0].SoilRanges.Should().HaveCount(2);
            almanac.AdvancedGardeningPlans[0].SoilRanges[0].Start.Should().Be(0);
            almanac.AdvancedGardeningPlans[0].SoilRanges[0].End.Should().Be(24);
            almanac.AdvancedGardeningPlans[0].SoilRanges[1].Start.Should().Be(35);
            almanac.AdvancedGardeningPlans[0].SoilRanges[1].End.Should().Be(59);
        }

        [Test]
        public void AdvancedGardeningPlans_Should_Split_To_Two_SubRanges_When_There_Is_A_Mapped_Portion_At_The_Start()
        {
            List<List<string>> input = GetTestAlmanacInput();
            input[0] = new() { "seeds: 10 50" };
            input[1] = new() { "seed-to-soil map:", "0 10 25" };

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.AdvancedGardeningPlans.Should().HaveCount(1);
            almanac.AdvancedGardeningPlans[0].SoilRanges.Should().HaveCount(2);
            almanac.AdvancedGardeningPlans[0].SoilRanges[0].Start.Should().Be(0);
            almanac.AdvancedGardeningPlans[0].SoilRanges[0].End.Should().Be(24);
            almanac.AdvancedGardeningPlans[0].SoilRanges[1].Start.Should().Be(35);
            almanac.AdvancedGardeningPlans[0].SoilRanges[1].End.Should().Be(59);
        }

        [Test]
        public void AdvancedGardeningPlans_Should_Split_To_Three_SubRanges_When_There_Is_A_Mapped_Portion_In_The_Middle()
        {
            List<List<string>> input = GetTestAlmanacInput();
            input[0] = new() { "seeds: 0 50" };
            input[1] = new() { "seed-to-soil map:", "1010 10 5" };

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.AdvancedGardeningPlans.Should().HaveCount(1);
            almanac.AdvancedGardeningPlans[0].SoilRanges.Should().HaveCount(3);
            almanac.AdvancedGardeningPlans[0].SoilRanges[0].Start.Should().Be(0);
            almanac.AdvancedGardeningPlans[0].SoilRanges[0].End.Should().Be(9);
            almanac.AdvancedGardeningPlans[0].SoilRanges[1].Start.Should().Be(1010);
            almanac.AdvancedGardeningPlans[0].SoilRanges[1].End.Should().Be(1014);
            almanac.AdvancedGardeningPlans[0].SoilRanges[2].Start.Should().Be(15);
            almanac.AdvancedGardeningPlans[0].SoilRanges[2].End.Should().Be(49);
        }

        [Test]
        public void AdvancedGardeningPlans_Should_Keep_One_Range_When_There_Is_A_Bigger_Mapped_Portion_Around()
        {
            List<List<string>> input = GetTestAlmanacInput();
            input[0] = new() { "seeds: 10 50" };
            input[1] = new() { "seed-to-soil map:", "10 0 60" };

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.AdvancedGardeningPlans.Should().HaveCount(1);
            almanac.AdvancedGardeningPlans[0].SoilRanges.Should().HaveCount(1);
            almanac.AdvancedGardeningPlans[0].SoilRanges[0].Start.Should().Be(20);
            almanac.AdvancedGardeningPlans[0].SoilRanges[0].End.Should().Be(69);
        }

        [Test]
        public void AdvancedGardeningPlans_Should_Be_Able_To_Apply_Two_Maps()
        {
            List<List<string>> input = GetTestAlmanacInput();
            input[0] = new() { "seeds: 0 50" };
            input[1] = new() { "seed-to-soil map:", "2 0 25", "23 25 25" };

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.AdvancedGardeningPlans.Should().HaveCount(1);
            almanac.AdvancedGardeningPlans[0].SoilRanges.Should().HaveCount(2);
            almanac.AdvancedGardeningPlans[0].SoilRanges[0].Start.Should().Be(2);
            almanac.AdvancedGardeningPlans[0].SoilRanges[0].End.Should().Be(26);
            almanac.AdvancedGardeningPlans[0].SoilRanges[1].Start.Should().Be(23);
            almanac.AdvancedGardeningPlans[0].SoilRanges[1].End.Should().Be(47);
        }

        [Test]
        public void AdvancedGardeningPlans_Should_Map_List_Of_SoilRanges_To_One_List_Of_FertilizerRanges_When_There_Is_No_Mapping_Applied()
        {
            List<List<string>> input = GetTestAlmanacInput();
            input[0] = new() { "seeds: 10 50" };
            input[1] = new() { "seed-to-soil map:", "0 10 25" };
            input[2] = new() { "soil-to-fertilizer map:", "0 100 1" };

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.AdvancedGardeningPlans.Should().HaveCount(1);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges.Should().HaveCount(2);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[0].Start.Should().Be(0);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[0].End.Should().Be(24);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[1].Start.Should().Be(35);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[1].End.Should().Be(59);
        }

        [Test]
        public void AdvancedGardeningPlans_Should_Map_List_Of_SoilRanges_To_One_List_Of_FertilizerRanges_When_There_Is_Some_Mapping_Applied()
        {
            List<List<string>> input = GetTestAlmanacInput();
            input[0] = new() { "seeds: 10 50" };
            input[1] = new() { "seed-to-soil map:", "0 10 25" };
            input[2] = new() { "soil-to-fertilizer map:", "1000 10 5", "100 40 8" };

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.AdvancedGardeningPlans.Should().HaveCount(1);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges.Should().HaveCount(6);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[0].Start.Should().Be(0);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[0].End.Should().Be(9);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[1].Start.Should().Be(1000);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[1].End.Should().Be(1004);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[2].Start.Should().Be(15);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[2].End.Should().Be(24);

            almanac.AdvancedGardeningPlans[0].FertilizerRanges[3].Start.Should().Be(35);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[3].End.Should().Be(39);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[4].Start.Should().Be(100);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[4].End.Should().Be(107);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[5].Start.Should().Be(48);
            almanac.AdvancedGardeningPlans[0].FertilizerRanges[5].End.Should().Be(59);
        }

        [Test]
        public void AdvancedGardeningPlans_Should_Map_All_Elements_To_Location()
        {
            List<List<string>> input = GetTestAlmanacInput();

            GardenAlmanac almanac = GardenAlmanac.FromInput(input);

            almanac.AdvancedGardeningPlans[0].LocationRanges.Min(l => l.Start).Should().Be(46);
        }

        private static List<List<string>> GetTestAlmanacInput()
        {
            return new List<List<string>>
            {
                new() { "seeds: 79 14 55 13" },
                new() { "seed-to-soil map:", "50 98 2", "52 50 48" },
                new() { "soil-to-fertilizer map:", "0 15 37", "37 52 2", "39 0 15" },
                new() { "fertilizer-to-water map:", "49 53 8", "0 11 42", "42 0 7", "57 7 4" },
                new() { "water-to-light map:", "88 18 7", "18 25 70" },
                new() { "light-to-temperature map:", "45 77 23", "81 45 19", "68 64 13" },
                new() { "temperature-to-humidity map:", "0 69 1", "1 0 69" },
                new() { "humidity-to-location map:", "60 56 37", "56 93 4" }
            };
        }
    }
}
