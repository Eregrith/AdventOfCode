using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Events
{
    class JumpIfTrueEvent : IntcodeEvent
    {
        public JumpIfTrueEvent(long addr, EventParam a, EventParam b) : base(addr)
        {
            Params.Add(a);
            Params.Add(b);
        }

        public override string ToString()
        {
            return $"if ({ParamLabel(0)} != 0) goto {ParamLabel(1)}";
        }
    }
}
