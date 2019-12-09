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
            Console.Write("Input: ");
            string input = Console.ReadLine();
            context.Write(1, int.Parse(input));
            context.InstructionPointer += 2;
        }
    }
}
