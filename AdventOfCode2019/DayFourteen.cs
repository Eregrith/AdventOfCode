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

            long increment = 1000000;
            long total = increment;
            long previousUsed = 0;
            long used = 0;
            while (increment > 0)
            {
                RecipeRobot bot = new RecipeRobot(recipes);
                bot.Make(total, "FUEL");
                used = bot.GetUsed("ORE");
                if (used > 1000000000000)
                {
                    total -= increment;
                    increment /= 10;
                    used = previousUsed;
                }
                else
                {
                    total += increment;
                }
                previousUsed = used;
            }

            Console.WriteLine("Produced " + total + " FUEL using " + used + " ORE");
        }
    }


}
