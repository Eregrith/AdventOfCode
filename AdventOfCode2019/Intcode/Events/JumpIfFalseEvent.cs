using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Events
{
    public class JumpIfFalseEvent : IntcodeEvent
    {
        public JumpIfFalseEvent(long addr, EventParam a, EventParam b) : base(addr)
        {
            Params.Add(a);
            Params.Add(b);
        }

        public override string ToString()
        {
            return $"if ({ParamLabel(0)} == 0) goto {ParamLabel(1)}";
        }
    }
}
