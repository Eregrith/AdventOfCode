using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.BoatRaces
{
    internal class ChargeBoat
    {
        private readonly long _time;
        private readonly long _distance;

        public ChargeBoat(long time, long distance)
        {
            _time = time;
            _distance = distance;
        }

        public long CountWaysToBeatRecord()
        {
            long chargeTime = 1;
            long ways = 0;
            while (chargeTime <= _time)
            {
                long distanceReached = chargeTime * (_time - chargeTime);
                if (distanceReached > _distance)
                    ways++;
                chargeTime++;
            }

            return ways;
        }
    }
}
