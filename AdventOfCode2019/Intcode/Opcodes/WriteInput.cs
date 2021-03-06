﻿using AdventOfCode2019.Intcode.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Opcodes
{
    public class WriteInput : Opcode
    {
        public override int Params => 1;

        public override IntcodeEvent ToEvent(IntcodeContext context)
        {
            return new WriteInputEvent(context.InstructionPointer,
                                       GetEventParam(context, 1));
        }

        protected override void InnerExecute(IntcodeContext context)
        {
            long value = 0;
            if (context.InputQueue.Count > 0 || context.Mode.HasFlag(IntcodeMode.Blocking))
            {
                context.IsWaitingForInput = true;
                while (context.InputQueue.Count == 0) ;
                context.IsWaitingForInput = false;
                value = context.InputQueue.Dequeue();
            }
            else
            {
                Console.Write("Input: ");
                string input = Console.ReadLine();
                value = int.Parse(input);
            }
            context.Write(1, value);
            context.InstructionPointer += 2;
        }
    }
}
