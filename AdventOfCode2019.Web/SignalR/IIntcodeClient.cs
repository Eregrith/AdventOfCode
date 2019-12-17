using AdventOfCode2019.Intcode;
using AdventOfCode2019.Intcode.Opcodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2019.Web.SignalR
{
    public interface IIntcodeClient
    {
        Task Step(IntcodeContext context, Opcode currentOpcode);
        Task BroadcastMessage(string type, string payload);
    }
}
