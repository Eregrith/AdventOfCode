using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Opcodes
{
    public class WriteInput : Opcode
    {
        public override int Params => 1;

        protected override void InnerExecute(IntcodeContext context)
        {
            int value = 0;
            if (context.InputQueue.Count > 0 || context.Mode.HasFlag(IntcodeMode.Blocking))
            {
                while (context.InputQueue.Count == 0);
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
