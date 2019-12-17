using AdventOfCode2019.Recipes;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Tests
{
    [TestFixture]
    class RecipeRobotTests
    {
        [Test]
        public void Make_Should_Track_How_Many_Of_Given_Element_Is_Required_To_Make_Given_Product_Based_On_Recipes()
        {
            List<Recipe> recipes = new List<Recipe>
            {
                new Recipe("1 ORE => 1 FUEL")
            };
            RecipeRobot botTested = new RecipeRobot(recipes);

            botTested.Make(1, "FUEL");

            botTested.GetUsed("ORE").Should().Be(1);
        }

        [Test]
        public void Make_Should_Cascade_Recipes_Down_To_Bottom()
        {
            List<Recipe> recipes = new List<Recipe>
            {
                new Recipe("1 ORE => 1 KEBAB"),
                new Recipe("1 KEBAB => 1 FUEL"),
            };
            RecipeRobot botTested = new RecipeRobot(recipes);

            botTested.Make(1, "FUEL");

            botTested.GetUsed("ORE").Should().Be(1);
        }

        [Test]
        public void Make_Should_Handle_Reagent_Quantities()
        {
            List<Recipe> recipes = new List<Recipe>
            {
                new Recipe("1 ORE => 1 KEBAB"),
                new Recipe("1 ORE => 1 SHISH"),
                new Recipe("2 KEBAB, 1 SHISH => 1 FUEL"),
            };
            RecipeRobot botTested = new RecipeRobot(recipes);

            botTested.Make(1, "FUEL");

            botTested.GetUsed("ORE").Should().Be(3);
        }

        [Test]
        public void Make_Should_Handle_Product_Quantities()
        {
            List<Recipe> recipes = new List<Recipe>
            {
                new Recipe("1 ORE => 2 KEBAB"),
                new Recipe("1 ORE => 1 SHISH"),
                new Recipe("2 KEBAB, 1 SHISH => 1 FUEL"),
            };
            RecipeRobot botTested = new RecipeRobot(recipes);

            botTested.Make(1, "FUEL");

            botTested.GetUsed("ORE").Should().Be(2);
        }

        [Test]
        public void Make_Should_Handle_Leftovers()
        {
            List<Recipe> recipes = new List<Recipe>
            {
                new Recipe("1 ORE => 2 KEBAB"),
                new Recipe("1 ORE, 1 KEBAB => 1 SHISH"),
                new Recipe("1 KEBAB, 1 SHISH => 1 FUEL"),
            };
            RecipeRobot botTested = new RecipeRobot(recipes);

            botTested.Make(1, "FUEL");

            botTested.GetUsed("ORE").Should().Be(2);
        }

        [Test]
        public void Make_Should_Handle_Complex_Recipes()
        {
            List<Recipe> recipes = new List<Recipe>
            {
                new Recipe("9 ORE => 2 A"),
                new Recipe("8 ORE => 3 B"),
                new Recipe("7 ORE => 5 C"),
                new Recipe("3 A, 4 B => 1 AB"),
                new Recipe("5 B, 7 C => 1 BC"),
                new Recipe("4 C, 1 A => 1 CA"),
                new Recipe("2 AB, 3 BC, 4 CA => 1 FUEL")
            };
            RecipeRobot botTested = new RecipeRobot(recipes);

            botTested.Make(1, "FUEL");

            botTested.GetUsed("ORE").Should().Be(165);
        }

        [Test]
        public void Make_Should_Allow_For_Limiting_Generation_Of_Ore()
        {
            long limit = 330;
            List<Recipe> recipes = new List<Recipe>
            {
                new Recipe("9 ORE => 2 A"),
                new Recipe("8 ORE => 3 B"),
                new Recipe("7 ORE => 5 C"),
                new Recipe("3 A, 4 B => 1 AB"),
                new Recipe("5 B, 7 C => 1 BC"),
                new Recipe("4 C, 1 A => 1 CA"),
                new Recipe("2 AB, 3 BC, 4 CA => 1 FUEL")
            };
            RecipeRobot botTested = new RecipeRobot(recipes);
            botTested.AddLimit(limit, "ORE");

            while (!botTested.LimitReached)
            {
                botTested.Make(1, "FUEL");
                botTested.AvailableElements.RemoveUpTo(1, "FUEL");
            }
            botTested.GetUsed("ORE").Should().Be(323);
            botTested.GetUsed("FUEL").Should().Be(2);
        }
    }
}
