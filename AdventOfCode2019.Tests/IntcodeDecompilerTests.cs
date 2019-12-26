using AdventOfCode2019.Intcode;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Tests
{
    [TestFixture]
    class IntcodeDecompilerTests
    {
        [Test]
        public void Decompile_Should_Output_Opcodes_And_Parameters()
        {
            long[] data = new long[]
            {
                1101, 1, 2, 0,
                2, 3, 4, 5,
                3, 1,
                204, 2,
                5, 142, 3,
                6, 25, 1,
                7, 19, 3, 4,
                8, 12, 1, 2,
                9, 6,
                99
            };
            IntcodeDecompiler decomTested = new IntcodeDecompiler();
            string[] expected = new[]
            {
                "{ decompiled } 0000: Add [@1 1i (=1), @2 2i (=2), @3 0p (=1101)]",
                "{ decompiled } 0004: Multiply [@5 3p (=0), @6 4p (=2), @7 5p (=3)]",
                "{ decompiled } 0008: WriteInput [@9 1p (=1)]",
                "{ decompiled } 0010: WriteOutput [@11 2r]",
                "{ decompiled } 0012: JumpIfTrue [@13 142p (=0), @14 3p (=0)]",
                "{ decompiled } 0015: JumpIfFalse [@16 25p (=2), @17 1p (=1)]",
                "{ decompiled } 0018: LessThan [@19 19p (=19), @20 3p (=0), @21 4p (=2)]",
                "{ decompiled } 0022: Equals [@23 12p (=5), @24 1p (=1), @25 2p (=2)]",
                "{ decompiled } 0026: OffsetRelativeBase [@27 6p (=4)]",
                "{ decompiled } 0028: Finish"
            };

            List<string> result = decomTested.Decompile(data);

            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Decompile_Should_Safely_Decompile_OutOfBonds_Targets()
        {
            long[] data = new long[]
            {
                3, 3,
                101, 0, 5000, 0,
                101, 0, -1, 0,
                142,
                99
            };
            IntcodeDecompiler decomTested = new IntcodeDecompiler();
            string[] expected = new[]
            {
                "{ decompiled } 0000: WriteInput [@1 3p (=0)]",
                "{ decompiled } 0002: Add [@3 0i (=0), @4 5000p (=oob{5000}), @5 0p (=3)]",
                "{ decompiled } 0006: Add [@7 0i (=0), @8 -1p (=oob{-1}), @9 0p (=3)]",
                "{ decompiled } 0010: Raw data [142]",
                "{ decompiled } 0011: Finish"
            };

            List<string> result = decomTested.Decompile(data);

            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Labelize_Should_Produce_Readable_Output_And_Use_Variables()
        {
            long[] data = new long[]
            {
                1101, 1, 2, 0,
                2, 4, 0, 4,
                3, 0,
                204, 2,
                7, 10, 0, 4,
                8, 4, 0, 10,
                9, 4,
                99,
                123, 456, 789
            };
            IntcodeDecompiler decomTested = new IntcodeDecompiler();
            string[] expected = new[]
            {
                "0000 pos_0: pos_0 = 1 + 2",
                "",
                "0004 pos_1: pos_1 = pos_1 * pos_0",
                "0008        pos_0 = getInput()",
                "",
                "0010 pos_2: Write(([2] + r))",
                "0012        pos_1 = (pos_2 < pos_0)",
                "0016        pos_2 = (pos_1 == pos_0)",
                "0020        r = r + pos_1",
                "0022        stop",
                "0023        data 123",
                "0024        data 456",
                "0025        data 789"
            };

            List<string> result = decomTested.Labelize(data);

            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Labelize_Should_Dereference_Jump_Values()
        {
            long[] data = new long[]
            {
                1005, 0, 0,
                1006, 0, 0,
                5, 0, 0,
                6, 0, 0,
            };
            IntcodeDecompiler decomTested = new IntcodeDecompiler();
            string[] expected = new[]
            {
                "0000 pos_0: if (pos_0 != 0) goto pos_0",
                "0003        if (pos_0 == 0) goto pos_0",
                "0006        if (pos_0 != 0) goto @pos_0",
                "0009        if (pos_0 == 0) goto @pos_0",
            };

            List<string> result = decomTested.Labelize(data);

            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Labelize_Should_Number_Positions_In_Growing_Order()
        {
            long[] data = new long[]
            {
                1, 4, 4, 4,
                1, 0, 0, 0,
                1, 8, 8, 8,
            };
            IntcodeDecompiler decomTested = new IntcodeDecompiler();
            string[] expected = new[]
            {
                "0000 pos_0: pos_1 = pos_1 + pos_1",
                "",
                "0004 pos_1: pos_0 = pos_0 + pos_0",
                "",
                "0008 pos_2: pos_2 = pos_2 + pos_2",
            };

            List<string> result = decomTested.Labelize(data);

            result.Should().ContainInOrder(expected);
        }

        [Test]
        public void Labelize_Should_Mark_In_Between_Positions()
        {
            long[] data = new long[]
            {
                1, 1, 2, 3,
            };
            IntcodeDecompiler decomTested = new IntcodeDecompiler();
            string[] expected = new[]
            {
                "0000        [3] = [1] + [2]",
            };

            List<string> result = decomTested.Labelize(data);

            result.Should().ContainInOrder(expected);
        }

        [Test]
        public void Labelize_Should_Not_Mark_Immediate_Values()
        {
            long[] data = new long[]
            {
                1101, 1, 2, 3,
            };
            IntcodeDecompiler decomTested = new IntcodeDecompiler();
            string[] expected = new[]
            {
                "0000        [3] = 1 + 2",
            };

            List<string> result = decomTested.Labelize(data);

            result.Should().ContainInOrder(expected);
        }
    }
}
