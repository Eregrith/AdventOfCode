using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Opcodes
{
    public class OffsetRelativeBase : Opcode
    {
        public override int Params => 1;

        protected override void InnerExecute(IntcodeContext context)
        {
            context.RelativeBase += context.Read(1);
            context.InstructionPointer += 2;
        }
    }
}
