using AdventOfCode2019.Opcodes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2019
{
    [Flags]
    public enum IntcodeMode
    {
        None = 0,
        Quiet = 1,
        Verbose = 2,
        Blocking = 4
    };

    public class IntcodeContext
    {
        public Queue<int> InputQueue { get; set; } = new Queue<int>();
        public Queue<int> OutputQueue { get; set; } = new Queue<int>();
        public IntcodeMode Mode { get; }
        public int[] Data { get; }
        public string Id { get; }
        public bool IsFinished { get; set; } = false;
        public int InstructionPointer { get; set; } = 0;
        public int CurrentOpcode => Data[InstructionPointer] % 100;

        public int Read(int offset) => ParamIsInImmediateMode(offset) ? ValueAt(offset) : Data[ValueAt(offset)];

        private int ValueAt(int offset) => Data[InstructionPointer + offset];

        public void Write(int offset, int value) => Data[Data[InstructionPointer + offset]] = value;
        public bool ParamIsInImmediateMode(int offset) => Data[InstructionPointer] / (10 * (int)Math.Pow(10, offset)) % 10 == 1;

        public IntcodeContext(int[] data, IntcodeMode mode, string id)
        {
            Data = data;
            Mode = mode;
            Id = id;
        }

        public override string ToString()
        {
            return $"{{ {Id} }} [{InstructionPointer}] {String.Join(",", Data)}";
        }
    }

    [DebuggerDisplay("{Context}")]
    public class Intcode
    {
        private IntcodeContext Context { get; set; }
        public Queue<int> InputQueue { get => Context.InputQueue; set => Context.InputQueue = value; }
        public Queue<int> OutputQueue { get => Context.OutputQueue; set => Context.OutputQueue = value; }
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

        public Intcode(int[] data, IntcodeMode mode = IntcodeMode.None, string id = null)
        {
            Context = new IntcodeContext(data, mode, id);
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
