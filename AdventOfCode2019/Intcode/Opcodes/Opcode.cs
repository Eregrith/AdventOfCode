using AdventOfCode2019.Intcode.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Intcode.Opcodes
{
    public abstract class Opcode
    {
        public abstract int Params { get; }
        public string Name => this.GetType().Name;
        protected abstract void InnerExecute(IntcodeContext context);

        public void Execute(IntcodeContext context)
        {
            if (context.Mode.HasFlag(IntcodeMode.Trace))
                context.Events.Add(ToEvent(context));
            if (context.Mode.HasFlag(IntcodeMode.Verbose))
                Console.WriteLine(Describe(context));
            InnerExecute(context);
        }

        protected EventParam GetEventParam(IntcodeContext c, long offset)
        {
            EventParam param = new EventParam();
            param.Value = c.Data[c.InstructionPointer + offset];
            if (c.ParamIsInImmediateMode(offset))
                param.Mode = ParamMode.Immediate;
            else if (c.ParamIsInRelativeMode(offset))
                param.Mode = ParamMode.Relative;
            else
                param.Mode = ParamMode.Position;
            return param;
        }

        public string Describe(IntcodeContext context)
        {
            string desc = "";
            if (!String.IsNullOrEmpty(context.Id))
                desc += "{ " + context.Id + " } ";
            desc += String.Format("{0:0000}: ", context.InstructionPointer);
            desc += this.GetType().Name;
            if (Params > 0)
                desc += " [" + string.Join(", ", Enumerable.Range(1, Params).Select(
                    i => "@" + (context.InstructionPointer + i) + " " + context.Data[context.InstructionPointer + i].ToString()
                        + (context.ParamIsInImmediateMode(i) ?
                             ("i (=" + context.Data[context.InstructionPointer + i] + ")")
                            : (context.ParamIsInRelativeMode(i) ? "r" : "p (=" + SafeDoubleDereference(context, i) + ")"))
                )) + "]";
            return desc;
        }

        private static string SafeDoubleDereference(IntcodeContext context, int i)
        {
            long target = context.InstructionPointer + i;
            target = context.Data[target];
            if (target >= context.Data.Length || target < 0)
                return "oob{" + target + "}";
            return "" + context.Data[target];
        }

        public abstract IntcodeEvent ToEvent(IntcodeContext context);
    }
}
