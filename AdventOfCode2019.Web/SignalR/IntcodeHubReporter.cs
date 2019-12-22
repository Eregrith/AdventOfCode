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
        private long lastOutputQueueIndexNotified = -1;

        public IntcodeHubReporter(IHubContext<IntcodeHub, IIntcodeClient> hubContext)
        {
            _hubContext = hubContext;
        }

        public void Step(IntcodeContext context, Opcode currentOpcode)
        {
            if (context.OutputQueue.Count - 1 > lastOutputQueueIndexNotified)
            {
                _hubContext.Clients.All.Step(context, currentOpcode);
                lastOutputQueueIndexNotified = context.OutputQueue.Count - 1;
                _hubContext.Clients.All.Output((char)(context.OutputQueue.ToArray()[lastOutputQueueIndexNotified]));
            }
        }
    }
}
