using AdventOfCode2019.Intcode.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Opcodes
{
    public class JumpIfFalse : Opcode
    {
        public override int Params => 2;

        public override IntcodeEvent ToEvent(IntcodeContext context)
        {
            return new JumpIfFalseEvent(context.InstructionPointer,
                                        GetEventParam(context, 1),
                                        GetEventParam(context, 2));
        }

        protected override void InnerExecute(IntcodeContext context)
        {
            context.InstructionPointer = context.Read(1) == 0 ? context.Read(2) : context.InstructionPointer + 3;
        }
    }
}
