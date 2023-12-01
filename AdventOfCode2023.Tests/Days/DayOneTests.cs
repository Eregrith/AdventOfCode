using AdventOfCode2023.Days;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests.Days
{
    internal class DayOneTests
    {
        [Test]
        public void GroupDigits_Should_Return_Number_With_First_And_Last_Digits_When_Input_Is_Parseable()
        {
            string input = "12";
            int expectedResult = 12;

            int result = DayOne.GroupDigits(input);

            result.Should().Be(expectedResult);
        }

        [Test]
        public void GroupDigits_Should_Return_Number_With_First_And_Last_Digits_When_Input_Has_Letters_In_The_Middle()
        {
            string input = "1s2";
            int expectedResult = 12;

            int result = DayOne.GroupDigits(input);

            result.Should().Be(expectedResult);
        }

        [Test]
        public void GroupDigits_Should_Return_Number_With_First_And_Last_Digits_When_Input_Has_Letters_In_Front()
        {
            string input = "s12";
            int expectedResult = 12;

            int result = DayOne.GroupDigits(input);

            result.Should().Be(expectedResult);
        }

        [Test]
        public void GroupDigits_Should_Return_Number_With_First_And_Last_Digits_When_Input_Has_Letters_At_The_End()
        {
            string input = "12s";
            int expectedResult = 12;

            int result = DayOne.GroupDigits(input);

            result.Should().Be(expectedResult);
        }

        [Test]
        public void GroupDigits_Should_Return_Number_With_First_And_Last_Digits_When_Input_Has_Letters_AnyWhere()
        {
            string input = "t1x2s";
            int expectedResult = 12;

            int result = DayOne.GroupDigits(input);

            result.Should().Be(expectedResult);
        }

        [Test]
        public void GroupDigits_Should_Return_Number_With_First_And_Last_Digits_When_Input_Has_Many_Digits()
        {
            string input = "t1f23546fdsf26g44x2s";
            int expectedResult = 12;

            int result = DayOne.GroupDigits(input);

            result.Should().Be(expectedResult);
        }

        [TestCase("zero", "0")]
        [TestCase("one", "1")]
        [TestCase("two", "2")]
        [TestCase("three", "3")]
        [TestCase("four", "4")]
        [TestCase("five", "5")]
        [TestCase("six", "6")]
        [TestCase("seven", "7")]
        [TestCase("eight", "8")]
        [TestCase("nine", "9")]
        public void DespellDigits_Should_Transform_Spelled_Digit_When_There_Is_Only_One(string input, string expectedResult)
        {
            string result = DayOne.DespellDigits(input);

            result.Should().Be(expectedResult);
        }

        [TestCase("onetwo", "12")]
        [TestCase("fourfivesix", "456")]
        public void DespellDigits_Should_Transform_Spelled_Digits_When_There_Are_Many(string input, string expectedResult)
        {
            string result = DayOne.DespellDigits(input);

            result.Should().Be(expectedResult);
        }

        [TestCase("oneight", "18")]
        public void DespellDigits_Should_Transform_Spelled_Digits_When_They_Are_Mixed(string input, string expectedResult)
        {
            string result = DayOne.DespellDigits(input);

            result.Should().Be(expectedResult);
        }

        [TestCase("abconedeftwo", "abc1def2")]
        [TestCase("abconeightdef", "abc18def")]
        public void DespellDigits_Should_Keep_The_Rest_Of_The_String(string input, string expectedResult)
        {
            string result = DayOne.DespellDigits(input);

            result.Should().Be(expectedResult);
        }
    }
}
