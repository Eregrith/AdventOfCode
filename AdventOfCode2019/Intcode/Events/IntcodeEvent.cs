using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Events
{
    public class IntcodeEvent
    {
        public long Address { get; set; }
        public List<EventParam> Params { get; set; } = new List<EventParam>();
        public string Label { get; internal set; }

        public string ParamLabel(int p)
        {
            string label;
            if (String.IsNullOrEmpty(Params[p].Label))
                label = Params[p].Value.ToString();
            else
                label = Params[p].Label;
            if (Params[p].Mode == ParamMode.Relative)
                label = "(" + label + " + r)";
            return label;
        }

        public IntcodeEvent(long addr)
        {
            Address = addr;
        }
    }
}
