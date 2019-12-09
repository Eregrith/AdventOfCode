using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Opcodes
{
    public class JumpIfFalse : Opcode
    {
        public override int Params => 2;

        protected override void InnerExecute(IntcodeContext context)
        {
            context.InstructionPointer = context.Read(1) == 0 ? context.Read(2) : context.InstructionPointer + 3;
        }
    }
}
