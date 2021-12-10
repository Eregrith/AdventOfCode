using System;

namespace AdventOfCode2021.Submarine
{
    public abstract class SubCommand
    {
        public abstract void ApplyTo(ControlledSubmarine sub);
    }

    public abstract class NumericParamCommand : SubCommand
    {
        protected readonly int _parameter;

        protected NumericParamCommand(int parameter)
        {
            _parameter = parameter;
        }
    }

    public class ForwardCommand : NumericParamCommand
    {
        public ForwardCommand(int parameter) : base(parameter) { }

        public override void ApplyTo(ControlledSubmarine sub) => sub.GoForward(_parameter);
    }

    public class DownCommand : NumericParamCommand
    {
        public DownCommand(int parameter) : base(parameter) { }

        public override void ApplyTo(ControlledSubmarine sub) => sub.GoDown(_parameter);
    }

    public class UpCommand : NumericParamCommand
    {
        public UpCommand(int parameter) : base(parameter) { }

        public override void ApplyTo(ControlledSubmarine sub) => sub.GoUp(_parameter);
    }
}