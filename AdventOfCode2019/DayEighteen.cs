using AdventOfCode2019.Mazes;
using AdventOfCode2019.Mazes.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public static class DayEighteen
    {
        public static void PartOne()
        {
            const string file = "18";
            string input = InputHelper.GetInputFromFile(file);
            Maze m = new Maze(input.Split(Environment.NewLine).Select(c => c.ToCharArray()).ToArray(), new DayEighteenMazeFactory());

            Console.WriteLine(m.GetDisplay());

            (int steps, string keysOrder) = GetFastestPathToAllKeys(m, file);
            Console.WriteLine("Shortest paths to all keys in order " + keysOrder + " is " + steps + " steps long");
        }

        private static (int, string) GetFastestPathToAllKeys(Maze m, string file)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<MazePath> paths = MakeAllPathsList(m);
            sw.Stop();
            Console.WriteLine($"All {paths.Count} paths from entrance/keys to keys have been devised in {sw.ElapsedMilliseconds} ms");
            File.WriteAllText(InputHelper.GetOutputPathForFile(file), String.Join(Environment.NewLine, paths));
            Console.WriteLine($"Paths saved to {file}.txt");

            sw.Reset();
            sw.Start();
            List<(int steps, string keyOrder)> orders = GetPossiblePaths(paths, m.Cells.OfType<MazeKey>().Count());
            sw.Stop();
            Console.WriteLine($"All {orders.Count} key orders have been mapped in {sw.ElapsedMilliseconds} ms");
            return orders.OrderBy(o => o.steps).First();
        }

        private static List<(int steps, string keyOrder)> GetPossiblePaths(List<MazePath> paths, int keys)
        {
            Dictionary<(char pos, string keys), int> visitedStates = new Dictionary<(char pos, string keys), int>();
            Queue<(int steps, string keyOrder)> pathsToCheck = new Queue<(int steps, string keyOrder)>();
            pathsToCheck.Enqueue((0, ""));
            int currentMinimum = int.MaxValue;

            while (!pathsToCheck.All(p => p.keyOrder.Length == keys))
            {
                var path = pathsToCheck.Dequeue();
                char position = path.keyOrder.Length > 0 ? path.keyOrder.Last() : '@';
                string keysInOrder = String.Join("", path.keyOrder.OrderBy(k => k));
                if (visitedStates.TryGetValue((position, keysInOrder), out var steps))
                {
                    if (steps <= path.steps)
                    {
                        continue;
                    }
                    visitedStates[(position, keysInOrder)] = path.steps;
                }
                else
                {
                    visitedStates.Add((position, keysInOrder), path.steps);
                }
                if (path.keyOrder.Length == keys)
                {
                    currentMinimum = Math.Min(currentMinimum, path.steps);
                    continue;
                }
                //Console.WriteLine($"Considering next option : from {from} after {stepsSoFar} steps having keys [{keysSoFar}]. Available paths are:");
                List<MazePath> availablePaths = paths.Where(p =>  p.CanReachWith(path.keyOrder) && p.From == position && !path.keyOrder.Contains(p.To)).ToList();
                //Console.WriteLine(String.Join(Environment.NewLine, availablePaths));
                foreach (MazePath availablePath in availablePaths)
                {
                    pathsToCheck.Enqueue((path.steps + availablePath.Steps, path.keyOrder + availablePath.To));
                }
                //Console.WriteLine("After adding these, queue looks like this:");
                //Console.WriteLine(String.Join(Environment.NewLine, pathsToCheck.ToList().Select(p => p.steps + " [" + p.keyOrder + "]")));
            }
            return pathsToCheck.ToList();
        }

        private static List<MazePath> MakeAllPathsList(Maze m)
        {
            List<MazeCell> pointsOfInterest = m.Cells.Where(c => c is MazeKey || c is MazeEntrance).ToList();
            List<MazePath> paths = new List<MazePath>();
            foreach (MazeCell poi in pointsOfInterest)
            {
                m.ResetCells();
                m.SetDistancesFrom(poi);
                var allKeys = m.Cells.OfType<MazeKey>().Where(k => k.DistanceFromStart > 0).ToList();
                if (poi is MazeKey key)
                    allKeys.Remove(key);
                foreach (var k in allKeys)
                {
                    paths.Add(new MazePath(poi, k, k.DistanceFromStart, k.KeysRequired));
                }
            }
            return paths;
        }
    }
}
