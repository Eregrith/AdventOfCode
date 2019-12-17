using AdventOfCode2019.Intcode;
using AdventOfCode2019.Intcode.Opcodes;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2019.Web.SignalR
{
    public class IntcodeHubReporter : IIntcodeReporter
    {
        private readonly IHubContext<IntcodeHub, IIntcodeClient> _hubContext;

        public IntcodeHubReporter(IHubContext<IntcodeHub, IIntcodeClient> hubContext)
        {
            _hubContext = hubContext;
        }

        public void Step(IntcodeContext context, Opcode currentOpcode)
        {
            _hubContext.Clients.All.Step(context, currentOpcode);
        }
    }
}
