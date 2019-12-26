using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Stack
{
    public class StackShuffler
    {
        private List<int> Stack { get; set; }

        public void Start(int v)
        {
            Stack = Enumerable.Range(0, v).ToList();
        }

        public List<int> GetStack()
        {
            return Stack;
        }

        public void DealIntoNewStack()
        {
            Stack.Reverse();
        }

        public void CutNCards(int v)
        {
            if (v < 0)
                v = Stack.Count + v;
            var cut = Stack.Take(v);
            Stack = Stack.Skip(v).ToList();
            Stack.AddRange(cut);
        }

        public void DealWithIncrement(int increment)
        {
            int ns_i = 0;
            int i = 0;
            int[] ns = new int[Stack.Count];
            while (i < Stack.Count)
            {
                ns[ns_i] = Stack[i];
                i++;
                ns_i = (ns_i + increment) % Stack.Count;
            }
            Stack = ns.ToList();
        }
    }
}
