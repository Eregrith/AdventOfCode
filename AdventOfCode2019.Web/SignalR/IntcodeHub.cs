using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2019.Web.SignalR
{
    public class IntcodeHub : Hub<IIntcodeClient>
    {
    }
}
