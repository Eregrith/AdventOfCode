using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Events
{
    public enum ParamMode
    {
        Relative,
        Immediate,
        Position
    }

    public class EventParam
    {
        public ParamMode Mode { get; internal set; }
        public long Value { get; internal set; }
        public string Label { get; internal set; }
    }
}
