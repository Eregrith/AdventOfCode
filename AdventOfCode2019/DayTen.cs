using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static AdventOfCode2019.Program;

namespace AdventOfCode2019
{
    public static class DayTen
    {
        public class Asteroid
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Sight { get; set; } = 0;
            public double Angle { get; set; } = 0;
            public double Distance { get; internal set; }

            public Asteroid(int x, int y)
            {
                X = x;
                Y = y;
            }

            internal bool CanSee(Asteroid otherAsteroid, IEnumerable<Asteroid> field)
            {
                int vX = otherAsteroid.X - X;
                int vY = otherAsteroid.Y - Y;
                double thisK = (otherAsteroid.X - X) / (double)vX;
                if (vX == 0)
                    thisK = (otherAsteroid.Y - Y) / (double)vY;
                if (X == 18 && Y == 30)
                    Console.WriteLine($"Checking for {otherAsteroid.X} {otherAsteroid.Y}. V {vX} {vY} (k = {thisK}).");
                var asteroidsOnTheLine = field.Where(a => ((a.X - X) * vY) == ((a.Y - Y) * vX));
                if (X == 18 && Y == 30)
                    Console.WriteLine($"Found {asteroidsOnTheLine.Count()} asteroids on the same line");
                if (!asteroidsOnTheLine.Any(a => HasSameSignedK(a, vX, vY, thisK))) return true;

                double minK = asteroidsOnTheLine.Where(a => HasSameSignedK(a, vX, vY, thisK)).Min(a => Math.Abs(K(a, vX, vY)));
                if (X == 18 && Y == 30)
                    Console.WriteLine($"Minimum K on the same side is { minK }");
                if (minK < Math.Abs(thisK))
                    return false;
                return true;
            }

            private double K(Asteroid a, double vX, double vY)
            {
                if (vX == 0)
                    return (a.Y - Y) / vY;
                return (a.X - X) / vX;
            }

            private bool HasSameSignedK(Asteroid a, double vX, double vY, double thisK)
            {
                if (vX == 0)
                    return ((a.Y - Y) / (double)vY > 0) == (thisK > 0);
                return ((a.X - X) / (double)vX > 0) == (thisK > 0);
            }
        }

        public enum Direction
        {
            Right,
            Down,
            Left,
            Up
        }

        public static void PartTwo()
        {
            string input = InputHelper.GetInputFromFile("10");
            List<string> lines = input.Split(Environment.NewLine).ToList();
            List<Asteroid> asteroids = new List<Asteroid>();

            for (int x = 0; x < lines[0].Length; x++)
            {
                for (int y = 0; y < lines.Count; y++)
                {
                    if (lines[y][x] == '#')
                        asteroids.Add(new Asteroid(x, y));
                }
            }

            Asteroid baseAsteroid = asteroids.First(a => a.X == 30 && a.Y == 34);
            asteroids.Remove(baseAsteroid);
            foreach (Asteroid asteroid in asteroids)
            {
                asteroid.Angle = (Angle(asteroid, baseAsteroid) - Math.PI/2 + (Math.PI * 2)) % (Math.PI * 2);
                asteroid.Distance = Distance(asteroid, baseAsteroid);
            }
            var targetAngles = asteroids.GroupBy(a => a.Angle).ToDictionary(t => t.Key, t => t.Select(a => a).ToList());
            int d = 0;
            int g = 0;
            while (d < 200)
            {
                Asteroid destroyed = targetAngles.ElementAt(g).Value.First();
                targetAngles.ElementAt(g).Value.Remove(destroyed);
                if (targetAngles.ElementAt(g).Value.Count == 0)
                    targetAngles.Remove(targetAngles.ElementAt(g).Key);
                d++;
                if (d == 200)
                    Console.WriteLine($"200th destroyed : {destroyed.X} {destroyed.Y}");
            }
        }

        private static double Distance(Asteroid asteroid, Asteroid baseAsteroid)
        {
            double x = asteroid.X - baseAsteroid.X;
            double y = asteroid.Y - baseAsteroid.Y;
            return Math.Sqrt(x*x + y*y);
        }

        private static double Angle(Asteroid baseAsteroid, Asteroid asteroid)
        {
            return Math.Atan2(asteroid.Y - baseAsteroid.Y, asteroid.X - baseAsteroid.X);
        }
    }
}
