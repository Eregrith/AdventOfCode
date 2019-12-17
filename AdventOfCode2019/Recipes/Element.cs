using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Recipes
{
    public class Element
    {
        public long Amount { get; set; }
        public string Id { get; set; }

        public Element(long amount, string id)
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
