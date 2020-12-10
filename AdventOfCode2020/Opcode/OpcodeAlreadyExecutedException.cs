using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Opcode
{
    public class OpcodeAlreadyExecutedException : Exception
    {
        public int Accumulator { get; }
        public int InstructionPointer { get; }
        public OpcodeInstruction Opcode { get; }

        public override string Message => $"The machine tried to execute a previously executed opcode at {InstructionPointer}. Accumulator was {Accumulator} before executing it. The opcode is {Opcode}";

        public OpcodeAlreadyExecutedException(int accumulator, int instructionPointer, OpcodeInstruction opcode)
        {
            Accumulator = accumulator;
            InstructionPointer = instructionPointer;
            Opcode = opcode;
        }
    }
}
