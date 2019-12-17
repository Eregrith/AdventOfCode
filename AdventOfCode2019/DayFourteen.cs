using AdventOfCode2019.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2019
{
    public static class DayFourteen
    {
        public static void PartOne()
        {
            string input = InputHelper.GetInputFromFile("14");
            string[] lines = input.Split(Environment.NewLine);
            List<Recipe> recipes = lines.Select(l => new Recipe(l)).ToList();
            Console.WriteLine("Recipes stored.");
            Console.WriteLine("Recipe for FUEL is : " + recipes.First(r => r.Product.Id == "FUEL"));

            RecipeRobot bot = new RecipeRobot(recipes);
            bot.Make(1, "FUEL");
            Console.WriteLine("Used : " + bot.UsedElements.Count(e => e.Id == "ORE") + " ORE");
        }

        public static void PartTwo()
        {
            string input = InputHelper.GetInputFromFile("14");
            string[] lines = input.Split(Environment.NewLine);
            List<Recipe> recipes = lines.Select(l => new Recipe(l)).ToList();
            Console.WriteLine("Recipes stored.");
            Console.WriteLine("Recipe for FUEL is : " + recipes.First(r => r.Product.Id == "FUEL"));

            RecipeRobot bot = new RecipeRobot(recipes);
            bot.Limits.Add(1000000000000, "ORE");

            while (!bot.LimitReached)
            {
                bot.Make(1, "FUEL");
                bot.AvailableElements.RemoveUpTo(1, "FUEL");
            }
            Console.WriteLine("Produced " + bot.GetUsed("FUEL") + " FUEL using " + bot.GetUsed("ORE") + " ORE");
        }
    }


}
