using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.DigitalDisplay
{
    class BrokenDigitalDisplay
    {
        private string[] _examples = new string[10];
        private string[] _output = new string[4];

        public static BrokenDigitalDisplay Parse(string line)
        {
            BrokenDigitalDisplay display = new BrokenDigitalDisplay();
            string[] insAndOuts = line.Split("|");
            string[] outputs = insAndOuts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            display._output = outputs;

            return display;
        }

        internal int CountEasyDigits()
        {
            int sum = 0;
            for (int i = 0; i < 4; i++)
            {
                if (_output[i].Length == 2
                    || _output[i].Length == 3
                    || _output[i].Length == 4
                    || _output[i].Length == 7)
                {
                    sum++;
                }
            }
            return sum;
        }
    }
}
