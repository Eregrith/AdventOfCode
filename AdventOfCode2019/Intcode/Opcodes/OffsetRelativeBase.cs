﻿using AdventOfCode2019.Intcode.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Opcodes
{
    public class OffsetRelativeBase : Opcode
    {
        public override int Params => 1;

        public override IntcodeEvent ToEvent(IntcodeContext context)
        {
            return new OffsetRelativeBaseEvent(context.InstructionPointer,
                                               GetEventParam(context, 1));
        }

        protected override void InnerExecute(IntcodeContext context)
        {
            context.RelativeBase += context.Read(1);
            context.InstructionPointer += 2;
        }
    }
}
