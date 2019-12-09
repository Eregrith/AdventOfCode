using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AdventOfCode2019.Program;

namespace AdventOfCode2019
{
    public static class DaySix
    {
        public static void PartOne()
        {
            string input = InputHelper.GetInputFromFile("6");

            IEnumerable<(string Orbitee, string Orbiter)> orbits = input.Split("\r\n").Select(line => { var parts = line.Split(")"); return (parts[0], parts[1]); });

            OrbitTree tree = new OrbitTree();
            Queue<Orbitable> orbitablesToProcess = new Queue<Orbitable>();
            orbitablesToProcess.Enqueue(tree.CenterOfMass);
            while (orbitablesToProcess.Count() > 0)
            {
                Orbitable currentOrbitable = orbitablesToProcess.Dequeue();
                var orbiters = orbits.Where(o => o.Orbitee == currentOrbitable.Code).Select(o => o.Orbiter);
                foreach (string orbiterCode in orbiters)
                {
                    Orbitable orbitable = new Orbitable(orbiterCode, currentOrbitable);
                    currentOrbitable.Orbiters.Add(orbitable);
                    orbitablesToProcess.Enqueue(orbitable);
                }
            }

            //Display(tree.CenterOfMass);
            Console.WriteLine($"Weight : {Weight(tree.CenterOfMass)}");
        }

        public static void PartTwo()
        {
            string input = InputHelper.GetInputFromFile("6");

            IEnumerable<(string Orbitee, string Orbiter)> orbits = input.Split("\r\n").Select(line => { var parts = line.Split(")"); return (parts[0], parts[1]); });

            OrbitTree tree = new OrbitTree();
            Queue<Orbitable> orbitablesToProcess = new Queue<Orbitable>();
            orbitablesToProcess.Enqueue(tree.CenterOfMass);
            Orbitable me = null, santa = null;
            while (orbitablesToProcess.Count() > 0)
            {
                Orbitable currentOrbitable = orbitablesToProcess.Dequeue();
                var orbiters = orbits.Where(o => o.Orbitee == currentOrbitable.Code).Select(o => o.Orbiter);
                foreach (string orbiterCode in orbiters)
                {
                    Orbitable orbitable = new Orbitable(orbiterCode, currentOrbitable);
                    if (orbiterCode == "YOU")
                        me = orbitable;
                    if (orbiterCode == "SAN")
                        santa = orbitable;
                    currentOrbitable.Orbiters.Add(orbitable);
                    orbitablesToProcess.Enqueue(orbitable);
                }
            }

            //Display(tree.CenterOfMass);
            int distanceBetween = GetDistanceBetween(tree, me, santa);
            Console.WriteLine($"Distance: {distanceBetween}");
        }

        private static int GetDistanceBetween(OrbitTree tree, Orbitable me, Orbitable santa)
        {
            int distanceUp = 0;
            Orbitable link = me.Orbitee;
            IEnumerable<Orbitable> reachables = Flatten(link);
            while (!reachables.Contains(santa))
            {
                link = link.Orbitee;
                reachables = Flatten(link);
                distanceUp++;
            }
            return distanceUp + DistanceDownTo(link, santa);
        }

        private static int DistanceDownTo(Orbitable link, Orbitable santa, int depth = 0)
        {
            if (link.Orbiters.Contains(santa)) return depth;
            Orbitable nextLink = link.Orbiters.First(o => Flatten(o).Contains(santa));
            return DistanceDownTo(nextLink, santa, depth + 1);
        }

        private static IEnumerable<Orbitable> Flatten(Orbitable e)
        {
            yield return e;
            foreach (Orbitable orbitable in e.Orbiters)
                foreach (Orbitable flat in Flatten(orbitable))
                    yield return flat;
        }

        private static int Weight(Orbitable centerOfMass, int depth = 0)
        {
            return centerOfMass.Orbiters.Aggregate(depth, (acc, o) => acc + Weight(o, depth + 1));
        }

        private static void Display(Orbitable centerOfMass, int depth = 0)
        {
            Console.WriteLine(new String('-', depth) + centerOfMass.Code);
            centerOfMass.Orbiters.ForEach(o => Display(o, depth + 1));
        }
    }

    public class OrbitTree
    {
        public Orbitable CenterOfMass { get; set; } = new Orbitable("COM", null);
    }

    public class Orbitable
    {
        public Orbitable Orbitee { get; set; }
        public string Code { get; set; }
        public List<Orbitable> Orbiters { get; set; } = new List<Orbitable>();
        public Orbitable(string code, Orbitable orbitee)
        {
            Code = code;
            Orbitee = orbitee;
        }
    }
}
