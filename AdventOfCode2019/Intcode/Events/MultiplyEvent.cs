namespace AdventOfCode2019.Intcode.Events
{
    internal class MultiplyEvent : IntcodeEvent
    {
        public MultiplyEvent(long addr, EventParam a, EventParam b, EventParam c) : base(addr)
        {
            Params.Add(a);
            Params.Add(b);
            Params.Add(c);
        }

        public override string ToString()
        {
            return $"{ParamLabel(2)} = {ParamLabel(0)} * {ParamLabel(1)}";
        }
    }
}