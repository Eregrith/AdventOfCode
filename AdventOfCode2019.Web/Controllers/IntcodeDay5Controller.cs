using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2019.Intcode;
using AdventOfCode2019.Web.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AdventOfCode2019.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IntcodeDay5Controller : ControllerBase
    {
        private readonly IIntcodeReporter _reporter;
        private readonly IHubContext<IntcodeHub, IIntcodeClient> _intcodeHub;
        private static IntcodeComputer _computer;

        public IntcodeDay5Controller(IIntcodeReporter reporter, IHubContext<IntcodeHub, IIntcodeClient> hubContext)
        {
            _reporter = reporter;
            _intcodeHub = hubContext;
        }

        [HttpGet]
        public void Start()
        {
            long[] data = InputHelper.GetIntcodeFromFile("5");
            _computer = new IntcodeComputer(data);
            _computer.InputQueue.Enqueue(1);
            _computer.Reporter = _reporter;
            _intcodeHub.Clients.All.BroadcastMessage("intcode_console", "Started !");
        }

        [HttpGet]
        public void Step()
        {
            if (_computer != null)
            {
                _computer.Step();
                _intcodeHub.Clients.All.BroadcastMessage("intcode_console", "Stepped !");
            }
            else
            {
                _intcodeHub.Clients.All.BroadcastMessage("intcode_console", "Can't step : _computer is null");
            }
        }
    }
}