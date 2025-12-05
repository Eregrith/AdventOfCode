using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025.Tests
{
    internal class DayThreeTests
    {
        [TestCase("987654321111111", 98)]
        [TestCase("198765432111111", 98)]
        [TestCase("108365432111117", 87)]
        [TestCase("102365432111187", 87)]
        [TestCase("811111111111119", 89)]
        [TestCase("234234234234278", 78)]
        [TestCase("818181911112111", 92)]
        public void BatteryBankJoltageChecker_Should_Find_Highest_Joltage(string batteryBank, int highestJoltage)
        {
            BatteryBankJoltageChecker checker = new BatteryBankJoltageChecker();

            checker.FindHighestJoltage(batteryBank).Should().Be(highestJoltage);
        }

        [TestCase("987654321111111", 987654321111)]
        [TestCase("811111111111119", 811111111119)]
        [TestCase("234234234234278", 434234234278)]
        [TestCase("818181911112111", 888911112111)]
        public void BatteryBankHeavyJoltageChecker_Should_Find_Highest_Joltage(string batteryBank, long highestJoltage)
        {
            BatteryBankHeavyJoltageChecker checker = new BatteryBankHeavyJoltageChecker();

            checker.FindHighestJoltage(batteryBank).Should().Be(highestJoltage);
        }
    }
}
