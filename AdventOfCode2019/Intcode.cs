using AdventOfCode2019.Opcodes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2019
{
    public enum IntcodeMode
    {
        Quiet,
        Verbose
    };

    public class IntcodeContext
    {
        public IntcodeMode Mode { get; }
        public int[] Data { get; }
        public bool IsFinished { get; set; } = false;
        public int InstructionPointer { get; set; } = 0;
        public int CurrentOpcode => Data[InstructionPointer] % 100;

        public int Read(int offset) => ParamIsInImmediateMode(offset) ? ValueAt(offset) : Data[ValueAt(offset)];

        private int ValueAt(int offset) => Data[InstructionPointer + offset];

        public void Write(int offset, int value) => Data[Data[InstructionPointer + offset]] = value;
        public bool ParamIsInImmediateMode(int offset) => Data[InstructionPointer] / (10 * (int)Math.Pow(10, offset)) % 10 == 1;

        public IntcodeContext(int[] data, IntcodeMode mode)
        {
            Data = data;
            Mode = mode;
        }

        public override string ToString()
        {
            return String.Join(",", Data);
        }
    }

    [DebuggerDisplay("{Context}")]
    public class Intcode
    {
        private IntcodeContext Context { get; set; }
        private Dictionary<int, Opcode> Opcodes = new Dictionary<int, Opcode>
        {
            [1] = new Add(),
            [2] = new Multiply(),
            [3] = new WriteInput(),
            [4] = new WriteOutput(),
            [5] = new JumpIfTrue(),
            [6] = new JumpIfFalse(),
            [7] = new LessThan(),
            [8] = new Equals(),
            [99] = new Finish()
        };

        public Intcode(int[] data, IntcodeMode mode = IntcodeMode.Quiet)
        {
            Context = new IntcodeContext(data, mode);
        }

        public int Run(int noun, int verb)
        {
            Context.Data[1] = noun;
            Context.Data[2] = verb;
            return Run();
        }

        public int Run()
        {
            while (!Context.IsFinished)
                Opcodes[Context.CurrentOpcode].Execute(Context);
            return Context.Data[0];
        }
    }
}
