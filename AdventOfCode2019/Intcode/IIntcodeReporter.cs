using AdventOfCode2019.Intcode.Opcodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode
{
    public interface IIntcodeReporter
    {
        void Step(IntcodeContext context, Opcode currentOpcode);
    }
}
