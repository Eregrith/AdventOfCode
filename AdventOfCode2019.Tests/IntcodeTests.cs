using NUnit.Framework;
using FluentAssertions;
using System;
using System.IO;
using Moq;
using System.Threading;

namespace AdventOfCode2019.Tests
{
    [TestFixture]
    class IntcodeTests
    {
        [TestCase(12, 2, 5866714)]
        [TestCase(52, 8, 19690720)]
        public void Intcode_Should_Return_Correct_Value_Based_On_Noun_And_Verb(int noun, int verb, int result)
        {
            int[] data = new[] { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 13, 1, 19, 1, 19, 10, 23, 1, 23, 6, 27, 1, 6, 27, 31, 1, 13, 31, 35, 1, 13, 35, 39, 1, 39, 13, 43, 2, 43, 9, 47, 2, 6, 47, 51, 1, 51, 9, 55, 1, 55, 9, 59, 1, 59, 6, 63, 1, 9, 63, 67, 2, 67, 10, 71, 2, 71, 13, 75, 1, 10, 75, 79, 2, 10, 79, 83, 1, 83, 6, 87, 2, 87, 10, 91, 1, 91, 6, 95, 1, 95, 13, 99, 1, 99, 13, 103, 2, 103, 9, 107, 2, 107, 10, 111, 1, 5, 111, 115, 2, 115, 9, 119, 1, 5, 119, 123, 1, 123, 9, 127, 1, 127, 2, 131, 1, 5, 131, 0, 99, 2, 0, 14, 0 };
            Intcode i = new Intcode(data);

            i.Run(noun, verb).Should().Be(result);
        }

        [Test]
        public void Opcodes_3_and_4_Read_and_Write_To_Console_When_Input_Queue_Is_Empty()
        {
            int[] data = new[] { 3, 0, 4, 0, 99 };
            int input = 1234;
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Mock<TextReader> mockTextReader = new Mock<TextReader>();
            Console.SetOut(mockTextWriter.Object);
            Console.SetIn(mockTextReader.Object);
            mockTextReader.Setup(m => m.ReadLine()).Returns(input.ToString());
            Intcode computerTested = new Intcode(data);

            computerTested.Run();

            mockTextWriter.Verify(m => m.Write("Input: "));
            mockTextWriter.Verify(m => m.WriteLine("Output: " + input));
        }

        [Test]
        public void Opcodes_3_Should_Read_From_Input_Queue_When_It_Is_Not_Empty()
        {
            int[] data = new[] { 3, 0, 4, 0, 99 };
            int input = 1234;
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Console.SetOut(mockTextWriter.Object);
            Intcode computerTested = new Intcode(data);
            computerTested.InputQueue.Enqueue(input);

            computerTested.Run();

            mockTextWriter.Verify(m => m.Write("Input: "), Times.Never);
            mockTextWriter.Verify(m => m.WriteLine("Output: " + input), Times.Once);
        }

        [Test]
        public void Opcodes_3_Should_Wait_For_Input_Queue_When_In_Blocking_Mode()
        {
            int[] data = new[] { 3, 0, 4, 0, 99 };
            int input = 1234;
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Console.SetOut(mockTextWriter.Object);
            Intcode computerTested = new Intcode(data, IntcodeMode.Blocking);

            new Thread(() => computerTested.Run()).Start();

            computerTested.InputQueue.Enqueue(input);
            mockTextWriter.Verify(m => m.Write("Input: "), Times.Never);
            mockTextWriter.Verify(m => m.WriteLine("Output: " + input), Times.Once);
        }

        [Test]
        public void Opcodes_4_Should_Also_Write_To_OutputQueue()
        {
            int[] data = new[] { 3, 0, 4, 0, 99 };
            int input = 1234;
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Console.SetOut(mockTextWriter.Object);
            Intcode computerTested = new Intcode(data);
            computerTested.InputQueue.Enqueue(input);

            computerTested.Run();

            computerTested.OutputQueue.Enqueue(input);
        }

        [Test]
        public void Opcodes_Should_Allow_ParameterMode_Change_For_Simple_Commands()
        {
            int[] data = new[] { 1002, 8, 3, 8, 1001, 8, 0, 0, 33 };
            Intcode computerTested = new Intcode(data);

            int result = computerTested.Run();

            result.Should().Be(99);
        }

