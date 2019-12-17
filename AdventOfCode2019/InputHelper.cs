using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2019
{
    public static class InputHelper
    {
        public static string GetInputFromFile(string name)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @$"../../../InputFiles/{name}.txt");
            return File.ReadAllText(path);
        }

        public static long[] GetIntcodeFromFile(string name)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @$"../../../InputFiles/{name}.txt");
            string text = File.ReadAllText(path);
            return text.Split(",").Select(i => long.Parse(i)).ToArray();
        }

        /// <summary>
        /// Returns a list of all sublists of given <paramref name="size"/>
        /// The last sublist contains as many elements as possible
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="size">Must be greater than 0</param>
        /// <returns></returns>
        public static List<T[]> Sublists<T>(this List<T> list, int size)
        {
            if (size == 0) throw new ArgumentException("Size must be > 0", nameof(size));
            List<T[]> sublists = new List<T[]>();
            for (int i = 0; i < list.Count;)
            {
                T[] sublist = new T[size];
                for (int s = 0; s < size; s++)
                {
                    sublist[s] = list[i];
                    i++;
                }
                sublists.Add(sublist);
            }
            return sublists;
        }
    }
}
