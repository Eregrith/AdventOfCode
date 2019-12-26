using AdventOfCode2019.Intcode.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Opcodes
{
    public class Finish : Opcode
    {
        public override int Params => 0;

        public override IntcodeEvent ToEvent(IntcodeContext context)
        {
            return new FinishEvent(context.InstructionPointer);
        }

        protected override void InnerExecute(IntcodeContext context)
        {
            context.IsFinished = true;
            context.InstructionPointer += 1;
        }
    }
}
