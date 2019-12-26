using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Events
{
    public class EqualsEvent : IntcodeEvent
    {
        public EqualsEvent(long addr, EventParam a, EventParam b, EventParam c) : base(addr)
        {
            Params.Add(a);
            Params.Add(b);
            Params.Add(c);
        }

        public override string ToString()
        {
            return $"{ParamLabel(2)} = ({ParamLabel(0)} == {ParamLabel(1)})";
        }
    }
}
