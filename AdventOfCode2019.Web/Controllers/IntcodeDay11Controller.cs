using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode2019.Intcode;
using AdventOfCode2019.Web.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using static AdventOfCode2019.DayTen;

namespace AdventOfCode2019.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntcodeDay11Controller : ControllerBase
    {
        private IHubContext<IntcodeHub, IIntcodeClient> _hubContext;

        public IntcodeDay11Controller(IHubContext<IntcodeHub, IIntcodeClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public string Post()
        {
            string retMessage = string.Empty;
            try
            {
                Message("intcode_console", "Robot Starting !");
                long[] data = InputHelper.GetIntcodeFromFile("11");
                List<Panel> panelsPainted = new List<Panel>();

                IntcodeComputer robot = new IntcodeComputer(data, IntcodeMode.Blocking | IntcodeMode.Quiet);
                Thread running = new Thread(() => robot.Run());
                running.Start();
                int x = 0;
                int y = 0;
                Direction facing = Direction.Up;
                while (!robot.IsFinished)
                {
                    Panel panelAtXY = panelsPainted.FirstOrDefault(p => p.X == x && p.Y == y);
                    if (panelAtXY == null)
                        robot.InputQueue.Enqueue(panelsPainted.Count == 0 ? 1 : 0);
                    else
                        robot.InputQueue.Enqueue(panelAtXY.Color == Color.White ? 1 : 0);
                    while (!robot.IsFinished && robot.OutputQueue.Count == 0) ;
                    if (robot.IsFinished) break;
                    long paint = robot.OutputQueue.Dequeue();
                    if (paint == 1)
                    {
                        if (panelAtXY != null)
                            panelAtXY.Color = Color.White;
                        else
                            panelsPainted.Add(new Panel(x, y, Color.White));
                    }
                    else
                    {
                        if (panelAtXY != null)
                            panelAtXY.Color = Color.Black;
                        else
                            panelsPainted.Add(new Panel(x, y, Color.Black));
                    }
                    while (robot.OutputQueue.Count == 0) ;
                    long action = robot.OutputQueue.Dequeue();
                    if (action == 1)
                        facing = TurnRight(facing);
                    else
                        facing = TurnLeft(facing);
                    switch (facing)
                    {
                        case Direction.Up:
                            y--;
                            break;
                        case Direction.Left:
                            x--;
                            break;
                        case Direction.Down:
                            y++;
                            break;
                        case Direction.Right:
                            x++;
                            break;
                    }
                }
                running.Join();
                Message("intcode_console", "Robot finished painting !");
                StringBuilder sb = new StringBuilder();
                for (y = panelsPainted.Min(p => p.Y); y <= panelsPainted.Max(p => p.Y); y++)
                {
                    for (x = panelsPainted.Min(p => p.X); x <= panelsPainted.Max(p => p.X); x++)
                    {
                        Panel panelAtXY = panelsPainted.FirstOrDefault(p => p.X == x && p.Y == y);
                        if (panelAtXY == null || panelAtXY.Color == Color.Black)
                            sb.Append('.');
                        else
                            sb.Append('#');
                    }
                    sb.AppendLine();
                }
                Message("intcode_console", $"{panelsPainted.Count} panels were painted !");
                Message("intcode_result", sb.ToString());
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }

        private static Direction TurnLeft(Direction facing)
        {
            switch (facing)
            {
                case Direction.Up:
                    return Direction.Left;
                case Direction.Left:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Up;
            }
            return Direction.Up;
        }

        private static Direction TurnRight(Direction facing)
        {
            return TurnLeft(TurnLeft(TurnLeft(facing)));
        }

        private void Message(string type, string payload)
        {
            _hubContext.Clients.All.BroadcastMessage(type, payload);
        }
    }
}