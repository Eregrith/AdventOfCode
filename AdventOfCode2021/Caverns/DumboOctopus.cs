using System;

namespace AdventOfCode2021.Caverns
{
    internal class DumboOctopus
    {
        public int Energy { get; private set; }
        public bool HasFlashed { get; private set; }
        public int Flashes { get; private set; }

        public DumboOctopus(int startingEnergy)
        {
            Energy = startingEnergy;
        }

        public void Flash()
        {
            HasFlashed = true;
            Flashes++;
        }

        public void ResetFlash()
        {
            HasFlashed = false;
        }

        internal void EnergyUp()
        {
            Energy++;
        }

        internal void ResetEnergy()
        {
            Energy = 0;
        }
    }
}