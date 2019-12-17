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
        public ElementsBin Limits { get; } = new ElementsBin();
        public bool LimitReached { get; private set; } = false;

        public RecipeRobot(List<Recipe> recipes)
        {
            this.recipes = recipes;
        }

        public void Make(long amount, string what)
        {
            Recipe directRecipe = recipes.FirstOrDefault(r => r.Product.Id == what);
            if (directRecipe == null)
            {
                if (!Limits.Any() || UsedElements.Count(e => e.Id == what) + amount <= Limits.Count(e => e.Id == what))
                {
                    AvailableElements.Add(amount, what);
                    UsedElements.Add(amount, what);
                    return;
                }
                else
                {
                    LimitReached = true;
                    return;
                }
            }
            if (AvailableElements.Has(what))
            {
                long leftoverUsed = Math.Min(AvailableElements.Count(e => e.Id == what), amount);
                amount -= leftoverUsed;
            }
            while (amount > 0)
            {
                RunRecipe(directRecipe);
                if (LimitReached) return;
                amount -= directRecipe.Product.Amount;
                UsedElements.Add(directRecipe.Product.Amount, what);
                AvailableElements.Add(directRecipe.Product.Amount, what);
            }
        }

        private void RunRecipe(Recipe directRecipe)
        {
            foreach (Element reagent in directRecipe.Reagents)
            {
                Make(reagent.Amount, reagent.Id);
                if (LimitReached)
                    return;
                AvailableElements.RemoveUpTo(reagent.Amount, reagent.Id);
            }
        }

        public long GetUsed(string what)
        {
            return UsedElements.Count(e => e.Id == what);
        }

        public void AddLimit(long limit, string what)
        {
            Limits.Add(limit, what);
        }
    }
}
