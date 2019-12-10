﻿using AdventOfCode2019.Opcodes;
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
        public Queue<long> InputQueue { get; set; } = new Queue<long>();
        public Queue<long> OutputQueue { get; set; } = new Queue<long>();
        public IntcodeMode Mode { get; }
        public long[] Data { get; }
        public string Id { get; }
        public bool IsFinished { get; set; } = false;
        public long InstructionPointer { get; set; } = 0;
        public long CurrentOpcode => Data[InstructionPointer] % 100;
        public long RelativeBase = 0;

        public long Read(long offset) => ParamIsInImmediateMode(offset) ? ValueAt(offset) : (ParamIsInRelativeMode(offset) ? Data[ValueAt(offset) + RelativeBase] : Data[ValueAt(offset)]);

        private long ValueAt(long offset) => Data[InstructionPointer + offset];

        public void Write(long offset, long value)
        {
            if (ParamIsInRelativeMode(offset))
                Data[Data[InstructionPointer + offset] + RelativeBase] = value;
            else
                Data[Data[InstructionPointer + offset]] = value;
        }

        public bool ParamIsInImmediateMode(long offset) => Data[InstructionPointer] / (10 * (long)Math.Pow(10, offset)) % 10 == 1;
        public bool ParamIsInRelativeMode(long offset) => Data[InstructionPointer] / (10 * (long)Math.Pow(10, offset)) % 10 == 2;

        public IntcodeContext(long[] data, IntcodeMode mode, string id)
        {
            Data = new long[2048];
            for (int i = 0; i < data.Length; i++)
                Data[i] = data[i];
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
        public Queue<long> InputQueue { get => Context.InputQueue; set => Context.InputQueue = value; }
        public Queue<long> OutputQueue { get => Context.OutputQueue; set => Context.OutputQueue = value; }
        private Dictionary<long, Opcode> Opcodes = new Dictionary<long, Opcode>
        {
            [1] = new Add(),
            [2] = new Multiply(),
            [3] = new WriteInput(),
            [4] = new WriteOutput(),
            [5] = new JumpIfTrue(),
            [6] = new JumpIfFalse(),
            [7] = new LessThan(),
            [8] = new Equals(),
            [9] = new OffsetRelativeBase(),
            [99] = new Finish()
        };

        public Intcode(long[] data, IntcodeMode mode = IntcodeMode.None, string id = null)
        {
            Context = new IntcodeContext(data, mode, id);
        }

        public long Run(int noun, int verb)
        {
            Context.Data[1] = noun;
            Context.Data[2] = verb;
            return Run();
        }

        public long Run()
        {
            while (!Context.IsFinished)
                Opcodes[Context.CurrentOpcode].Execute(Context);
            return Context.Data[0];
        }
    }
}
