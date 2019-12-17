using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2019.Intcode;
using AdventOfCode2019.Web.Requests;
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
        public List<string> GetIntcodeFiles()
        {
            return new List<string> { "11", "2", "5", "7", "9" };
        }

        [HttpPost]
        public void Start([FromBody]StartRequest request)
        {
            long[] data = InputHelper.GetIntcodeFromFile(request.File);
            _computer = new IntcodeComputer(data, IntcodeMode.Blocking);
            _computer.Reporter = _reporter;
            _intcodeHub.Clients.All.BroadcastMessage("intcode_console", "Started !");
        }

        [HttpPost]
        public void SendInput([FromBody]InputRequest request)
        {   
            _computer.InputQueue.Enqueue(request.Input);
        }

        [HttpGet]
        public void Step()
        {
            if (_computer != null)
            {
                _computer.Step();
            }
            else
            {
                _intcodeHub.Clients.All.BroadcastMessage("intcode_console", "Can't step : _computer is null");
            }
        }
    }
}