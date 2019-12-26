using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Events
{
    public class DataEvent : IntcodeEvent
    {
        public long Data { get; set; }
        public DataEvent(long addr, long data) : base(addr)
        {
            Data = data;
        }

        public override string ToString()
        {
            return $"data {Data}";
        }
    }
}
