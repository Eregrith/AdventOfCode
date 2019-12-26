using AdventOfCode2019.Intcode.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Opcodes
{
    public class Equals : Opcode
    {
        public override int Params => 3;

        public override IntcodeEvent ToEvent(IntcodeContext context)
        {
            return new EqualsEvent(context.InstructionPointer,
                                   GetEventParam(context, 1),
                                   GetEventParam(context, 2),
                                   GetEventParam(context, 3));
        }

        protected override void InnerExecute(IntcodeContext context)
        {
            context.Write(3, context.Read(1) == context.Read(2) ? 1 : 0);
            context.InstructionPointer += 4;
        }
    }
}
