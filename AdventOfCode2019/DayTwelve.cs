using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2019
{
    public static class DayTwelve
    {
        public static void PartOne()
        {
            string input = InputHelper.GetInputFromFile("12");
            List<Moon> moons = GetMoons(input);

            for (int i = 0; i < 1000; i++)
            {
                TimeStep(moons);
            }
            Console.WriteLine("Total energy in the system after 1000 time steps :" + moons.Sum(m => m.Energy));
        }

        public static void PartTwo()
        {
            string input = InputHelper.GetInputFromFile("12");
            List<Moon> moons = GetMoons(input);

            int step = 0;
            int zeroX = 0;
            int zeroY = 0;
            int zeroZ = 0;
            while (zeroX == 0 || zeroY == 0 || zeroZ == 0)
            {
                TimeStep(moons);
                step++;
                if (zeroX == 0 && moons.All(m => m.Velocity.X == 0))
                    zeroX = step;
                if (zeroY == 0 && moons.All(m => m.Velocity.Y == 0))
                    zeroY = step;
                if (zeroZ == 0 && moons.All(m => m.Velocity.Z == 0))
                    zeroZ = step;
            }
            Console.WriteLine($"Zero Velocity after {zeroX}, {zeroY} and {zeroZ} steps for X Y and Z");
            long lcm = LCM(zeroX, LCM(zeroY, zeroZ));
            Console.WriteLine($"LCM is {lcm}, twice that is {lcm*2}");
        }
        private static long GCF(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static long LCM(long a, long b)
        {
            return (a / GCF(a, b)) * b;
        }

        private static bool CheckEquality(List<Moon> moons, int step)
        {
            bool X = true;
            bool Y = true;
            bool Z = true;
            for (int i = 0; i < moons.Count; i++)
            {
                if (moons[i].Velocity.Y != 0)
                {
                    Y = false;
                    break;
                }
            }
            for (int i = 0; i < moons.Count; i++)
            {
                if (moons[i].Velocity.Z != 0)
                {
                    Z = false; break;
                }
            }
            if (X == true)
                Console.WriteLine($"Zero Velocity X after {step} steps");
            if (Y == true)
                Console.WriteLine($"Zero Velocity Y after {step} steps");
            if (Z == true)
                Console.WriteLine($"Zero Velocity Z after {step} steps");
            return X && Y && Z;
        }

        private static void TimeStep(List<Moon> moons)
        {
            foreach (Moon moon in moons)
            {
                moon.Velocity.X += moons.Count(m => m.Position.X > moon.Position.X) - moons.Count(m => m.Position.X < moon.Position.X);
                moon.Velocity.Y += moons.Count(m => m.Position.Y > moon.Position.Y) - moons.Count(m => m.Position.Y < moon.Position.Y);
                moon.Velocity.Z += moons.Count(m => m.Position.Z > moon.Position.Z) - moons.Count(m => m.Position.Z < moon.Position.Z);
            }
            foreach (Moon moon in moons)
            {
                moon.Position.Add(moon.Velocity);
            }
        }

        private static List<Moon> GetMoons(string input)
        {
            List<Moon> moons = new List<Moon>();
            string[] lines = input.Split(Environment.NewLine);
            //<x=-5, y=-4, z=-4>
            Regex regex = new Regex(@"<x=(?<x>-?\d+), y=(?<y>-?\d+), z=(?<z>-?\d+)");
            foreach (string line in lines)
            {
                Match m = regex.Match(line);
                if (m.Success)
                {
                    Moon moon = new Moon(int.Parse(m.Groups["x"].Value),
                                         int.Parse(m.Groups["y"].Value),
                                         int.Parse(m.Groups["z"].Value));
                    moons.Add(moon);
                }
            }
            return moons;
        }
    }

    public class Moon
    {
        public Point3D Position { get; set; }
        public Point3D Velocity { get; set; }
        public int PotentialEnergy => EnergyOf(Position);

        public int KineticEnergy => EnergyOf(Velocity);
        public int Energy => PotentialEnergy * KineticEnergy;

        public Moon(int x, int y, int z)
        {
            Position = new Point3D(x, y, z);
            Velocity = new Point3D(0, 0, 0);
        }

        private int EnergyOf(Point3D item)
        {
            return Math.Abs(item.X) + Math.Abs(item.Y) + Math.Abs(item.Z);
        }

        public override string ToString()
        {
            return $"pos=<x={Position.X}, y={Position.Y}, z={Position.Z}>, vel=<x={Velocity.X}, y={Velocity.Y}, z={Velocity.Z}>";
        }
    }

    public class Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public static Point3D Zero = new Point3D(0, 0, 0);

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Add(Point3D velocity)
        {
            X += velocity.X;
            Y += velocity.Y;
            Z += velocity.Z;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point3D)) return false;
            Point3D p = obj as Point3D;
            return X == p.X && Y == p.Y && Z == p.Z;
        }

        public override int GetHashCode()
        {
            return X * Y * Z;
        }
    }
}
