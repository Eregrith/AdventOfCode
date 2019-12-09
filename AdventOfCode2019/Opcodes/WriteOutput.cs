using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Opcodes
{
    public class WriteOutput : Opcode
    {
        public override int Params => 1;

        protected override void InnerExecute(IntcodeContext context)
        {
            int output = context.Read(1);
            Console.WriteLine("Output: " + output);
            context.InstructionPointer += 2;
        }
    }
}
