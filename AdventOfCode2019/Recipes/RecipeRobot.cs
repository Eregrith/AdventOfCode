using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Recipes
{
    public class RecipeRobot
    {
        private List<Recipe> recipes;

        public ElementsBin UsedElements { get; } = new ElementsBin();
        public ElementsBin AvailableElements { get; } = new ElementsBin();

        public RecipeRobot(List<Recipe> recipes)
        {
            this.recipes = recipes;
        }

        public void Make(long amount, string what)
        {
            Recipe directRecipe = recipes.FirstOrDefault(r => r.Product.Id == what);
            if (directRecipe == null)
            {
                AvailableElements.Add(amount, what);
                UsedElements.Add(amount, what);
                return;
            }
            if (AvailableElements.Has(what))
            {
                long leftoverUsed = Math.Min(AvailableElements.Count(e => e.Id == what), amount);
                amount -= leftoverUsed;
            }
            if (amount > 0)
            {
                long times = (long)Math.Ceiling((double)amount / (double)directRecipe.Product.Amount);
                RunRecipe(times, directRecipe);
                UsedElements.Add(directRecipe.Product.Amount * times, what);
                AvailableElements.Add(directRecipe.Product.Amount * times, what);
            }
        }

        private void RunRecipe(long times, Recipe directRecipe)
        {
            foreach (Element reagent in directRecipe.Reagents)
            {
                Make(reagent.Amount * times, reagent.Id);
                AvailableElements.RemoveUpTo(reagent.Amount * times, reagent.Id);
            }
        }

        public long GetUsed(string what)
        {
            return UsedElements.Count(e => e.Id == what);
        }
    }
}
