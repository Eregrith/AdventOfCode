using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.DigitalDisplay
{
    class BrokenDigitalDisplay
    {
        private string[] _examples = new string[10];
        private string[] _output = new string[4];
        private Dictionary<char, char> _segments = new Dictionary<char, char>();
        private Dictionary<string, int> normalDisplay = new Dictionary<string, int>
        {
            { "abcefg", 0 },
            { "cf", 1 },
            { "acdeg", 2 },
            { "acdfg", 3 },
            { "bcdf", 4 },
            { "abdfg", 5 },
            { "abdefg", 6 },
            { "acf", 7 },
            { "abcdefg", 8 },
            { "abcdfg", 9 },
        };

        public static BrokenDigitalDisplay Parse(string line)
        {
            BrokenDigitalDisplay display = new BrokenDigitalDisplay();
            string[] insAndOuts = line.Split("|");
            display._output = insAndOuts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            display._examples = insAndOuts[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
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

        internal int DecryptOutput()
        {
            foreach (char c in "abcdefg")
            {
                int count = _examples.Count(e => e.Contains(c));
                Console.Write($"{c} appears {count} times");
                if (count == 4)
                    RecordTranslatation(c, 'e');
                else if (count == 6)
                    RecordTranslatation(c, 'b');
                else if (count == 7)
                {
                    if (_examples.First(e => e.Length == 4).Contains(c))
                        RecordTranslatation(c, 'd');
                    else
                        RecordTranslatation(c, 'g');

                }
                else if (count == 9)
                    RecordTranslatation(c, 'f');
                else if (count == 8)
                {
                    if (_examples.First(e => e.Length == 2).Contains(c))
                        RecordTranslatation(c, 'c');
                    else
                        RecordTranslatation(c, 'a');
                }
                else
                {
                    Console.WriteLine($"Could not find translation for {c}");
                }
            }

            string[] decrypted = _output.Select(o => String.Join("", o.Select(c => _segments[c]).OrderBy(c => c))).ToArray();

            int output =
                  GetDigit(decrypted[0]) * 1000
                + GetDigit(decrypted[1]) * 100
                + GetDigit(decrypted[2]) * 10
                + GetDigit(decrypted[3]);

            return output;
        }

        private void RecordTranslatation(char c, char realSegment)
        {
            Console.WriteLine($"{c} is in fact {realSegment}");
            _segments.Add(c, realSegment);
        }

        private int GetDigit(string v)
        {
            return normalDisplay[v];
        }
    }
}
