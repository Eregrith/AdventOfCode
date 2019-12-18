using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Recipes
{
    public class ElementsBin
    {
        List<Element> _usedElements = new List<Element>();

        public void Add(long amount, string id)
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

        public long Count(Func<Element, bool> p) => _usedElements.FirstOrDefault(p)?.Amount??0;

        public long RemoveUpTo(long amountRequired, string id)
        {
            Element existingUsed = _usedElements.FirstOrDefault(e => e.Id == id);
            if (existingUsed == null) return 0;

            if (existingUsed.Amount >= amountRequired)
            {
                existingUsed.Amount -= amountRequired;
                return amountRequired;
            }
            long removed = existingUsed.Amount;
            existingUsed.Amount = 0;
            return removed;
        }

        public bool Any()
        {
            return _usedElements.Any();
        }

        public bool Has(string id) => _usedElements.Any(e => e.Id == id && e.Amount > 0);

        public override string ToString()
        {
            return String.Join(", ", _usedElements);
        }

        public void MultiplyBy(int v)
        {
            _usedElements.ForEach(e => e.Amount *= v);
        }
    }
}