        [Test]
        public void Verbose_Mode_Should_Output_Simple_Commands()
        {
            int[] data = new[] { 1002, 8, 3, 8, 1001, 8, 0, 0, 33 };
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Mock<TextReader> mockTextReader = new Mock<TextReader>();
            Console.SetOut(mockTextWriter.Object);
            Console.SetIn(mockTextReader.Object);
            Intcode computerTested = new Intcode(data, IntcodeMode.Verbose);

            int result = computerTested.Run();

            mockTextWriter.Verify(m => m.WriteLine("0: Multiply [@1 8p (=33), @2 3i (=3), @3 8p (=33)]"));
            mockTextWriter.Verify(m => m.WriteLine("4: Add [@5 8p (=99), @6 0i (=0), @7 0p (=1002)]"));
            mockTextWriter.Verify(m => m.WriteLine("8: Finish"));
        }

        [Test]
        public void Quiet_Mode_Should_Not_Output_Commands()
        {
            int[] data = new[] { 1002, 8, 3, 8, 1001, 8, 0, 0, 33 };
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Mock<TextReader> mockTextReader = new Mock<TextReader>();
            Console.SetOut(mockTextWriter.Object);
            Console.SetIn(mockTextReader.Object);
            Intcode computerTested = new Intcode(data);

            int result = computerTested.Run();

            mockTextWriter.Verify(m => m.WriteLine("0: Multiply [8p, 3i, 8p]"), Times.Never);
            mockTextWriter.Verify(m => m.WriteLine("4: Add [8p, 0i, 0p]"), Times.Never);
            mockTextWriter.Verify(m => m.WriteLine("8: Finish"), Times.Never);
        }

        [Test]
        public void Opcodes_Should_Allow_ParameterMode_Change_For_NextGen_Commands()
        {
            int[] data = new[] { 3, 0, 104, 0, 99 };
            int input = 123;
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Mock<TextReader> mockTextReader = new Mock<TextReader>();
            Console.SetOut(mockTextWriter.Object);
            Console.SetIn(mockTextReader.Object);
            mockTextReader.Setup(m => m.ReadLine()).Returns(input.ToString());
            Intcode computerTested = new Intcode(data);

            computerTested.Run();

            mockTextWriter.Verify(m => m.WriteLine("Output: 0"));
        }

        [Test]
        public void Opcode_5_Should_Jump_To_Second_Parameter_Position_When_First_Parameter_Is_Non_Zero()
        {
            int[] data = new[] { 1, 0, 0, 0, 1105, 1, 11, 1, 0, 0, 0, 99 };
            Intcode computerTested = new Intcode(data);

            int result = computerTested.Run();

            result.Should().Be(2);
        }

        [Test]
        public void Opcode_5_Should_Do_Nothing_When_First_Parameter_Is_Zero()
        {
            int[] data = new[] { 1, 0, 0, 0, 1105, 0, 11, 1, 0, 0, 0, 99 };
            Intcode computerTested = new Intcode(data);

            int result = computerTested.Run();

            result.Should().Be(4);
        }

        [Test]
        public void Opcode_6_Should_Jump_To_Second_Parameter_Position_When_First_Parameter_Is_Zero()
        {
            int[] data = new[] { 1, 0, 0, 0, 1106, 0, 11, 1, 0, 0, 0, 99 };
            Intcode computerTested = new Intcode(data);

            int result = computerTested.Run();

            result.Should().Be(2);
        }

        [Test]
        public void Opcode_6_Should_Do_Nothing_When_First_Parameter_Is_Non_Zero()
        {
            int[] data = new[] { 1, 0, 0, 0, 1106, 1, 11, 1, 0, 0, 0, 99 };
            Intcode computerTested = new Intcode(data);

            int result = computerTested.Run();

            result.Should().Be(4);
        }

        [Test]
        public void Opcode_7_Should_Write_One_When_First_Param_Is_Less_Than_Second()
        {
            int[] data = new[] { 1107, 0, 1, 0, 99 };
            Intcode computerTested = new Intcode(data);

            int result = computerTested.Run();

            result.Should().Be(1);
        }

        [Test]
        public void Opcode_7_Should_Write_Zero_When_First_Param_Is_Not_Less_Than_Second()
        {
            int[] data = new[] { 1107, 1, 0, 0, 99 };
            Intcode computerTested = new Intcode(data);

            int result = computerTested.Run();

            result.Should().Be(0);
        }

        [Test]
        public void Opcode_8_Should_Write_One_When_First_Param_Is_Equal_To_Second()
        {
            int[] data = new[] { 1108, 0, 0, 0, 99 };
            Intcode computerTested = new Intcode(data);

            int result = computerTested.Run();

            result.Should().Be(1);
        }

        [Test]
        public void Opcode_8_Should_Write_Zero_When_First_Param_Is_Not_Equal_To_Second()
        {
            int[] data = new[] { 1108, 1, 0, 0, 99 };
            Intcode computerTested = new Intcode(data);

            int result = computerTested.Run();

            result.Should().Be(0);
        }
    }
}
