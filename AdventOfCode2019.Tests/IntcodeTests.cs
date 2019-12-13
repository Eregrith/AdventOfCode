using NUnit.Framework;
using FluentAssertions;
using System;
using System.IO;
using Moq;
using System.Threading;
using AdventOfCode2019.Intcode;

namespace AdventOfCode2019.Tests
{
    [TestFixture]
    class IntcodeTests
    {
        [TestCase(12, 2, 5866714)]
        [TestCase(52, 8, 19690720)]
        public void Intcode_Should_Return_Correct_Value_Based_On_Noun_And_Verb(int noun, int verb, long result)
        {
            long[] data = new long[] { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 13, 1, 19, 1, 19, 10, 23, 1, 23, 6, 27, 1, 6, 27, 31, 1, 13, 31, 35, 1, 13, 35, 39, 1, 39, 13, 43, 2, 43, 9, 47, 2, 6, 47, 51, 1, 51, 9, 55, 1, 55, 9, 59, 1, 59, 6, 63, 1, 9, 63, 67, 2, 67, 10, 71, 2, 71, 13, 75, 1, 10, 75, 79, 2, 10, 79, 83, 1, 83, 6, 87, 2, 87, 10, 91, 1, 91, 6, 95, 1, 95, 13, 99, 1, 99, 13, 103, 2, 103, 9, 107, 2, 107, 10, 111, 1, 5, 111, 115, 2, 115, 9, 119, 1, 5, 119, 123, 1, 123, 9, 127, 1, 127, 2, 131, 1, 5, 131, 0, 99, 2, 0, 14, 0 };
            IntcodeComputer i = new IntcodeComputer(data);

            i.Run(noun, verb).Should().Be(result);
        }

        [Test]
        public void Opcodes_3_and_4_Read_and_Write_To_Console_When_Input_Queue_Is_Empty()
        {
            long[] data = new long[] { 3, 0, 4, 0, 99 };
            long input = 1234;
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Mock<TextReader> mockTextReader = new Mock<TextReader>();
            Console.SetOut(mockTextWriter.Object);
            Console.SetIn(mockTextReader.Object);
            mockTextReader.Setup(m => m.ReadLine()).Returns(input.ToString());
            IntcodeComputer computerTested = new IntcodeComputer(data);

            computerTested.Run();

            mockTextWriter.Verify(m => m.Write("Input: "));
            mockTextWriter.Verify(m => m.WriteLine("Output: " + input));
        }

        [Test]
        public void Opcodes_3_Should_Read_From_Input_Queue_When_It_Is_Not_Empty()
        {
            long[] data = new long[] { 3, 0, 4, 0, 99 };
            long input = 1234;
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Console.SetOut(mockTextWriter.Object);
            IntcodeComputer computerTested = new IntcodeComputer(data);
            computerTested.InputQueue.Enqueue(input);

            computerTested.Run();

            mockTextWriter.Verify(m => m.Write("Input: "), Times.Never);
            mockTextWriter.Verify(m => m.WriteLine("Output: " + input), Times.Once);
        }

        [Test]
        public void Opcodes_3_Should_Wait_For_Input_Queue_When_In_Blocking_Mode()
        {
            long[] data = new long[] { 3, 0, 4, 0, 99 };
            long input = 1234;
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Console.SetOut(mockTextWriter.Object);
            IntcodeComputer computerTested = new IntcodeComputer(data, IntcodeMode.Blocking);

            new Thread(() => computerTested.Run()).Start();

            computerTested.InputQueue.Enqueue(input);
            mockTextWriter.Verify(m => m.Write("Input: "), Times.Never);
            mockTextWriter.Verify(m => m.WriteLine("Output: " + input), Times.Once);
        }

        [Test]
        public void Opcodes_4_Should_Also_Write_To_OutputQueue()
        {
            long[] data = new long[] { 3, 0, 4, 0, 99 };
            long input = 1234;
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Console.SetOut(mockTextWriter.Object);
            IntcodeComputer computerTested = new IntcodeComputer(data);
            computerTested.InputQueue.Enqueue(input);

            computerTested.Run();

            computerTested.OutputQueue.Enqueue(input);
        }

