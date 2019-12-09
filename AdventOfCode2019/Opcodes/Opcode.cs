using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Opcodes
{
    public abstract class Opcode
    {
        public abstract int Params { get; }
        protected abstract void InnerExecute(IntcodeContext context);

        public void Execute(IntcodeContext context)
        {
            if (context.Mode.HasFlag(IntcodeMode.Verbose))
                Console.WriteLine(Describe(context));
            InnerExecute(context);
        }

        public string Describe(IntcodeContext context)
        {
            string desc = "";
            if (!String.IsNullOrEmpty(context.Id))
                desc += "{ " + context.Id + " } ";
            desc += context.InstructionPointer + ": ";
            desc += this.GetType().Name;
            if (Params > 0)
                desc += " [" + String.Join(", ", Enumerable.Range(1, Params).Select(
                    i => "@"+ (context.InstructionPointer + i) + " " + context.Data[context.InstructionPointer + i].ToString() + (context.ParamIsInImmediateMode(i) ? ("i (=" + context.Data[context.InstructionPointer + i])
                        : "p (=" + (context.Data[context.Data[context.InstructionPointer + i]])) + ")"
                )) + "]";
            return desc;
        }
    }
}
