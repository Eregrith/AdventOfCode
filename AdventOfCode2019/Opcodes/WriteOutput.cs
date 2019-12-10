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
            long output = context.Read(1);
            if (!context.Mode.HasFlag(IntcodeMode.Quiet))
                Console.WriteLine("Output: " + output);
            context.OutputQueue.Enqueue(output);
            context.InstructionPointer += 2;
        }
    }
}