        [Test]
        public void Opcodes_Should_Allow_ParameterMode_Change_For_Simple_Commands()
        {
            long[] data = new long[] { 1002, 8, 3, 8, 1001, 8, 0, 0, 33 };
            IntcodeComputer computerTested = new IntcodeComputer(data);

            long result = computerTested.Run();

            result.Should().Be(99);
        }

        [Test]
        public void Verbose_Mode_Should_Output_Simple_Commands()
        {
            long[] data = new long[] { 1002, 8, 3, 8, 1001, 8, 0, 0, 33 };
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Mock<TextReader> mockTextReader = new Mock<TextReader>();
            Console.SetOut(mockTextWriter.Object);
            Console.SetIn(mockTextReader.Object);
            IntcodeComputer computerTested = new IntcodeComputer(data, IntcodeMode.Verbose);

            long result = computerTested.Run();

            mockTextWriter.Verify(m => m.WriteLine("0: Multiply [@1 8p (=33), @2 3i (=3), @3 8p (=33)]"));
            mockTextWriter.Verify(m => m.WriteLine("4: Add [@5 8p (=99), @6 0i (=0), @7 0p (=1002)]"));
            mockTextWriter.Verify(m => m.WriteLine("8: Finish"));
        }

        [Test]
        public void Quiet_Mode_Should_Not_Output_Commands()
        {
            long[] data = new long[] { 1002, 8, 3, 8, 1001, 8, 0, 0, 33 };
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Mock<TextReader> mockTextReader = new Mock<TextReader>();
            Console.SetOut(mockTextWriter.Object);
            Console.SetIn(mockTextReader.Object);
            IntcodeComputer computerTested = new IntcodeComputer(data);

            long result = computerTested.Run();

            mockTextWriter.Verify(m => m.WriteLine("0: Multiply [8p, 3i, 8p]"), Times.Never);
            mockTextWriter.Verify(m => m.WriteLine("4: Add [8p, 0i, 0p]"), Times.Never);
            mockTextWriter.Verify(m => m.WriteLine("8: Finish"), Times.Never);
        }

        [Test]
        public void Opcodes_Should_Allow_ParameterMode_Change_For_NextGen_Commands()
        {
            long[] data = new long[] { 3, 0, 104, 0, 99 };
            long input = 123;
            Mock<TextWriter> mockTextWriter = new Mock<TextWriter>();
            Mock<TextReader> mockTextReader = new Mock<TextReader>();
            Console.SetOut(mockTextWriter.Object);
            Console.SetIn(mockTextReader.Object);
            mockTextReader.Setup(m => m.ReadLine()).Returns(input.ToString());
            IntcodeComputer computerTested = new IntcodeComputer(data);

            computerTested.Run();

            mockTextWriter.Verify(m => m.WriteLine("Output: 0"));
        }

        [Test]
        public void Opcode_5_Should_Jump_To_Second_Parameter_Position_When_First_Parameter_Is_Non_Zero()
        {
            long[] data = new long[] { 1, 0, 0, 0, 1105, 1, 11, 1, 0, 0, 0, 99 };
            IntcodeComputer computerTested = new IntcodeComputer(data);

            long result = computerTested.Run();

            result.Should().Be(2);
        }

        [Test]
        public void Opcode_5_Should_Do_Nothing_When_First_Parameter_Is_Zero()
        {
            long[] data = new long[] { 1, 0, 0, 0, 1105, 0, 11, 1, 0, 0, 0, 99 };
            IntcodeComputer computerTested = new IntcodeComputer(data);

            long result = computerTested.Run();

            result.Should().Be(4);
        }

        [Test]
        public void Opcode_6_Should_Jump_To_Second_Parameter_Position_When_First_Parameter_Is_Zero()
        {
            long[] data = new long[] { 1, 0, 0, 0, 1106, 0, 11, 1, 0, 0, 0, 99 };
            IntcodeComputer computerTested = new IntcodeComputer(data);

            long result = computerTested.Run();

            result.Should().Be(2);
        }

