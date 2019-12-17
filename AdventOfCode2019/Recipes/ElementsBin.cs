using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Recipes
{
    public class ElementsBin
    {
        List<Element> _usedElements = new List<Element>();

        internal void Add(int amount, string id)
        {
            Element existingUsed = _usedElements.FirstOrDefault(e => e.Id == id);
            if (existingUsed == null)
            {
                existingUsed = new Element(amount, id);
                _usedElements.Add(existingUsed);
            }
            else
                existingUsed.Amount += amount;
        }

        public int Count(Func<Element, bool> p) => _usedElements.FirstOrDefault(p)?.Amount??0;

        internal int RemoveUpTo(int amountRequired, string id)
        {
            Element existingUsed = _usedElements.FirstOrDefault(e => e.Id == id);
            if (existingUsed == null) return 0;

            if (existingUsed.Amount >= amountRequired)
            {
                existingUsed.Amount -= amountRequired;
                return amountRequired;
            }
            int removed = existingUsed.Amount;
            existingUsed.Amount = 0;
            return removed;
        }

        internal bool Has(string id) => _usedElements.Any(e => e.Id == id);
    }
}