using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static AdventOfCode2019.Program;

namespace AdventOfCode2019
{
    public class Layer
    {
        public static int Width => 25;
        public static int Height => 6;
        public int[,] Pixels { get; set; } = new int[Width,Height];
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
                        switch (l.Pixels[x, y])
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
        public static void PartTwo()
        {
            string input = InputHelper.GetInputFromFile("8");
            int width = 25;
            int height = 6;
            List<Layer> layers = new List<Layer>();
            int i = 0;
            while (i + (width * height) - 1 < input.Length)
            {
                string layerString = input.Substring(i, width * height);
                Layer l = new Layer();
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        l.Pixels[x, y] = layerString[x + (y * width)] - '0';
                    }
                }
                layers.Add(l);
                i += (width * height);
            }

            using (Bitmap bmp = new Bitmap(width, height))
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        foreach (Layer l in layers)
                        {
                            bmp.SetPixel(x, y, Color.Transparent);
                            if (l.Pixels[x, y] == 2) continue;
                            Color color = l.Pixels[x, y] == 0 ? Color.Black : Color.White;
                            bmp.SetPixel(x, y, color);
                            break;
                        }
                    }
                }
                bmp.Save(@"C:\Temp\DayEight.bmp");
            }
        }
    }
}
