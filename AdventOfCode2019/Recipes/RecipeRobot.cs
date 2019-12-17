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

        public void Make(int amount, string what)
        {
            Recipe directRecipe = recipes.FirstOrDefault(r => r.Product.Id == what);
            if (directRecipe == null) return;
            foreach (Element reagent in directRecipe.Reagents)
            {
                int amountRequired = amount / directRecipe.Product.Amount * reagent.Amount;
                if (AvailableElements.Has(reagent.Id))
                if (amountRequired > 0)
                {
                    Make(amountRequired, reagent.Id);
                    UsedElements.Add(amountRequired, reagent.Id);
                }
            }
        }

        public int GetUsed(string what)
        {
            return UsedElements.Count(e => e.Id == what);
        }
    }
}
