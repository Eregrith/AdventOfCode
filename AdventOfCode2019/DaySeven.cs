using AdventOfCode2019.Intcode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using static AdventOfCode2019.Program;

namespace AdventOfCode2019
{
    public static class DaySeven
    {
        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                yield break;
            }

            var list = sequence.ToList();

            if (!list.Any())
            {
                yield return Enumerable.Empty<T>();
            }
            else
            {
                var startingElementIndex = 0;

                foreach (var startingElement in list)
                {
                    var index = startingElementIndex;
                    var remainingItems = list.Where((e, i) => i != index);

                    foreach (var permutationOfRemainder in remainingItems.Permute())
                    {
                        yield return startingElement.Concat(permutationOfRemainder);
                    }

                    startingElementIndex++;
                }
            }
        }

        private static IEnumerable<T> Concat<T>(this T firstElement, IEnumerable<T> secondSequence)
        {
            yield return firstElement;
            if (secondSequence == null)
            {
                yield break;
            }

            foreach (var item in secondSequence)
            {
                yield return item;
            }
        }

        public static void PartOne()
        {
            long[] data = InputHelper.GetIntcodeFromFile("7");

            List<int> phases = new List<int> { 0, 1, 2, 3, 4 };

            var allPhases = Permute(phases);
            Dictionary<long, List<int>> outputPerPhase = new Dictionary<long, List<int>>();
            foreach (IEnumerable<int> p in allPhases)
            {
                var phase = p.ToList();
                IntcodeComputer a = new IntcodeComputer(data);
                a.InputQueue.Enqueue(phase[0]);
                a.InputQueue.Enqueue(0);
                a.Run();
                IntcodeComputer b = new IntcodeComputer(data);
                b.InputQueue.Enqueue(phase[1]);
                b.InputQueue.Enqueue(a.OutputQueue.Dequeue());
                b.Run();
                IntcodeComputer c = new IntcodeComputer(data);
                c.InputQueue.Enqueue(phase[2]);
                c.InputQueue.Enqueue(b.OutputQueue.Dequeue());
                c.Run();
                IntcodeComputer d = new IntcodeComputer(data);
                d.InputQueue.Enqueue(phase[3]);
                d.InputQueue.Enqueue(c.OutputQueue.Dequeue());
                d.Run();
                IntcodeComputer e = new IntcodeComputer(data);
                e.InputQueue.Enqueue(phase[4]);
                e.InputQueue.Enqueue(d.OutputQueue.Dequeue());
                e.Run();
                long output = e.OutputQueue.Dequeue();
                outputPerPhase.Add(output, phase);
                Console.WriteLine($"Phase {String.Join(',', phase)} produces output {output}");
            }
            var maxPhase = outputPerPhase.First(o => o.Key == outputPerPhase.Max(k => k.Key));
            Console.WriteLine($"Phase with biggest output {String.Join(',', maxPhase.Value)} produces output {maxPhase.Key}");
        }

        public static void PartTwo()
        {
            long[] data = InputHelper.GetIntcodeFromFile("7");

            List<int> phases = new List<int> { 5, 6, 7, 8, 9 };

            var allPhases = Permute(phases);
            Dictionary<long, List<int>> outputPerPhase = new Dictionary<long, List<int>>();
            foreach (IEnumerable<int> p in allPhases)
            {
                var phase = p.ToList();
                IntcodeComputer a = new IntcodeComputer(data.ToArray(), IntcodeMode.Quiet | IntcodeMode.Blocking, "A");
                IntcodeComputer b = new IntcodeComputer(data.ToArray(), IntcodeMode.Quiet | IntcodeMode.Blocking, "B");
                IntcodeComputer c = new IntcodeComputer(data.ToArray(), IntcodeMode.Quiet | IntcodeMode.Blocking, "C");
                IntcodeComputer d = new IntcodeComputer(data.ToArray(), IntcodeMode.Quiet | IntcodeMode.Blocking, "D");
                IntcodeComputer e = new IntcodeComputer(data.ToArray(), IntcodeMode.Quiet | IntcodeMode.Blocking, "E");
                a.InputQueue = e.OutputQueue;
                a.InputQueue.Enqueue(phase[0]);
                a.InputQueue.Enqueue(0);
                b.InputQueue = a.OutputQueue;
                b.InputQueue.Enqueue(phase[1]);
                c.InputQueue = b.OutputQueue;
                c.InputQueue.Enqueue(phase[2]);
                d.InputQueue = c.OutputQueue;
                d.InputQueue.Enqueue(phase[3]);
                e.InputQueue = d.OutputQueue;
                e.InputQueue.Enqueue(phase[4]);
                Thread at = new Thread(() => a.Run());
                Thread bt = new Thread(() => b.Run());
                Thread ct = new Thread(() => c.Run());
                Thread dt = new Thread(() => d.Run());
                Thread et = new Thread(() => e.Run());
                at.Start();
                bt.Start();
                ct.Start();
                dt.Start();
                et.Start();
                at.Join();
                bt.Join();
                ct.Join();
                dt.Join();
                et.Join();
                long output = e.OutputQueue.Dequeue();
                outputPerPhase.Add(output, phase);
                Console.WriteLine($"Phase {String.Join(',', phase)} produces output {output}");
            }
            var maxPhase = outputPerPhase.First(o => o.Key == outputPerPhase.Max(k => k.Key));
            Console.WriteLine($"Phase with biggest output {String.Join(',', maxPhase.Value)} produces output {maxPhase.Key}");
        }
    }
}
