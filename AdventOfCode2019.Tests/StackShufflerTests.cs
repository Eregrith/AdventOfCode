using AdventOfCode2019.Stack;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Tests
{
    [TestFixture]
    class StackShufflerTests
    {
        [Test]
        public void Start_Should_Setup_Stack_Of_Given_Size_In_Order()
        {
            StackShuffler shufflerTested = new StackShuffler();

            shufflerTested.Start(10);

            var stack = shufflerTested.GetStack();
            stack.Count.Should().Be(10);
            stack.Should().ContainInOrder(Enumerable.Range(0, 10));
        }

        [Test]
        public void Deal_Into_New_Stack_Should_Reverse_The_Stack()
        {
            StackShuffler shufflerTested = new StackShuffler();
            shufflerTested.Start(10);

            shufflerTested.DealIntoNewStack();

            var stack = shufflerTested.GetStack();
            stack.Count.Should().Be(10);
            stack.Should().ContainInOrder(Enumerable.Range(0, 10).Reverse());
        }

        [Test]
        public void CutNCards_Should_Put_N_Cards_At_The_End()
        {
            StackShuffler shufflerTested = new StackShuffler();
            shufflerTested.Start(10);

            shufflerTested.CutNCards(3);

            var stack = shufflerTested.GetStack();
            stack.Count.Should().Be(10);
            stack.Should().ContainInOrder(new List<int> { 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 });
        }

        [Test]
        public void CutNCards_Negative_Should_Put_Size_Minus_N_Cards_At_The_End()
        {
            StackShuffler shufflerTested = new StackShuffler();
            shufflerTested.Start(10);

            shufflerTested.CutNCards(-4);

            var stack = shufflerTested.GetStack();
            stack.Count.Should().Be(10);
            stack.Should().ContainInOrder(new List<int> { 6, 7, 8, 9, 0, 1, 2, 3, 4, 5 });
        }

        [Test]
        public void DealWithIncrement_Should_Distibute_Cards_Every_N_Steps()
        {
            StackShuffler shufflerTested = new StackShuffler();
            shufflerTested.Start(10);

            shufflerTested.DealWithIncrement(9);

            var stack = shufflerTested.GetStack();
            stack.Count.Should().Be(10);
            stack.Should().ContainInOrder(new List<int> { 0, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
        }

        [Test]
        public void Chaining_Calls_Should_Yield_Correct_Result()
        {
            StackShuffler shufflerTested = new StackShuffler();
            shufflerTested.Start(10);

            shufflerTested.DealIntoNewStack();
            shufflerTested.CutNCards(-2);
            shufflerTested.DealWithIncrement(7);
            shufflerTested.CutNCards(8);
            shufflerTested.CutNCards(-4);
            shufflerTested.DealWithIncrement(7);
            shufflerTested.CutNCards(3);
            shufflerTested.DealWithIncrement(9);
            shufflerTested.DealWithIncrement(3);
            shufflerTested.CutNCards(-1);

            var stack = shufflerTested.GetStack();
            stack.Count.Should().Be(10);
            stack.Should().ContainInOrder(new List<int> { 9, 2, 5, 8, 1, 4, 7, 0, 3, 6 });
        }
    }
}
