using AdventOfCode2019.Intcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2019.Web.SignalR
{
    public interface IIntcodeClient
    {
        Task Step(IntcodeContext context);
        Task BroadcastMessage(string type, string payload);
    }
}