        [Test]
        public void Opcode_6_Should_Do_Nothing_When_First_Parameter_Is_Non_Zero()
        {
            long[] data = new long[] { 1, 0, 0, 0, 1106, 1, 11, 1, 0, 0, 0, 99 };
            IntcodeComputer computerTested = new IntcodeComputer(data);

            long result = computerTested.Run();

            result.Should().Be(4);
        }

        [Test]
        public void Opcode_7_Should_Write_One_When_First_Param_Is_Less_Than_Second()
        {
            long[] data = new long[] { 1107, 0, 1, 0, 99 };
            IntcodeComputer computerTested = new IntcodeComputer(data);

            long result = computerTested.Run();

            result.Should().Be(1);
        }

        [Test]
        public void Opcode_7_Should_Write_Zero_When_First_Param_Is_Not_Less_Than_Second()
        {
            long[] data = new long[] { 1107, 1, 0, 0, 99 };
            IntcodeComputer computerTested = new IntcodeComputer(data);

            long result = computerTested.Run();

            result.Should().Be(0);
        }

        [Test]
        public void Opcode_8_Should_Write_One_When_First_Param_Is_Equal_To_Second()
        {
            long[] data = new long[] { 1108, 0, 0, 0, 99 };
            IntcodeComputer computerTested = new IntcodeComputer(data);

            long result = computerTested.Run();

            result.Should().Be(1);
        }

        [Test]
        public void Opcode_8_Should_Write_Zero_When_First_Param_Is_Not_Equal_To_Second()
        {
            long[] data = new long[] { 1108, 1, 0, 0, 99 };
            IntcodeComputer computerTested = new IntcodeComputer(data);

            long result = computerTested.Run();

            result.Should().Be(0);
        }

        [Test]
        public void Opcode_9_Should_Offset_Relative_Base_For_Parameters_In_Relative_Mode()
        {
            long[] data = new long[] { 109, 2, 2201, 0, 0, 0, 99 };
            IntcodeComputer computerTested = new IntcodeComputer(data);

            long result = computerTested.Run();

            result.Should().Be(4402);
        }

        [Test]
        public void Writes_Can_Be_In_Relative_Mode()
        {
            long input = 23942059;
            long[] data = new long[] { 109, 3, 203, -3, 99 };
            IntcodeComputer computerTested = new IntcodeComputer(data);
            computerTested.InputQueue.Enqueue(input);

            long result = computerTested.Run();

            result.Should().Be(input);
        }

        [Test]
        public void Memory_Should_Be_Larger_Than_Initial_Data()
        {
            long[] data = new long[] { 1, 0, 0, 9, 1, 9, 9, 0, 99 };
            IntcodeComputer computerTested = new IntcodeComputer(data);

            long result = computerTested.Run();

            result.Should().Be(4);
        }

        [Test]
        public void Large_Numbers_Should_Be_Okay()
        {
            long[] data = new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
            IntcodeComputer computerTested = new IntcodeComputer(data);

            computerTested.Run();

            computerTested.OutputQueue.Should().Contain(1219070632396864);
        }

        [Test]
        public void Should_Report_Context_To_Given_Reporter_When_There_Is_One_After_Each_Step()
        {
            long[] data = new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
            IntcodeComputer computerTested = new IntcodeComputer(data);
            Mock<IIntcodeReporter> mockReporter = new Mock<IIntcodeReporter>();
            computerTested.Reporter = mockReporter.Object;

            computerTested.Run();

            mockReporter.Verify(m => m.Step(computerTested.Context), Times.Exactly(3));
        }

        [Test]
        public void Should_Work_In_Step_By_Step_Mode()
        {
            long[] data = new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
            IntcodeComputer computerTested = new IntcodeComputer(data);
            Mock<IIntcodeReporter> mockReporter = new Mock<IIntcodeReporter>();
            computerTested.Reporter = mockReporter.Object;

            computerTested.Step();

            mockReporter.Verify(m => m.Step(computerTested.Context), Times.Once);

            computerTested.Step();

            mockReporter.Verify(m => m.Step(computerTested.Context), Times.Exactly(2));

            computerTested.Step();

            mockReporter.Verify(m => m.Step(computerTested.Context), Times.Exactly(3));
        }
    }
}
