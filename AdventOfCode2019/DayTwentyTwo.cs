using AdventOfCode2019.Stack;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    public static class DayTwentyTwo
    {
        public static void PartOne()
        {
            string input = InputHelper.GetInputFromFile("22");
            string[] lines = input.Split(Environment.NewLine);
            StackShuffler stack = new StackShuffler();
            stack.Start(10007);

            foreach (string line in lines)
            {
                if (line.StartsWith("deal with increment "))
                    stack.DealWithIncrement(int.Parse(line.Split(' ')[3]));
                if (line.StartsWith("cut "))
                    stack.CutNCards(int.Parse(line.Split(' ')[1]));
                if (line == "deal into new stack")
                    stack.DealIntoNewStack();
            }

            Console.WriteLine("Position of card 2019 : " + stack.GetStack().IndexOf(2019));
        }
    }
}
