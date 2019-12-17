using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2019.Recipes
{
    public class Recipe
    {
        public List<Element> Reagents { get; set; } = new List<Element>();
        public Element Product { get; set; }

        public Recipe(string l)
        {
            Regex r = new Regex(@"(?:(?<reagent>(\d+) ([A-Z]+))(?:, )?)+ => (?<productAmount>\d+) (?<product>[A-Z]+)");
            Match m = r.Match(l);
            if (!m.Success)
                throw new Exception("Could not match regex to line " + l);
            Product = new Element(int.Parse(m.Groups["productAmount"].Value), m.Groups["product"].Value);
            for (int i = 0; i < m.Groups["reagent"].Captures.Count; i++)
            {
                string[] capt = m.Groups["reagent"].Captures[i].Value.Split(" ");
                Reagents.Add(new Element(int.Parse(capt[0]), capt[1]));
            }
        }

        public override string ToString()
        {
            return string.Join(", ", Reagents) + " => " + Product;
        }
    }
}
