using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Opcodes
{
    public class Finish : Opcode
    {
        public override int Params => 0;

        protected override void InnerExecute(IntcodeContext context)
        {
            context.IsFinished = true;
            context.InstructionPointer += 1;
        }
    }
}
