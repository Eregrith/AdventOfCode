using AdventOfCode2023.BoatRaces;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests.BoatRaces
{
    internal class ChargeBoatTests
    {
        [Test]
        public void CountWaysToBeatRecord_Should_Return_Zero_When_Record_Is_Not_Beatable()
        {
            int time = 1;
            int distance = 5;
            ChargeBoat boat = new ChargeBoat(time, distance);

            long ways = boat.CountWaysToBeatRecord();

            ways.Should().Be(0);
        }

        [Test]
        public void CountWaysToBeatRecord_Should_Return_One_When_Record_Can_Be_Beaten_One_Way()
        {
            int time = 2;
            int distance = 0;
            ChargeBoat boat = new ChargeBoat(time, distance);

            long ways = boat.CountWaysToBeatRecord();

            ways.Should().Be(1);
        }

        [Test]
        public void CountWaysToBeatRecord_Should_Return_Four_When_Record_Can_Be_Beaten_Four_Ways()
        {
            int time = 7;
            int distance = 9;
            ChargeBoat boat = new ChargeBoat(time, distance);

            long ways = boat.CountWaysToBeatRecord();

            ways.Should().Be(4);
        }

        [Test]
        public void CountWaysToBeatRecord_Should_Return_Eight_When_Record_Can_Be_Beaten_Eight_Ways()
        {
            int time = 15;
            int distance = 40;
            ChargeBoat boat = new ChargeBoat(time, distance);

            long ways = boat.CountWaysToBeatRecord();

            ways.Should().Be(8);
        }

        [Test]
        public void CountWaysToBeatRecord_Should_Return_Nine_When_Record_Can_Be_Beaten_Nine_Ways()
        {
            int time = 30;
            int distance = 200;
            ChargeBoat boat = new ChargeBoat(time, distance);

            long ways = boat.CountWaysToBeatRecord();

            ways.Should().Be(9);
        }
    }
}
