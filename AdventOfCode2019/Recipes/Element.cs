using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Recipes
{
    public class Element
    {
        public int Amount { get; set; }
        public string Id { get; set; }

        public Element(int amount, string id)
        {
            Amount = amount;
            Id = id;
        }

        public override string ToString()
        {
            return Amount + " " + Id;
        }
    }
}
