using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AdventOfCode2019.Program;

namespace AdventOfCode2019
{
    public class Layer
    {
        public int Width => 25;
        public int Height => 6;
        public List<int> Pixels => new List<int>();
        public int Zeroes = 0;
        public int Ones = 0;
        public int Twos = 0;
    }
    public static class DayEight
    {
        public static void PartOne()
        {
            string input = InputHelper.GetInputFromFile("8");
            List<Layer> layers = new List<Layer>();
            int i = 0;
            while (i + 25 * 6 < input.Length)
            {
                string layerString = input.Substring(i, 25 * 6);
                Layer l = new Layer();
                for (int x = 0; x < 25; x++)
                {
                    for (int y = 0; y < 6; y++)
                    {
                        l.Pixels.Add(layerString[x + y * 25] - '0');
                        switch (l.Pixels.Last())
                        {
                            case 0:
                                l.Zeroes++;
                                break;
                            case 1:
                                l.Ones++;
                                break;
                            case 2:
                                l.Twos++;
                                break;
                        }
                    }
                }
                layers.Add(l);
                i += (25 * 6);
            }
            Layer fattest = layers.First(l => l.Zeroes == layers.Min(l => l.Zeroes));
            Console.WriteLine("Result: " + fattest.Ones * fattest.Twos);
        }
    }
}
